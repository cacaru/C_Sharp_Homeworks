using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Net;
namespace HW2
{
    public partial class Form1 : Form
    {
        const int SIZE = 1024 * 16;
        private int SENDSIZE = 0;
        delegate void ChangeButton();

        private Packet packet = new Packet();
        private Packet defaultpacket = new Packet();

        private NetworkStream mynetworkstream;
        private TcpListener tcpListener;
        private byte[] sendbf = new byte[SIZE];
        private byte[] readbf = new byte[SIZE];

        private bool clienton = false;
        private Thread thread;

        private string pathText;
        private int port = 0;
        private IPAddress ip;
        public void Run() {
            
            int nread = 0;
            if (pathtxt.Text == "") {
                MessageBox.Show("경로를 입력해주세요");
                if (this.InvokeRequired) {
                    ChangeButton cb = new ChangeButton(setSbtn);
                    this.Invoke(cb, new object[] { });
                }
                else {
                    setSbtn();
                }
                return;
            }
            else { 
                packet.dir = new DirectoryInfo(pathText);
                packet.di = packet.dir.GetDirectories();
                packet.sfa = packet.dir.GetFiles();
                packet.nextpath = pathText;
            }
            try {
                ip = IPAddress.Parse(iptxt.Text);
                port = Convert.ToInt32(porttxt.Text);
                this.tcpListener = new TcpListener(ip, port);
                this.tcpListener.Start();
            }
            catch {
                MessageBox.Show("연결 에러");
                if (this.InvokeRequired) {
                    ChangeButton cb = new ChangeButton(setSbtn);
                    this.Invoke(cb, new object[] { });
                }
                else {
                    setSbtn();
                }
                return;
            }

            if (!this.clienton) {
                this.Invoke(new MethodInvoker(delegate () {
                    log.AppendText("클라이언트 접속 대기중...\r\n");
                    log.AppendText("ip :" + iptxt.Text + "  PORT : " + port + "\r\n");    
                }));
            }

            TcpClient client = this.tcpListener.AcceptTcpClient();

            if (client.Connected) {
                this.clienton = true;
                this.Invoke(new MethodInvoker(delegate () {
                    log.AppendText("클라이언트 접속!\r\n");
                }));
                mynetworkstream = client.GetStream();
            }

            InitialConnect();

            while (clienton)
            {
                try
                {
                    nread = 0;
                    packet = defaultpacket;
                    nread = mynetworkstream.Read(readbf, 0, SIZE);
                }
                catch
                {
                    clienton = false;
                    mynetworkstream = null;
                }

                packet = (Packet)Packet.Desserialize(readbf);
   
                switch ((int)packet.Type) {

                    case (int)PacketType.Expand:
                        this.Invoke(new MethodInvoker(delegate () {
                            this.log.AppendText(" >> Client로부터 Expand요청\r\n");
                        }));
                        if (packet.nextpath != "") {
                            packet.dir = new DirectoryInfo(packet.nextpath);
                            packet.di = packet.dir.GetDirectories();
                            packet.sfa = packet.dir.GetFiles();
                        }
                        else {
                            packet.dir = new DirectoryInfo(pathText);
                            packet.di = packet.dir.GetDirectories();
                            packet.sfa = packet.dir.GetFiles();
                        }
                        sendbf = Packet.Serialize(packet);
                        SENDSIZE = sendbf.Length;
                        Send();
                        break;

                    case (int)PacketType.Select:
                        this.Invoke(new MethodInvoker(delegate () {
                            this.log.AppendText(" >> Client로부터 Select요청\r\n");
                        }));
                        packet.dir = new DirectoryInfo(packet.nextpath);
                        packet.di = packet.dir.GetDirectories();
                        packet.sfa = packet.dir.GetFiles();
                        sendbf = Packet.Serialize(packet);
                        SENDSIZE = sendbf.Length;
                        Send();
                        break;

                    case (int)PacketType.setPlus:
                        if (packet.nextpath != "") {
                            packet.dir = new DirectoryInfo(packet.nextpath);
                            packet.di = packet.dir.GetDirectories();
                            packet.sfa = packet.dir.GetFiles();
                        }
                        else {
                            packet.dir = new DirectoryInfo(pathText);
                            packet.di = packet.dir.GetDirectories();
                            packet.sfa = packet.dir.GetFiles();
                        }
                        sendbf = Packet.Serialize(packet);
                        SENDSIZE = sendbf.Length;
                        Send();
                        break;

                    case (int)PacketType.setInfo:
                        this.Invoke(new MethodInvoker(delegate () {
                            this.log.AppendText(" >> Client로부터 상세정보 요청\r\n");
                        }));
                        foreach (FileInfo item in packet.sfa) {
                            if (item.Name == packet.name) {
                                packet.size = (int)item.Length;
                                packet.createDay = item.CreationTime;
                                packet.accessDay = item.LastAccessTime;
                                packet.modifyDay = item.LastWriteTime;
                                packet.fileType = item.Extension;
                                packet.locate = item.FullName;
                                break;
                            }
                        }
                        sendbf = Packet.Serialize(packet); SENDSIZE = sendbf.Length;
                        Send();
                        break;

                    case (int)PacketType.filesend:
                        string filefullname = System.IO.Path.Combine(packet.nextpath, packet.name);
                        string copyfullname = System.IO.Path.Combine(packet.savepath, packet.name);
                        this.Invoke(new MethodInvoker(delegate () {
                            this.log.AppendText(" >> Client로부터 파일 다운로드 요청\r\n");
                            this.log.AppendText(" 다운로드 경로 : " + packet.savepath + "\r\n" + "해당 파일 경로 : " + filefullname + "\r\n");
                        }));
                        try {
                            System.IO.File.Copy(filefullname, copyfullname);
                        }
                        catch {
                            this.Invoke(new MethodInvoker(delegate () {
                                this.log.AppendText("파일 다운로드 에러\r\n");
                            }));
                        }
                        this.Invoke(new MethodInvoker(delegate () {
                            this.log.AppendText(" 경로로 다운로드 완료!\r\n");
                        }));
                        break;
                    case (int)PacketType.ConnectEnd:
                        clienton = false;
                        break;
                }

                
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        public void InitialConnect() {
            sendbf = Packet.Serialize(packet); SENDSIZE = sendbf.Length;
            Send();

            this.Invoke(new MethodInvoker(delegate () {
                log.AppendText("설정된 경로의 DirectoryInfo, DirectoryInfo[], FileInfo[] 전송\r\n");
            }));
        }

        private void Sbtn_Click(object sender, EventArgs e) {
            if( sbtn.Text == "서버켜기") {
                this.thread = new Thread(new ThreadStart(Run));
                this.thread.Start();
                sbtn.Text = "서버끊기";
                sbtn.ForeColor = Color.Red;
            }
            else {
                this.tcpListener.Stop();
                this.mynetworkstream.Close();
                this.thread.Abort();
                setSbtn();
                this.log.AppendText("서버 종료 \r\n");
            }
        }

        public void setSbtn() {
            sbtn.Text = "서버켜기";
            sbtn.ForeColor = Color.Black;
        }

        public void Send()
        {
            this.mynetworkstream.Write(this.sendbf, 0, this.sendbf.Length);
            this.mynetworkstream.Flush();

            for (int i = 0; i < SENDSIZE; i++)
                this.sendbf[i] = 0;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            if( this.tcpListener != null)
                this.tcpListener.Stop();
            if(this.mynetworkstream != null)
                this.mynetworkstream.Close();
            if(this.thread != null)
                this.thread.Abort();
        }

        private void Pathbtn_Click(object sender, EventArgs e) {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
                pathtxt.Text = folderBrowserDialog.SelectedPath;
                pathText = pathtxt.Text;
                log.AppendText(pathText + " 로 경로가 설정되었습니다\r\n");
                packet.dir = new DirectoryInfo(pathText);
                packet.di = packet.dir.GetDirectories();
                packet.sfa = packet.dir.GetFiles();
                packet.nextpath = pathText;
            }
            
        }
    }
}
