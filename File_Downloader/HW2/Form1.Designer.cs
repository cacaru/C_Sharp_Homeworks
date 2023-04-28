namespace HW2 {
    partial class Form1 {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent() {
            this.iptxt = new System.Windows.Forms.TextBox();
            this.porttxt = new System.Windows.Forms.TextBox();
            this.pathtxt = new System.Windows.Forms.TextBox();
            this.sbtn = new System.Windows.Forms.Button();
            this.pathbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.log = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // iptxt
            // 
            this.iptxt.Location = new System.Drawing.Point(73, 12);
            this.iptxt.Name = "iptxt";
            this.iptxt.Size = new System.Drawing.Size(514, 21);
            this.iptxt.TabIndex = 0;
            // 
            // porttxt
            // 
            this.porttxt.Location = new System.Drawing.Point(73, 39);
            this.porttxt.Name = "porttxt";
            this.porttxt.Size = new System.Drawing.Size(514, 21);
            this.porttxt.TabIndex = 1;
            // 
            // pathtxt
            // 
            this.pathtxt.AcceptsReturn = true;
            this.pathtxt.Location = new System.Drawing.Point(73, 66);
            this.pathtxt.Name = "pathtxt";
            this.pathtxt.ReadOnly = true;
            this.pathtxt.Size = new System.Drawing.Size(514, 21);
            this.pathtxt.TabIndex = 2;
            // 
            // sbtn
            // 
            this.sbtn.Location = new System.Drawing.Point(612, 16);
            this.sbtn.Name = "sbtn";
            this.sbtn.Size = new System.Drawing.Size(91, 38);
            this.sbtn.TabIndex = 3;
            this.sbtn.Text = "서버켜기";
            this.sbtn.UseVisualStyleBackColor = true;
            this.sbtn.Click += new System.EventHandler(this.Sbtn_Click);
            // 
            // pathbtn
            // 
            this.pathbtn.Location = new System.Drawing.Point(612, 66);
            this.pathbtn.Name = "pathbtn";
            this.pathbtn.Size = new System.Drawing.Size(91, 21);
            this.pathbtn.TabIndex = 4;
            this.pathbtn.Text = "경로선택";
            this.pathbtn.UseVisualStyleBackColor = true;
            this.pathbtn.Click += new System.EventHandler(this.Pathbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "PORT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "PATH";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "log";
            // 
            // log
            // 
            this.log.Location = new System.Drawing.Point(12, 123);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(691, 549);
            this.log.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 684);
            this.Controls.Add(this.log);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pathbtn);
            this.Controls.Add(this.sbtn);
            this.Controls.Add(this.pathtxt);
            this.Controls.Add(this.porttxt);
            this.Controls.Add(this.iptxt);
            this.Name = "Form1";
            this.Text = "File Manager - Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox iptxt;
        private System.Windows.Forms.TextBox porttxt;
        private System.Windows.Forms.TextBox pathtxt;
        private System.Windows.Forms.Button sbtn;
        private System.Windows.Forms.Button pathbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox log;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}

