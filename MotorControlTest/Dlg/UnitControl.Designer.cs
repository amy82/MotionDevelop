
namespace MotorControlTest.Dlg
{
    partial class UnitControl
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Socekt_Ready = new System.Windows.Forms.Button();
            this.btn_Socekt_Pause = new System.Windows.Forms.Button();
            this.btn_Socekt_Stop = new System.Windows.Forms.Button();
            this.btn_Socekt_Start = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Socekt_Ready);
            this.groupBox1.Controls.Add(this.btn_Socekt_Pause);
            this.groupBox1.Controls.Add(this.btn_Socekt_Stop);
            this.groupBox1.Controls.Add(this.btn_Socekt_Start);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 230);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Socket";
            // 
            // btn_Socekt_Ready
            // 
            this.btn_Socekt_Ready.BackColor = System.Drawing.Color.DarkKhaki;
            this.btn_Socekt_Ready.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Socekt_Ready.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Socekt_Ready.Location = new System.Drawing.Point(19, 20);
            this.btn_Socekt_Ready.Name = "btn_Socekt_Ready";
            this.btn_Socekt_Ready.Size = new System.Drawing.Size(117, 45);
            this.btn_Socekt_Ready.TabIndex = 2;
            this.btn_Socekt_Ready.Text = "READY";
            this.btn_Socekt_Ready.UseVisualStyleBackColor = false;
            this.btn_Socekt_Ready.Click += new System.EventHandler(this.btn_Socekt_Ready_Click);
            // 
            // btn_Socekt_Pause
            // 
            this.btn_Socekt_Pause.BackColor = System.Drawing.Color.DarkKhaki;
            this.btn_Socekt_Pause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Socekt_Pause.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Socekt_Pause.Location = new System.Drawing.Point(19, 71);
            this.btn_Socekt_Pause.Name = "btn_Socekt_Pause";
            this.btn_Socekt_Pause.Size = new System.Drawing.Size(117, 45);
            this.btn_Socekt_Pause.TabIndex = 5;
            this.btn_Socekt_Pause.Text = "PAUSE";
            this.btn_Socekt_Pause.UseVisualStyleBackColor = false;
            this.btn_Socekt_Pause.Click += new System.EventHandler(this.btn_Socekt_Pause_Click);
            // 
            // btn_Socekt_Stop
            // 
            this.btn_Socekt_Stop.BackColor = System.Drawing.Color.DarkKhaki;
            this.btn_Socekt_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Socekt_Stop.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Socekt_Stop.Location = new System.Drawing.Point(19, 173);
            this.btn_Socekt_Stop.Name = "btn_Socekt_Stop";
            this.btn_Socekt_Stop.Size = new System.Drawing.Size(117, 45);
            this.btn_Socekt_Stop.TabIndex = 3;
            this.btn_Socekt_Stop.Text = "STOP";
            this.btn_Socekt_Stop.UseVisualStyleBackColor = false;
            this.btn_Socekt_Stop.Click += new System.EventHandler(this.btn_Socekt_Stop_Click);
            // 
            // btn_Socekt_Start
            // 
            this.btn_Socekt_Start.BackColor = System.Drawing.Color.DarkKhaki;
            this.btn_Socekt_Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Socekt_Start.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Socekt_Start.Location = new System.Drawing.Point(19, 122);
            this.btn_Socekt_Start.Name = "btn_Socekt_Start";
            this.btn_Socekt_Start.Size = new System.Drawing.Size(117, 45);
            this.btn_Socekt_Start.TabIndex = 4;
            this.btn_Socekt_Start.Text = "AUTORUN";
            this.btn_Socekt_Start.UseVisualStyleBackColor = false;
            this.btn_Socekt_Start.Click += new System.EventHandler(this.btn_Socekt_Start_Click);
            // 
            // UnitControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UnitControl";
            this.Size = new System.Drawing.Size(169, 236);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Socekt_Ready;
        private System.Windows.Forms.Button btn_Socekt_Pause;
        private System.Windows.Forms.Button btn_Socekt_Stop;
        private System.Windows.Forms.Button btn_Socekt_Start;
    }
}
