using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System;

namespace TimeZero.Auction.Bot.Controls.SettingsListView
{
    public class SettingsListView : ListView
    {
        private ListViewItem _itemAtCursor;

        public SettingsListView()
        {
            MouseMove += LvGroupsMouseMove;
            MouseLeave += LvGroupsMouseLeave;
            DrawItem += LvGroupsDrawItem;
            OwnerDraw = true;
            MultiSelect = false;
            FullRowSelect = true;
            HeaderStyle = ColumnHeaderStyle.None;
            Scrollable = false;
            View = View.Details;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg >= 0x201 && m.Msg <= 0x209)
            {
                Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                ListViewItem item = GetItemAt(pos.X, pos.Y);
                if (item == null || item.Text == "-")
                {
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void LvGroupsMouseMove(object sender, MouseEventArgs e)
        {
            ListViewItem lvi = GetItemAt(e.X, e.Y);
            if (_itemAtCursor != lvi)
            {
                bool isSeparator = lvi != null && lvi.Text == "-";
                Cursor = lvi != null && !isSeparator
                    ? Cursors.Hand
                    : Cursors.Default;
                if (_itemAtCursor != null && !_itemAtCursor.Selected)
                {
                    RedrawItems(_itemAtCursor.Index, _itemAtCursor.Index, true);
                }
                _itemAtCursor = !isSeparator ? lvi : null;
                if (_itemAtCursor != null && !_itemAtCursor.Selected)
                {
                    RedrawItems(_itemAtCursor.Index, _itemAtCursor.Index, true);
                }
            }
        }

        private void LvGroupsMouseLeave(object sender, EventArgs e)
        {
            if (_itemAtCursor != null)
            {
                int idx = _itemAtCursor.Index;
                _itemAtCursor = null;
                if (SelectedIndices.Count > 0 && SelectedIndices[0] != idx)
                {
                    RedrawItems(idx, idx, true);
                }
            }
        }

        private void LvGroupsDrawItem(object sender, DrawListViewItemEventArgs e)
        {
            bool isSeparator = e.Item.Text == "-";

            Brush brush;
            if (e.Item == _itemAtCursor && !e.Item.Selected)
            {
                brush = Brushes.Gainsboro;
            }
            else
            {
                brush = !e.Item.Selected || isSeparator
                            ? Brushes.White
                            : Brushes.Silver;
            }
            e.Graphics.FillRectangle(brush, e.Bounds);

            if (!isSeparator)
            {
                Rectangle rect = new Rectangle(e.Item.Bounds.X + 32, e.Item.Bounds.Y + 7,
                                               e.Item.Bounds.Width - 32, e.Item.Bounds.Height - 7);
                Font font = new Font(Font, e.Item.Selected ? FontStyle.Bold : FontStyle.Regular);
                e.Graphics.DrawString(e.Item.Text, font, Brushes.Black, rect);
                e.Graphics.DrawImage(SmallImageList.Images[e.Item.ImageIndex],
                                     e.Item.Bounds.Location);
            }
            else
            {
                const int margin = 6;
                const float lineHeight = 1f;
                Color penColor = Color.Gray;
                Pen pen = new Pen(penColor, lineHeight);
                pen.StartCap = pen.EndCap = LineCap.Flat;
                //e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

                Point ptStart = new Point(
                    e.Item.Bounds.X + margin,
                    (int)(e.Item.Bounds.Top + e.Item.Bounds.Height / 2 - lineHeight / 2) + 1);
                Point ptEnd = new Point(
                    ptStart.X + (ClientRectangle.Width - margin * 2), ptStart.Y);
                e.Graphics.DrawLine(pen, ptStart, ptEnd);
            }
        }
    }
}
