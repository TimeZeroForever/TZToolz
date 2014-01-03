using System.Drawing;
using System.Windows.Forms;

namespace TimeZero.Auction.Bot.Controls.TransparentPanel
{
    public sealed partial class TransparentPanel : Panel
    {
        public TransparentPanel()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Opaque, true);
            BackColor = Color.Transparent;
            InitializeComponent();
            SetStyle(ControlStyles.Selectable, false);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;
                return cp;
            }
        }
    }
}