using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeZero.Auction.Bot.Forms
{
    public partial class frmLoading : PerPixelAlphaForm
    {
        public frmLoading()
        {
            InitializeComponent();
            Bitmap logo = new Bitmap(Properties.Resources.logo);
            SetBitmap(logo);
        }

        public new frmLoading Show()
        {
            Location = new Point((Screen.PrimaryScreen.Bounds.Width - Width) / 2,
                                 (Screen.PrimaryScreen.Bounds.Height - Height) / 2);
            base.Show();
            Application.DoEvents();
            return this;
        }
    }
}
