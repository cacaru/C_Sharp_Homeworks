using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using ClassLibrary1;
using System.Net.Sockets;
using System.Net;

namespace Client {
    public partial class Form1 : Form {
        const int SIZE = 1024 * 16;
        private int SENDSIZE = 0;
        private int port = 0;
        private IPAddress ip;
        private Packet packet = new Packet();

        private NetworkStream mynetworkstream;
        private TcpClient tcpclient;
        private byte[] sendbf = new byte[SIZE];
        private byte[] readbf = new byte[SIZE];
        
        private bool connect = false;

        
        public Form1() {
            InitializeComponent();
        }

        public void setPlus(TreeNode node) {
             
            packet.nextpath = node.FullPath.Substring(0,node.FullPath.Length - node.Text.Length);
            //pathtxt.Text = node.FullPath.Substring(0, node.FullPath.Length - node.Text.Length);
            packet.Type = 3;
            sendbf = Packet.Serialize(packet); SENDSIZE = sendbf.Length;
            Send();

            this.mynetworkstream.Read(readbf, 0, SIZE);
            packet = (Packet)Packet.Desserialize(readbf);
            
            try {
                if (packet.di.Length > 0)
                    node.Nodes.Add("");
                node.ImageIndex = 1;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        public void OpenFile() {
            ListView.SelectedListViewItemCollection silist;
            silist = listView.SelectedItems;

            foreach (ListViewItem item in silist) {
                OpenItem(item);
            }
        }

        public void OpenItem(ListViewItem item) {
            TreeNode node;
            TreeNode child;

            if (item.Tag.ToString() == "D") {
                node = treeView.SelectedNode;
                node.Expand();

                child = node.FirstNode;
                while (child != null) {
                    if (child.Text == item.Text) {
                        treeView.SelectedNode = child;
                        treeView.Focus();
                        break;
                    }
                    child = child.NextNode;
                }
            }
        }

        public void Send() {
            this.mynetworkstream.Write(this.sendbf, 0, this.sendbf.Length);
            this.mynetworkstream.Flush();

            for (int i = 0; i < SENDSIZE; i++)
                this.sendbf[i] = 0;
        }

        private void treeView_BeforeExpand(object sender, TreeViewCancelEventArgs e) {
            TreeNode node;

            packet.Type = 0; packet.nextpath = e.Node.FullPath;
            
            sendbf = Packet.Serialize(packet); SENDSIZE = sendbf.Length;
            Send();
            
            this.mynetworkstream.Read(readbf, 0, SIZE);
            packet = (Packet)Packet.Desserialize(readbf);

            e.Node.Nodes.Clear();
            
            try {
                foreach (DirectoryInfo dirs in packet.di) {
                    node = e.Node.Nodes.Add(dirs.Name);
                    
                    setPlus(node);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void treeView_BeforeSelect(object sender, TreeViewCancelEventArgs e) {
            e.Node.ImageIndex = 1;
            packet.Type = 1; packet.nextpath = e.Node.FullPath;
            sendbf = Packet.Serialize(packet); SENDSIZE = sendbf.Length;
            Send();
            
            this.mynetworkstream.Read(readbf, 0, SIZE);
            packet = (Packet)Packet.Desserialize(readbf);

            ListViewItem item;
            listView.Items.Clear();
            try {
                foreach (DirectoryInfo tdis in packet.di) {
                    item = listView.Items.Add(tdis.Name);
                    item.SubItems.Add("");
                    item.SubItems.Add(tdis.LastWriteTime.ToString());
                    item.ImageIndex = 1;
                    item.Tag = "D";
                }

               
                foreach (FileInfo fis in packet.sfa) {
                    item = listView.Items.Add(fis.Name);
                    item.SubItems.Add(fis.Length.ToString());
                    item.SubItems.Add(fis.LastWriteTime.ToString());
                    
                    switch (fis.Extension) {
                        case ".txt":
                            item.ImageIndex = 5;
                            item.Tag = "T";
                            break;
                        case ".png":
                            item.ImageIndex = 2;
                            item.Tag = "I";
                            break;
                        case ".mp3":
                            item.ImageIndex = 3;
                            item.Tag = "M";
                            break;
                        case ".avi":
                            item.ImageIndex = 0;
                            item.Tag = "V";
                            break;
                        default:
                            item.ImageIndex = 4;
                            item.Tag = "O";
                            break;
                    }
                    
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void listView_DoubleClick(object sender, EventArgs e) {

            ListView.SelectedListViewItemCollection selectitem = listView.SelectedItems;

            foreach (ListViewItem item in selectitem) {
                if (item.Tag.ToString() == "D") {
                    OpenFile();
                    return;
                }

            }
            setShareinfo();
            Form2 form2 = new Form2(packet);
            form2.Owner = this;
            form2.Show();

        }

        private void Btnconnect_Click(object sender, EventArgs e) {
            if( btnconnect.Text == "서버연결") {
                this.tcpclient = new TcpClient();
                
                if (pathtxt.Text == "") {
                    MessageBox.Show("경로를 지정해주세요.");
                    return;
                }
                else if( porttxt.Text == "") {
                    MessageBox.Show("포트번호를 지정해주세요.");
                    return;
                }
                else if (iptxt.Text == "") {
                    MessageBox.Show("ip를 지정해주세요.");
                    return;
                }

                try {
                    ip = IPAddress.Parse(iptxt.Text);
                    port = Convert.ToInt32(porttxt.Text);
                    this.tcpclient.Connect(ip, port);
                }
                catch {
                    MessageBox.Show("연결 에러");
                    return;
                }
               
                this.connect = true;
                this.mynetworkstream = this.tcpclient.GetStream();
                btnconnect.Text = "서버끊기";
                btnconnect.ForeColor = Color.Red;

                this.mynetworkstream.Read(readbf, 0, SIZE);
                packet = (Packet)Packet.Desserialize(readbf);
 
                FirstRun();
            }
            else {
                packet.Type = 2;
                sendbf = Packet.Serialize(packet); SENDSIZE = sendbf.Length;
                Send();
                this.tcpclient.Close();
                this.mynetworkstream.Close();
                btnconnect.Text = "서버연결";
                btnconnect.ForeColor = Color.Black;
                connect = false;
            }
        }

        private void FirstRun()
        {
            //before expand
            TreeNode root;
            root = treeView.Nodes.Add(packet.dir.FullName);
            root.ImageIndex = 1;

            if (treeView.SelectedNode == null)
                treeView.SelectedNode = root;
            
            root.SelectedImageIndex = root.ImageIndex;
            root.Nodes.Add("");
        }
        
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            if (connect) {
                packet.Type = 2;
                sendbf = Packet.Serialize(packet); SENDSIZE = sendbf.Length;
                Send();
                connect = false;
            }
            if (this.tcpclient != null) {
                
                this.tcpclient.Close();
            }
            if (this.mynetworkstream != null) {
                this.mynetworkstream.Close();
                
            }
        }


        private void mnuView_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            자세히ToolStripMenuItem.Checked = false;
            간단히ToolStripMenuItem.Checked = false;
            작은아이콘ToolStripMenuItem.Checked = false;
            큰아이콘ToolStripMenuItem.Checked = false;

            switch (item.Text) {
                case "자세히":
                    자세히ToolStripMenuItem.Checked = true;
                    listView.View = View.Details;
                    break;
                case "간단히":
                    간단히ToolStripMenuItem.Checked = true;
                    listView.View = View.List;
                    break;
                case "작은아이콘":
                    작은아이콘ToolStripMenuItem.Checked = true;
                    listView.View = View.SmallIcon;
                    break;
                case "큰아이콘":
                    큰아이콘ToolStripMenuItem.Checked = true;
                    listView.View = View.LargeIcon;
                    break;
            }

        }

        private void Pathbtn_Click(object sender, EventArgs e) {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
                pathtxt.Text = folderBrowserDialog.SelectedPath;
            }
        }

        public void setShareinfo() {
            ListView.SelectedListViewItemCollection selectitem = listView.SelectedItems;

            foreach (ListViewItem item in selectitem) {
                packet.name = item.Text;
            }
            packet.Type = 4; packet.savepath = pathtxt.Text.ToString();
            sendbf = Packet.Serialize(packet); SENDSIZE = sendbf.Length;
            Send();

            this.mynetworkstream.Read(readbf, 0, SIZE);
            packet = (Packet)Packet.Desserialize(readbf);
        }

        private void 상세정보ToolStripMenuItem_Click(object sender, EventArgs e) {
            ListView.SelectedListViewItemCollection selectitem = listView.SelectedItems;

            foreach (ListViewItem item in selectitem) {
                if( item.Tag == "D") {
                    MessageBox.Show("폴더는 상세정보를 지원하지 않습니다.");
                    return;
                }
                packet.name = item.Text;
            }
            
            setShareinfo();
            
            Form2 form2 = new Form2(packet);
            form2.Owner = this;
            form2.Show();
        }

        private void 다운로드ToolStripMenuItem_Click(object sender, EventArgs e) {
            ListView.SelectedListViewItemCollection selectitem = listView.SelectedItems;

            foreach (ListViewItem item in selectitem) {
                if (item.Tag == "D") {
                    MessageBox.Show("폴더는 다운로드를 지원하지 않습니다.");
                    return;
                }
                packet.name = item.Text;
            }
            packet.Type = 5; packet.savepath = pathtxt.Text.ToString();
            sendbf = Packet.Serialize(packet); SENDSIZE = sendbf.Length;
            Send();

        }
    }
}
