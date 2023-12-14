using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScottPlot;
using ScottPlot.Plottable;


namespace dataCut_V3
{
    public partial class Form1 : Form
    {
        int motionStartTime = 0;
        int motionRange = 0;
        string origenFilePath;
        int colorIndex = 0;
        FormsPlot formsPlot = new FormsPlot();
        VLine vStartLine;
        VLine vEndLine;
        private List<ScatterPlotDraggable> scatterList = new List<ScatterPlotDraggable>();

        Dictionary<string, List<AxisData>> axisData_Dic = new Dictionary<string, List<AxisData>>();
        Dictionary<string, List<Data>> groupedData;

        static Dictionary<string, string> setting_Dic = new Dictionary<string, string>();


        public Form1()
        {
            InitializeComponent();
            graph_setting();

            nowStatus_textBox.ScrollBars = ScrollBars.Vertical;
            setting_textBox.ScrollBars = ScrollBars.Vertical;
        }

        #region 그래프 설정

        private void Set_vLine(int startTime, int endTime)
        {
            var vZeroLine = formsPlot.Plot.AddVerticalLine(0);
            vZeroLine.DragEnabled = false;
            vZeroLine.DragLimitMin = 0;
            vZeroLine.PositionLabel = true;

            vStartLine = formsPlot.Plot.AddVerticalLine(startTime);
            vStartLine.DragEnabled = true;
            vStartLine.DragLimitMin = 0;
            vStartLine.PositionLabel = true;


            vEndLine = formsPlot.Plot.AddVerticalLine(endTime);
            vEndLine.DragEnabled = true;
            vEndLine.DragLimitMin = 0;
            vEndLine.PositionLabel = true;
        }
        private void graph_setting()
        {

            formsPlot.Plot.Palette = ScottPlot.Palette.OneHalfDark;
            formsPlot.Plot.Legend();
            /*
                        for (int i = 0; i < formsPlot.Plot.Palette.Count(); i++)
                        {
                            double[] xs = DataGen.Consecutive(100);
                            double[] ys = DataGen.Sin(100, phase: -i * .5 / formsPlot.Plot.Palette.Count());
                            formsPlot.Plot.AddScatterLines(xs, ys, lineWidth: 3);
                        }
                        formsPlot.Plot.Title($"{formsPlot.Plot.Palette}");
                        formsPlot.Plot.AxisAuto(0, 0.1);
                        formsPlot.Plot.Style(ScottPlot.Style.Gray1);
                        var bnColor = System.Drawing.ColorTranslator.FromHtml("#2e3440");
                        formsPlot.Plot.Style(figureBackground: bnColor, dataBackground: bnColor);
                        plotPanel.Controls.Add(formsPlot);
                        formsPlot.Refresh();
            */
            // add axis lines and configure their drag settings

            Set_vLine(0, 5000);

            formsPlot.Dock = DockStyle.Fill;
            plotPanel.Controls.Add(formsPlot);
            formsPlot.Refresh();
        }

        

        #endregion



        #region 그래프 그리기
        private void paint_Plot(ScatterPlotDraggable scatter)
        {            
            formsPlot.Plot.Add(scatter);

            formsPlot.Refresh();
        }
        /* 축 값을 읽고 그래프 그리기 */
        private void readAxisData(string id)
        {
            if (groupedData.ContainsKey(id))
            {
                List<Data> targetData = groupedData[id];

                AxisData axisData = new AxisData
                {
                    Label = new string[targetData.Count],
                    X = new double[targetData.Count],
                    Y = new double[targetData.Count]
                };

                for (int i = 0; i < targetData.Count; i++)
                {
                    axisData.Label[i] = targetData[i].FullId;
                    // data.Time을 x에 추가
                    axisData.X[i] = Convert.ToDouble(targetData[i].Time);

                    // data.Value를 y에 추가
                    axisData.Y[i] = Convert.ToDouble(targetData[i].Value);                   
                }

                // Check if the ID exists in the dictionary
                if (axisData_Dic.ContainsKey(id))
                {
                    axisData_Dic[id].Add(axisData);
                }
                else
                {
                    // If the ID doesn't exist, create a new list and add it to the dictionary
                    axisData_Dic[id] = new List<AxisData> { axisData };
                }

                var scatter = new ScatterPlotDraggable(axisData_Dic[id].LastOrDefault().X, axisData_Dic[id].LastOrDefault().Y)
                {
                    Color = GetNextColor(),
                    DragEnabled = true,   // controls whether anything can be dragged
                    DragEnabledX = false, // controls whether points can be dragged horizontally 
                    DragEnabledY = true,  // controls whether points can be dragged vertically
                };
                scatter.Label = targetData[0].FullId;

                scatterList.Add(scatter);
                paint_Plot(scatterList.LastOrDefault());
            }
            else
            {
                Console.WriteLine($"ID {id}에 해당하는 데이터가 없습니다.");
            }
        }

        private Color GetNextColor()
        {
            Color nextColor = formsPlot.Plot.Palette.GetColor(colorIndex++);
            
            if (formsPlot.Plot.Palette.Count() <= colorIndex)
                colorIndex = 0;

            return nextColor;
        }
        #endregion

        #region 데이터 읽기
        private void openBtn_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                // CSV 파일 필터 설정
                openFileDialog.Filter = "CSV 파일 (*.csv)|*.csv|모든 파일 (*.*)|*.*";
                // 사용자가 파일을 선택하면
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 선택한 파일의 경로 출력
                    Console.WriteLine("선택한 파일: " + openFileDialog.FileName);
                    origenFilePath = openFileDialog.FileName;


                    /* 그래프 재설정 */
                    formsPlot.Plot.Clear();
                    scatterList.Clear();
                    colorIndex = 0;
                    motionStartTime = 0;

                    int.TryParse(startTime_textBox.Text, out int startTime_int);
                    int.TryParse(endTime_textBox.Text, out int endTime_int);
                    Set_vLine(startTime_int, endTime_int);


                    // CSV 파일 읽기
                    List<Data> dataList = ReadCsv(origenFilePath);

                    // ID로 그룹화
                    if (groupedData != null)
                        groupedData.Clear();

                    groupedData = GroupDataById(dataList);

                    Console.WriteLine($"그룹 개수: {groupedData.Count}");

                    // 출력: 각 그룹의 FullId
                    foreach (var groupId in groupedData.Keys)
                    {
                        Console.WriteLine($"그룹 FullId: {groupId}");
                        readAxisData(groupId);
                    }
                    //readAxisData("1#1");
                    //readAxisData("1#3");

                }
            }
        }
        static Dictionary<string, List<Data>> GroupDataById(List<Data> dataList)
        {
            return dataList.GroupBy(data => data.FullId)
                          .ToDictionary(group => group.Key, group => group.ToList());
        }
        /* csv 를 읽어 항목별로 Tag하여 List에 추가*/
        static List<Data> ReadCsv(string filePath)
        {
            List<Data> dataList = new List<Data>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length >= 3)
                    {
                        string time = parts[0];
                        string value = parts[1];
                        string fullId = parts[2];

                        dataList.Add(new Data { Time = time, Value = value, FullId = fullId });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading CSV file: {ex.Message}");
            }

            return dataList;
        }
        #endregion

        #region step1_사용구간지정
        private void startTime_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If not a digit or control key, suppress the key press
                e.Handled = true;
            }
        }
        private void endTime_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If not a digit or control key, suppress the key press
                e.Handled = true;
            }
        }

        private void readToGraph_Btn_Click(object sender, EventArgs e)
        {
            startTime_textBox.Text = Convert.ToInt32(vStartLine.X).ToString();
            endTime_textBox.Text = Convert.ToInt32(vEndLine.X).ToString();
        }

        private void timeCut_btn_Click(object sender, EventArgs e)
        {
            /*
            for(int i = 0; i < axisData_Dic["1#1"].LastOrDefault().X.Count(); i++)
            {
               // axisData_Dic["1#1"].LastOrDefault().X[i] = i;
                axisData_Dic["1#1"].LastOrDefault().Y[i] = 500;
            }*/
            int.TryParse(startTime_textBox.Text, out int startTime_int);
            int.TryParse(endTime_textBox.Text, out int endTime_int);

            if (startTime_int > endTime_int)
                return;

            motionRange = endTime_int - startTime_int;


            /* 그래프 재설정 */
            formsPlot.Plot.Clear();
            scatterList.Clear();
            colorIndex = 0;



            //Set_vLine(startTime_int, endTime_int);
            Set_vLine(1000, endTime_int-(startTime_int-1000));
            motionStartTime = 1000;

            foreach (var dataList in axisData_Dic.Values)
            {
                foreach (var axisData in dataList)
                {
                    // X값이 1000이상 3000미만인 값을 남기기
                    
                    axisData.Y = axisData.Y
                                .Where((yValue, index) => axisData.X.Length > index && axisData.X[index] >= startTime_int && axisData.X[index] < endTime_int)
                                .ToArray();
                    axisData.X = axisData.X.Where(xValue => xValue >= startTime_int && xValue < endTime_int).ToArray();

                    if (axisData.X.Count() != 0)
                    {
                        var scatter = new ScatterPlotDraggable(axisData.X, axisData.Y)
                        {
                            Color = GetNextColor(),
                            DragEnabled = true,   // controls whether anything can be dragged
                            DragEnabledX = false, // controls whether points can be dragged horizontally 
                            DragEnabledY = true,  // controls whether points can be dragged vertically
                        };
                        scatter.Label = axisData.Label[0];
                        scatterList.Add(scatter);
                        paint_Plot(scatterList.LastOrDefault());
                    }                    
                }                
            }

            foreach (var dataList in axisData_Dic.Values)
            {
                foreach (var axisData in dataList)
                {
                    for (int i = 0; i < axisData.X.Length; i++)
                    {
                        axisData.X[i] -= startTime_int - 1000;
                    }
                }
            }
            formsPlot.Refresh();
        }
        #endregion

        #region step2_시간축 이동
        private void moveTime_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If not a digit or control key, suppress the key press
                e.Handled = true;
            }
        }

        private void move_Plus_Btn_Click(object sender, EventArgs e)
        {
            
            if (int.TryParse(moveTime_textBox.Text, out int moveTime_int))
            {
                motionStartTime += moveTime_int;
                foreach (var dataList in axisData_Dic.Values)
                {
                    foreach (var axisData in dataList)
                    {
                        for (int i = 0; i < axisData.X.Length; i++)
                        {
                            axisData.X[i] += moveTime_int;
                        }
                    }
                }
                formsPlot.Refresh();
            }
        }
        private void moveMinus_Btn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(moveTime_textBox.Text, out int moveTime_int))
            {
                motionStartTime -= moveTime_int;
                foreach (var dataList in axisData_Dic.Values)
                {
                    foreach (var axisData in dataList)
                    {
                        for (int i = 0; i < axisData.X.Length; i++)
                        {
                            axisData.X[i] -= moveTime_int;
                        }
                    }
                }
                formsPlot.Refresh();
            }
        }

        #endregion

        #region step3_현재 상태 조회

        private void nowStatus_Btn_Click(object sender, EventArgs e)
        {
            string statusLog = "";
            foreach (var dataList in axisData_Dic.Values)
            {
                foreach (var axisData in dataList)
                {
                    if (axisData.X.Length > 0)
                    {
                        double firstXValue = axisData.X.First();
                        double lastXValue = axisData.X.Last();

                        double firstYValue = axisData.Y.First();
                        double lastYValue = axisData.Y.Last();

                        statusLog += $"ID : {axisData.Label[0]}{Environment.NewLine}" +
                            $"  시작 : {firstYValue,4}  [{firstXValue}ms]{Environment.NewLine}" +
                            $"  종료 : {lastYValue,4}   [{lastXValue}ms]{Environment.NewLine}"; 
                    }
                }
            }
            nowStatus_textBox.Text = statusLog;
        }


        #endregion

        #region step4_설정파일 읽기
        private void setting_Btn_Click(object sender, EventArgs e)
        {
            // 파일 다이얼로그 생성
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select Text File",
                Filter = "Text Files|*.txt|All Files|*.*",
                DefaultExt = "txt"
            };

            // 파일을 선택하면
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 선택한 파일의 경로 출력
                Console.WriteLine("Selected File: " + openFileDialog.FileName);

                // 선택한 파일의 경로를 전역 변수로 저장
                string filePath = openFileDialog.FileName;

                // 파일 이름이 MT_ST.TXT인 경우에만 처리
                if (Path.GetFileName(filePath).Equals("MT_ST.TXT", StringComparison.OrdinalIgnoreCase))
                {
                    // 파일에서 각 줄 읽어오기
                    string[] lines = File.ReadAllLines(filePath);

                    foreach (string line in lines)
                    {
                        // 쉼표로 분리된 값 추출
                        string[] values = line.Split(',');

                        if (values.Length >= 6)
                        {
                            // fullID (두 번째 항목)
                            string fullID = values[1];

                            // fullID 형식 변경 (1.1 -> 1#1)
                            fullID = fullID.Replace(".", "#");

                            // initPosition (다섯 번째 항목)
                            string initPosition = values[4];

                            // 결과 출력 또는 다른 처리
                            Console.WriteLine($"Full ID: {fullID}, Init Position: {initPosition}");

                            // Dictionary에 추가
                            setting_Dic[fullID] = initPosition;
                        }
                        else
                        {
                            Console.WriteLine("Invalid line format");
                        }
                    }

                    // Dictionary 확인
                    setting_textBox.Text = "";
                    foreach (var entry in setting_Dic)
                    {
                        Console.WriteLine($"Full ID: {entry.Key}, Init Position: {entry.Value}");

                        if (axisData_Dic.ContainsKey(entry.Key))
                        {
                            setting_textBox.Text += $"ID : {entry.Key,5} initPosi : {entry.Value,4}{Environment.NewLine}";
                        }                        
                    }
                }
                else
                {
                    setting_textBox.Text = "MT_ST.TXT 파일을 선택하세요";
                    Console.WriteLine("Invalid file name. Please select MT_ST.TXT");
                }
            }
            else
            {
                Console.WriteLine("File selection canceled");
            }
        }
        #endregion

        #region step5_보간
        private void endMoveTime_Btn_Click(object sender, EventArgs e)
        {

            /* 그래프 재설정 */
            int.TryParse(startTime_textBox.Text, out int startTime_int);
            int.TryParse(endTime_textBox.Text, out int endTime_int);

            if (startTime_int > endTime_int)
                return;

            formsPlot.Plot.Clear();
            scatterList.Clear();
            colorIndex = 0;

            Set_vLine(1000, endTime_int - (startTime_int - 1000));

            int.TryParse(endMoveTime_textBox.Text, out int endMoveTime_int);

            foreach (var kvp in axisData_Dic)
            {
                List<AxisData> dataList = kvp.Value;

                foreach (AxisData data in dataList)
                {
                    if (setting_Dic.ContainsKey(data.Label[0]))
                    {
                        if (int.TryParse(setting_Dic[data.Label[0]], out int initPosi_int))
                        {
                            if (data.X.Length != 0)
                            {
                                InterpolateLine(data,
                                    motionStartTime, motionStartTime + motionRange, //자른 모션 시작,끝 시간
                                    0, motionStartTime + motionRange + endMoveTime_int, //변경 후 시작,끝 시간
                                    initPosi_int); //init posi 
                            }
                            else
                            {
                                // data.X가 비어있을 경우 처리
                            }
                        }
                        else
                        {
                            // initPosi_int로의 변환 실패 시 처리
                        }
                    }
                    else
                    {
                        // data.Label이 setting_Dic에 없을 경우 처리
                    }


                    /*
                    foreach (var entry in setting_Dic)
                    {
                        if (axisData_Dic.ContainsKey(data.Label))
                        {
                            int.TryParse(entry.Value, out int initPosi_int);
                           
                        }
                    }*/
                }
            }

            foreach (var dataList in axisData_Dic.Values)
            {
                foreach (var axisData in dataList)
                {
                    if (axisData.X.Count() != 0)
                    {
                        var scatter = new ScatterPlotDraggable(axisData.X, axisData.Y)
                        {
                            Color = GetNextColor(),
                            DragEnabled = true,   // controls whether anything can be dragged
                            DragEnabledX = false, // controls whether points can be dragged horizontally 
                            DragEnabledY = true,  // controls whether points can be dragged vertically
                        };
                        scatter.Label = axisData.Label[0];
                        scatterList.Add(scatter);
                        paint_Plot(scatterList.LastOrDefault());
                    }
                }
            }
            formsPlot.Refresh();
        }

        static void InterpolateLine(AxisData data, double mStartTime, double mEndTime, double startTime, double endTime, double initPosi)
        {
            /* 시작 부분 */
            // 보간할 점의 개수 계산
            int numStartPoints = (int)((mStartTime - startTime) / 20) + 1;

            // 보간된 값 저장
            List<double> startX = new List<double>();
            List<double> startY = new List<double>();

            for (int i = 0; i < numStartPoints; i++)
            {
                double x = i * 20;
                double y = InterpolateY(0, initPosi, mStartTime, data.Y[0], x);

                startX.Add(x);
                startY.Add(y);
            }

            // 기존 데이터에 보간된 값 추가

            double[] newX = startX.Concat(data.X).ToArray();
            double[] newY = startY.Concat(data.Y).ToArray();

            // 기존 데이터 갱신
            data.X = newX;
            data.Y = newY;

            /* 끝부분 */
            // 보간할 점의 개수 계산
            int numEndPoints = (int)((endTime - mEndTime) / 20) + 1;

            // 보간된 값 저장
            List<double> endX = new List<double>();
            List<double> endY = new List<double>();

            for (int i = 0; i < numEndPoints; i++)
            {
                double x = mEndTime + (i * 20);
                double y = InterpolateY(mEndTime, data.Y[data.Y.Length - 1], endTime, initPosi, x);

                endX.Add(x);
                endY.Add(y);
            }

            // 기존 데이터에 보간된 값 추가
            data.X = data.X.Concat(endX).ToArray();
            data.Y = data.Y.Concat(endY).ToArray();


        }

        static double InterpolateY(double x1, double y1, double x2, double y2, double x)
        {
            return y1 + (y2 - y1) * (x - x1) / (x2 - x1);
        }

        #endregion

        #region 저장
        private void save_Btn_Click(object sender, EventArgs e)
        {
            // 파일 다이얼로그 열기
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV Files (*.CSV)|*.csv";
            saveFileDialog.Title = "모션 유닛 저장";
            saveFileDialog.FileName = "Unit_.CSV";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                List<Tuple<double, double, string>> allData = new List<Tuple<double, double, string>>();

                foreach (var kvp in axisData_Dic)
                {
                    List<AxisData> dataList = kvp.Value;

                    foreach (AxisData data in dataList)
                    {
                        for (int i = 0; i < data.X.Length; i++)
                        {
                            allData.Add(Tuple.Create(data.X[i], data.Y[i], data.Label[i]));
                        }
                    }
                }

                // 전체 데이터 정렬
                var sortedData = allData.OrderBy(tuple => tuple.Item1).ToList();

                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    // CSV 헤더 쓰기
                    //sw.WriteLine("X,Y,Label");

                    // 정렬된 데이터 작성
                    foreach (var tuple in sortedData)
                    {
                        sw.WriteLine($"{Convert.ToInt32(tuple.Item1)},{Convert.ToInt32(tuple.Item2)},{tuple.Item3}");
                    }
                }
            }
        }

        #endregion


    }
}

class AxisData
{
    public string[] Label;
    public double[] X { get; set; }
    public double[] Y { get; set; }    
}

class Data
{
    public string Time { get; set; }
    public string Value { get; set; }
    public string FullId { get; set; }
}



