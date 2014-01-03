using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TimeZero.Auction.Bot.Controls.Header
{
    public sealed partial class Header : UserControl
    {

#region Private members

        private string _text = "Caption";
        private Color _topGradientColor = Color.AntiqueWhite;
        private byte _topGradientTransparency = 255;
        private Color _bottomGradientColor = Color.GhostWhite;
        private byte _bottomGradientTransparency = 255;

#endregion

#region Properties

        #region Hidden

        [DefaultValue(null), Browsable(false)]
        public new string Text { get; set; }

        [Browsable(false)]
        public new Color BackColor { get; set; }

        [Browsable(false)]
        public new bool TabStop { get; set; }

        [Browsable(false)]
        public new int TabIndex { get; set; }

        [Browsable(false)]
        public new Padding Padding
        {
            get { return base.Padding; }
            set
            {
                base.Padding = value;
            }
        }

        [Browsable(false)]
        public new BorderStyle BorderStyle { get; set; }

        [Browsable(false)]
        public new Image BackgroundImage { get; set; }

        [Browsable(false)]
        public new ImageLayout BackgroundImageLayout { get; set; }

        [Browsable(false)]
        public new AutoSizeMode AutoSizeMode { get; set; }

        [Browsable(false)]
        public new bool AutoSize { get; set; }

        [Browsable(false)]
        public new AutoValidate AutoValidate { get; set; }

        [Browsable(false)]
        public new bool AutoScroll { get; set; }

        [Browsable(false)]
        public new Size AutoScrollMinSize { get; set; }

        [Browsable(false)]
        public new Size AutoScrollMargin { get; set; }

#endregion

        [DefaultValue(null), Browsable(true)]
        public string Caption
        {
            get { return _text; }
            set
            {
                lblHeader.Text = _text = value;
            }
        }

        [DefaultValue(null), Browsable(true)]
        public Color TopGradientColor
        {
            get { return _topGradientColor; }
            set
            {
                _topGradientColor = value;
                Invalidate();
            }
        }

        [DefaultValue((byte)255), Browsable(true)]
        public byte TopGradientTransparency
        {
            get { return _topGradientTransparency; }
            set
            {
                _topGradientTransparency = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        public Color BottomGradientColor
        {
            get { return _bottomGradientColor; }
            set
            {
                _bottomGradientColor = value;
                Invalidate();
            }
        }

        [DefaultValue((byte)255), Browsable(true)]
        public byte BottomGradientTransparency
        {
            get { return _bottomGradientTransparency; }
            set
            {
                _bottomGradientTransparency = value;
                Invalidate();
            }
        }

#endregion

#region Class members

        public Header()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            base.TabStop = false;
        }

        private void HeaderPaint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(ClientRectangle.Location, ClientRectangle.Size);
            Brush brush = new LinearGradientBrush(ClientRectangle,
                Color.FromArgb(_topGradientTransparency, _topGradientColor),
                Color.FromArgb(_bottomGradientTransparency, _bottomGradientColor), 
                90, false);
            e.Graphics.FillRectangle(brush, rect);
            e.Graphics.DrawLine(new Pen(Color.DimGray), new Point(0, Height - 1),
                                new Point(Width, Height - 1));
        }

        private void LblHeaderTextChanged(object sender, System.EventArgs e)
        {
            lblHeader.Text = _text;
        }

#endregion

#region ShouldSerialize

        private bool ShouldSerializeCaption()
        {
            return false;
        }

        private bool ShouldSerializeTopGradientColor()
        {
            return false;
        }

        private bool ShouldSerializeBottomGradientColor()
        {
            return false;
        }

#endregion

    }
}
