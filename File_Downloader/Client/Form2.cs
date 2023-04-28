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

namespace Client
{
    public partial class Form2 : Form
    {
        public Form2(Packet sval)
        {
            InitializeComponent();
            
            this.filename.Text = sval.name;
            this.label7.Text = sval.fileType;
            this.label8.Text = sval.locate;
            this.label9.Text = sval.size.ToString();
            this.label10.Text = sval.createDay.ToString();
            this.label11.Text = sval.modifyDay.ToString();
            this.label12.Text = sval.accessDay.ToString();
            switch (sval.fileType) {
                case ".txt":
                    pictureBox.Image = Properties.Resources.text;
                    break;
                case ".png":
                    pictureBox.Image = Properties.Resources.image;
                    break;
                case ".avi":
                    pictureBox.Image = Properties.Resources.avi;
                    break;
                case ".mp3":
                    pictureBox.Image = Properties.Resources.music;
                    break;
                default:
                    pictureBox.Image = Properties.Resources.temp;
                    break;
            }
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void Okbtn_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
