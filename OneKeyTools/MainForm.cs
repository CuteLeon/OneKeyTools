using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            //this.Opacity = 0.5;
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

        }
    }
}
