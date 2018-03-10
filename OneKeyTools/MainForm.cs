using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneKeyTools
{
    public partial class MainForm : Form
    {
        bool _enterKeyDown = false;
        bool EnterKeyDown
        {
            get => _enterKeyDown;
            set => _enterKeyDown = value;
        }

        new Image BackgroundImage
        {
            get => base.BackgroundImage;
            set
            {
                base.BackgroundImage?.Dispose();
                base.BackgroundImage = null;
                base.BackgroundImage = value;
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (EnterKeyDown) return;
                EnterKeyDown = true;
                this.BackgroundImage = UnityResource._3;
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EnterKeyDown = false;
                this.BackgroundImage = UnityResource._1;
            }
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            //PopText(DateTime.Now.ToString());
            PopText("嘻嘻嘻~小可爱~么么哒~~~");
        }

        private void PopText(string Message)
        {
            Form PopForm = new Form()
            {
                AutoSize = true,
                FormBorderStyle = FormBorderStyle.None,
                TransparencyKey = BackColor,
                ShowInTaskbar = false,
                ShowIcon=false,
            };
            PopForm.Controls.Add(new Label()
            {
                ForeColor = Color.HotPink,
                AutoEllipsis = false,
                AutoSize = true,
                Text = Message,
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
                Font = new Font("微软雅黑",30)
            });
            PopForm.Shown += delegate {
                ThreadPool.QueueUserWorkItem(new WaitCallback(delegate {
                    try
                    {
                        while (PopForm.Left > -PopForm.Width)
                        {
                            if (!this?.Visible ?? true) break;
                            PopForm?.Invoke(new Action(delegate
                            {
                                PopForm.Left -= 2;
                            }));
                            Thread.Sleep(10);
                        }
                        PopForm?.Invoke(new Action(delegate {
                            PopForm.Close();
                        }));
                    }
                    catch { }
                }));
            };
            PopForm.Show(this);
            PopForm.SetBounds(Screen.PrimaryScreen.Bounds.Width, new Random().Next(Screen.PrimaryScreen.Bounds.Height),PopForm.Width,PopForm.Controls[0].Height);
            this.Activate();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form OnwedForm in this.OwnedForms)
            {
                OnwedForm?.Close();
            }
        }
    }
}
