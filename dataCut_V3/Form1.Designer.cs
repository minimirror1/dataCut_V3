
namespace dataCut_V3
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.openBtn = new System.Windows.Forms.Button();
            this.plotPanel = new System.Windows.Forms.Panel();
            this.startTime_textBox = new System.Windows.Forms.TextBox();
            this.endTime_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.readToGraph_Btn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.timeCut_btn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.startTime_label = new System.Windows.Forms.Label();
            this.moveMinus_Btn = new System.Windows.Forms.Button();
            this.move_Plus_Btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.moveTime_textBox = new System.Windows.Forms.TextBox();
            this.moveZero_Btn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nowStatus_Btn = new System.Windows.Forms.Button();
            this.nowStatus_textBox = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.setting_Btn = new System.Windows.Forms.Button();
            this.setting_textBox = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.save_Btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.endMoveTime_textBox = new System.Windows.Forms.TextBox();
            this.endMoveTime_Btn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(11, 476);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(75, 47);
            this.openBtn.TabIndex = 1;
            this.openBtn.Text = "Open MTC_ALL";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // plotPanel
            // 
            this.plotPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.plotPanel.Location = new System.Drawing.Point(12, 12);
            this.plotPanel.Name = "plotPanel";
            this.plotPanel.Size = new System.Drawing.Size(1044, 415);
            this.plotPanel.TabIndex = 2;
            // 
            // startTime_textBox
            // 
            this.startTime_textBox.Location = new System.Drawing.Point(6, 32);
            this.startTime_textBox.Name = "startTime_textBox";
            this.startTime_textBox.Size = new System.Drawing.Size(100, 21);
            this.startTime_textBox.TabIndex = 3;
            this.startTime_textBox.Text = "0";
            this.startTime_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.startTime_textBox_KeyPress);
            // 
            // endTime_textBox
            // 
            this.endTime_textBox.Location = new System.Drawing.Point(6, 71);
            this.endTime_textBox.Name = "endTime_textBox";
            this.endTime_textBox.Size = new System.Drawing.Size(100, 21);
            this.endTime_textBox.TabIndex = 4;
            this.endTime_textBox.Text = "5000";
            this.endTime_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.endTime_textBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "시작시간";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "끝시간";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.readToGraph_Btn);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.timeCut_btn);
            this.groupBox1.Controls.Add(this.startTime_textBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.endTime_textBox);
            this.groupBox1.Location = new System.Drawing.Point(92, 470);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(115, 180);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. 사용구간지정";
            // 
            // readToGraph_Btn
            // 
            this.readToGraph_Btn.Location = new System.Drawing.Point(6, 98);
            this.readToGraph_Btn.Name = "readToGraph_Btn";
            this.readToGraph_Btn.Size = new System.Drawing.Size(100, 23);
            this.readToGraph_Btn.TabIndex = 9;
            this.readToGraph_Btn.Text = "그래프에서읽기";
            this.readToGraph_Btn.UseVisualStyleBackColor = true;
            this.readToGraph_Btn.Click += new System.EventHandler(this.readToGraph_Btn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "구간 외 데이터\r\n제거";
            // 
            // timeCut_btn
            // 
            this.timeCut_btn.Location = new System.Drawing.Point(6, 151);
            this.timeCut_btn.Name = "timeCut_btn";
            this.timeCut_btn.Size = new System.Drawing.Size(101, 23);
            this.timeCut_btn.TabIndex = 7;
            this.timeCut_btn.Text = "적용";
            this.timeCut_btn.UseVisualStyleBackColor = true;
            this.timeCut_btn.Click += new System.EventHandler(this.timeCut_btn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.startTime_label);
            this.groupBox2.Controls.Add(this.moveMinus_Btn);
            this.groupBox2.Controls.Add(this.move_Plus_Btn);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.moveTime_textBox);
            this.groupBox2.Controls.Add(this.moveZero_Btn);
            this.groupBox2.Location = new System.Drawing.Point(213, 470);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(123, 180);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2.시간 축 이동";
            // 
            // startTime_label
            // 
            this.startTime_label.AutoSize = true;
            this.startTime_label.Location = new System.Drawing.Point(4, 83);
            this.startTime_label.Name = "startTime_label";
            this.startTime_label.Size = new System.Drawing.Size(73, 12);
            this.startTime_label.TabIndex = 5;
            this.startTime_label.Text = "시간 축 이동";
            // 
            // moveMinus_Btn
            // 
            this.moveMinus_Btn.Location = new System.Drawing.Point(6, 151);
            this.moveMinus_Btn.Name = "moveMinus_Btn";
            this.moveMinus_Btn.Size = new System.Drawing.Size(55, 23);
            this.moveMinus_Btn.TabIndex = 4;
            this.moveMinus_Btn.Text = "-";
            this.moveMinus_Btn.UseVisualStyleBackColor = true;
            this.moveMinus_Btn.Click += new System.EventHandler(this.moveMinus_Btn_Click);
            // 
            // move_Plus_Btn
            // 
            this.move_Plus_Btn.Location = new System.Drawing.Point(62, 151);
            this.move_Plus_Btn.Name = "move_Plus_Btn";
            this.move_Plus_Btn.Size = new System.Drawing.Size(55, 23);
            this.move_Plus_Btn.TabIndex = 3;
            this.move_Plus_Btn.Text = "+";
            this.move_Plus_Btn.UseVisualStyleBackColor = true;
            this.move_Plus_Btn.Click += new System.EventHandler(this.move_Plus_Btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "시간 축 이동";
            // 
            // moveTime_textBox
            // 
            this.moveTime_textBox.Location = new System.Drawing.Point(6, 124);
            this.moveTime_textBox.Name = "moveTime_textBox";
            this.moveTime_textBox.Size = new System.Drawing.Size(100, 21);
            this.moveTime_textBox.TabIndex = 1;
            this.moveTime_textBox.Text = "1000";
            this.moveTime_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.moveTime_textBox_KeyPress);
            // 
            // moveZero_Btn
            // 
            this.moveZero_Btn.Location = new System.Drawing.Point(6, 20);
            this.moveZero_Btn.Name = "moveZero_Btn";
            this.moveZero_Btn.Size = new System.Drawing.Size(111, 23);
            this.moveZero_Btn.TabIndex = 0;
            this.moveZero_Btn.Text = "좌측 정렬";
            this.moveZero_Btn.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nowStatus_Btn);
            this.groupBox3.Controls.Add(this.nowStatus_textBox);
            this.groupBox3.Location = new System.Drawing.Point(342, 470);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(258, 180);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "3.현재 상태 조회";
            // 
            // nowStatus_Btn
            // 
            this.nowStatus_Btn.Location = new System.Drawing.Point(177, 151);
            this.nowStatus_Btn.Name = "nowStatus_Btn";
            this.nowStatus_Btn.Size = new System.Drawing.Size(75, 23);
            this.nowStatus_Btn.TabIndex = 1;
            this.nowStatus_Btn.Text = "조회";
            this.nowStatus_Btn.UseVisualStyleBackColor = true;
            this.nowStatus_Btn.Click += new System.EventHandler(this.nowStatus_Btn_Click);
            // 
            // nowStatus_textBox
            // 
            this.nowStatus_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nowStatus_textBox.Location = new System.Drawing.Point(6, 20);
            this.nowStatus_textBox.Multiline = true;
            this.nowStatus_textBox.Name = "nowStatus_textBox";
            this.nowStatus_textBox.ReadOnly = true;
            this.nowStatus_textBox.Size = new System.Drawing.Size(246, 125);
            this.nowStatus_textBox.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.setting_Btn);
            this.groupBox4.Controls.Add(this.setting_textBox);
            this.groupBox4.Location = new System.Drawing.Point(606, 470);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(258, 180);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "4.시작,종료위치 불러오기";
            // 
            // setting_Btn
            // 
            this.setting_Btn.Location = new System.Drawing.Point(144, 151);
            this.setting_Btn.Name = "setting_Btn";
            this.setting_Btn.Size = new System.Drawing.Size(108, 23);
            this.setting_Btn.TabIndex = 1;
            this.setting_Btn.Text = "Open MT_ST";
            this.setting_Btn.UseVisualStyleBackColor = true;
            this.setting_Btn.Click += new System.EventHandler(this.setting_Btn_Click);
            // 
            // setting_textBox
            // 
            this.setting_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.setting_textBox.Location = new System.Drawing.Point(6, 20);
            this.setting_textBox.Multiline = true;
            this.setting_textBox.Name = "setting_textBox";
            this.setting_textBox.ReadOnly = true;
            this.setting_textBox.Size = new System.Drawing.Size(246, 125);
            this.setting_textBox.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.save_Btn);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.endMoveTime_textBox);
            this.groupBox5.Controls.Add(this.endMoveTime_Btn);
            this.groupBox5.Location = new System.Drawing.Point(870, 470);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(185, 180);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "5.생성";
            // 
            // save_Btn
            // 
            this.save_Btn.Location = new System.Drawing.Point(104, 151);
            this.save_Btn.Name = "save_Btn";
            this.save_Btn.Size = new System.Drawing.Size(75, 23);
            this.save_Btn.TabIndex = 3;
            this.save_Btn.Text = "저장";
            this.save_Btn.UseVisualStyleBackColor = true;
            this.save_Btn.Click += new System.EventHandler(this.save_Btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "끝지점 이동시간";
            // 
            // endMoveTime_textBox
            // 
            this.endMoveTime_textBox.Location = new System.Drawing.Point(6, 56);
            this.endMoveTime_textBox.Name = "endMoveTime_textBox";
            this.endMoveTime_textBox.Size = new System.Drawing.Size(100, 21);
            this.endMoveTime_textBox.TabIndex = 1;
            this.endMoveTime_textBox.Text = "1000";
            // 
            // endMoveTime_Btn
            // 
            this.endMoveTime_Btn.Location = new System.Drawing.Point(6, 83);
            this.endMoveTime_Btn.Name = "endMoveTime_Btn";
            this.endMoveTime_Btn.Size = new System.Drawing.Size(75, 23);
            this.endMoveTime_Btn.TabIndex = 0;
            this.endMoveTime_Btn.Text = "생성";
            this.endMoveTime_Btn.UseVisualStyleBackColor = true;
            this.endMoveTime_Btn.Click += new System.EventHandler(this.endMoveTime_Btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 662);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.plotPanel);
            this.Controls.Add(this.openBtn);
            this.Name = "Form1";
            this.Text = "motionCut_V0.1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.Panel plotPanel;
        private System.Windows.Forms.TextBox startTime_textBox;
        private System.Windows.Forms.TextBox endTime_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button timeCut_btn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox moveTime_textBox;
        private System.Windows.Forms.Button moveZero_Btn;
        private System.Windows.Forms.Button move_Plus_Btn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox nowStatus_textBox;
        private System.Windows.Forms.Button nowStatus_Btn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button setting_Btn;
        private System.Windows.Forms.TextBox setting_textBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox endMoveTime_textBox;
        private System.Windows.Forms.Button endMoveTime_Btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button save_Btn;
        private System.Windows.Forms.Button readToGraph_Btn;
        private System.Windows.Forms.Button moveMinus_Btn;
        private System.Windows.Forms.Label startTime_label;
    }
}

