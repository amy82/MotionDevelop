
namespace MotorControlTest
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
            this.btn_ini_Load = new System.Windows.Forms.Button();
            this.btn_ini_Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_ini_Load
            // 
            this.btn_ini_Load.Location = new System.Drawing.Point(416, 86);
            this.btn_ini_Load.Name = "btn_ini_Load";
            this.btn_ini_Load.Size = new System.Drawing.Size(75, 23);
            this.btn_ini_Load.TabIndex = 0;
            this.btn_ini_Load.Text = "Ini Load";
            this.btn_ini_Load.UseVisualStyleBackColor = true;
            this.btn_ini_Load.Click += new System.EventHandler(this.btn_Ini_Load_Click);
            // 
            // btn_ini_Save
            // 
            this.btn_ini_Save.Location = new System.Drawing.Point(416, 115);
            this.btn_ini_Save.Name = "btn_ini_Save";
            this.btn_ini_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_ini_Save.TabIndex = 1;
            this.btn_ini_Save.Text = "Ini Save";
            this.btn_ini_Save.UseVisualStyleBackColor = true;
            this.btn_ini_Save.Click += new System.EventHandler(this.btn_Ini_Save_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 450);
            this.Controls.Add(this.btn_ini_Save);
            this.Controls.Add(this.btn_ini_Load);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ini_Load;
        private System.Windows.Forms.Button btn_ini_Save;
    }
}

