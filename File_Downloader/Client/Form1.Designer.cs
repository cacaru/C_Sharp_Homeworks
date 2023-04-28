namespace Client {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnopf = new System.Windows.Forms.Button();
            this.btnpath = new System.Windows.Forms.Button();
            this.btnconnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.porttxt = new System.Windows.Forms.TextBox();
            this.pathtxt = new System.Windows.Forms.TextBox();
            this.iptxt = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.상세정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.다운로드ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.자세히ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.간단히ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.작은아이콘ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.큰아이콘ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.treeView = new System.Windows.Forms.TreeView();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnopf);
            this.panel1.Controls.Add(this.btnpath);
            this.panel1.Controls.Add(this.btnconnect);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.porttxt);
            this.panel1.Controls.Add(this.pathtxt);
            this.panel1.Controls.Add(this.iptxt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 126);
            this.panel1.TabIndex = 1;
            // 
            // btnopf
            // 
            this.btnopf.Location = new System.Drawing.Point(524, 92);
            this.btnopf.Name = "btnopf";
            this.btnopf.Size = new System.Drawing.Size(93, 23);
            this.btnopf.TabIndex = 18;
            this.btnopf.Text = "폴더열기";
            this.btnopf.UseVisualStyleBackColor = true;
            // 
            // btnpath
            // 
            this.btnpath.Location = new System.Drawing.Point(335, 92);
            this.btnpath.Name = "btnpath";
            this.btnpath.Size = new System.Drawing.Size(93, 23);
            this.btnpath.TabIndex = 17;
            this.btnpath.Text = "경로설정";
            this.btnpath.UseVisualStyleBackColor = true;
            this.btnpath.Click += new System.EventHandler(this.Pathbtn_Click);
            // 
            // btnconnect
            // 
            this.btnconnect.Location = new System.Drawing.Point(133, 92);
            this.btnconnect.Name = "btnconnect";
            this.btnconnect.Size = new System.Drawing.Size(93, 23);
            this.btnconnect.TabIndex = 16;
            this.btnconnect.Text = "서버연결";
            this.btnconnect.UseVisualStyleBackColor = true;
            this.btnconnect.Click += new System.EventHandler(this.Btnconnect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "다운로드 경로 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "IP  :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(544, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "PORT : ";
            // 
            // porttxt
            // 
            this.porttxt.Location = new System.Drawing.Point(617, 12);
            this.porttxt.Name = "porttxt";
            this.porttxt.Size = new System.Drawing.Size(118, 21);
            this.porttxt.TabIndex = 12;
            // 
            // pathtxt
            // 
            this.pathtxt.Location = new System.Drawing.Point(133, 56);
            this.pathtxt.Name = "pathtxt";
            this.pathtxt.ReadOnly = true;
            this.pathtxt.Size = new System.Drawing.Size(602, 21);
            this.pathtxt.TabIndex = 11;
            // 
            // iptxt
            // 
            this.iptxt.Location = new System.Drawing.Point(89, 12);
            this.iptxt.Name = "iptxt";
            this.iptxt.Size = new System.Drawing.Size(412, 21);
            this.iptxt.TabIndex = 10;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.상세정보ToolStripMenuItem,
            this.다운로드ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.자세히ToolStripMenuItem,
            this.간단히ToolStripMenuItem,
            this.작은아이콘ToolStripMenuItem,
            this.큰아이콘ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(135, 142);
            // 
            // 상세정보ToolStripMenuItem
            // 
            this.상세정보ToolStripMenuItem.Name = "상세정보ToolStripMenuItem";
            this.상세정보ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.상세정보ToolStripMenuItem.Text = "상세정보";
            this.상세정보ToolStripMenuItem.Click += new System.EventHandler(this.상세정보ToolStripMenuItem_Click);
            // 
            // 다운로드ToolStripMenuItem
            // 
            this.다운로드ToolStripMenuItem.Name = "다운로드ToolStripMenuItem";
            this.다운로드ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.다운로드ToolStripMenuItem.Text = "다운로드";
            this.다운로드ToolStripMenuItem.Click += new System.EventHandler(this.다운로드ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(131, 6);
            // 
            // 자세히ToolStripMenuItem
            // 
            this.자세히ToolStripMenuItem.Name = "자세히ToolStripMenuItem";
            this.자세히ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.자세히ToolStripMenuItem.Text = "자세히";
            this.자세히ToolStripMenuItem.Click += new System.EventHandler(this.mnuView_Click);
            // 
            // 간단히ToolStripMenuItem
            // 
            this.간단히ToolStripMenuItem.Name = "간단히ToolStripMenuItem";
            this.간단히ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.간단히ToolStripMenuItem.Text = "간단히";
            this.간단히ToolStripMenuItem.Click += new System.EventHandler(this.mnuView_Click);
            // 
            // 작은아이콘ToolStripMenuItem
            // 
            this.작은아이콘ToolStripMenuItem.Name = "작은아이콘ToolStripMenuItem";
            this.작은아이콘ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.작은아이콘ToolStripMenuItem.Text = "작은아이콘";
            this.작은아이콘ToolStripMenuItem.Click += new System.EventHandler(this.mnuView_Click);
            // 
            // 큰아이콘ToolStripMenuItem
            // 
            this.큰아이콘ToolStripMenuItem.Name = "큰아이콘ToolStripMenuItem";
            this.큰아이콘ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.큰아이콘ToolStripMenuItem.Text = "큰아이콘";
            this.큰아이콘ToolStripMenuItem.Click += new System.EventHandler(this.mnuView_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "avi.png");
            this.imageList1.Images.SetKeyName(1, "folder.png");
            this.imageList1.Images.SetKeyName(2, "image.png");
            this.imageList1.Images.SetKeyName(3, "music.png");
            this.imageList1.Images.SetKeyName(4, "temp.png");
            this.imageList1.Images.SetKeyName(5, "text.png");
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 126);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 551);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitter2);
            this.panel2.Controls.Add(this.listView);
            this.panel2.Controls.Add(this.treeView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 126);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(783, 551);
            this.panel2.TabIndex = 6;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(121, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 551);
            this.splitter2.TabIndex = 2;
            this.splitter2.TabStop = false;
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView.ContextMenuStrip = this.contextMenuStrip1;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.LargeImageList = this.imageList1;
            this.listView.Location = new System.Drawing.Point(121, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(662, 551);
            this.listView.SmallImageList = this.imageList1;
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "파일이름";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "파일크기";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "수정한날짜";
            this.columnHeader3.Width = 200;
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView.ImageKey = "folder.png";
            this.treeView.ImageList = this.imageList1;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 1;
            this.treeView.Size = new System.Drawing.Size(121, 551);
            this.treeView.TabIndex = 0;
            this.treeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_BeforeExpand);
            this.treeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_BeforeSelect);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 677);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "File Manager - Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnopf;
        private System.Windows.Forms.Button btnpath;
        private System.Windows.Forms.Button btnconnect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox porttxt;
        private System.Windows.Forms.TextBox pathtxt;
        private System.Windows.Forms.TextBox iptxt;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 상세정보ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 다운로드ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 자세히ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 간단히ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 작은아이콘ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 큰아이콘ToolStripMenuItem;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

