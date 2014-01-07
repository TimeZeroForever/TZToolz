using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TimeZero.Auction.Bot.Helpers
{
    public static class Helper
    {

#region P/Invoke

        [DllImport("User32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam,
                                                IntPtr lParam);

#endregion

#region Static methods

        public static string GetLocalIP()
        {
            IPAddress[] localIPs = Dns.GetHostAddresses(Environment.MachineName);
            foreach (IPAddress addr in localIPs)
            {
                if (addr.AddressFamily == AddressFamily.InterNetwork)
                {
                    return addr.ToString();
                }
            }
            return "192.168.1.1";
        }

        public static string BytesToString(long byteCount)
        {
            string[] suf = { " bytes", " KB", " MB", " GB" };
            if (byteCount == 0)
            {
                return "0" + suf[0];
            }
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num) + suf[place];
        }

        public static void LockUpdate(Control parentCtrl)
        {
            SendMessage(parentCtrl.Handle, 0x000B, (IntPtr)0, (IntPtr)0);
        }

        public static void UnlockUpdate(Control parentCtrl)
        {
            SendMessage(parentCtrl.Handle, 0x000B, (IntPtr)1, (IntPtr)0);
            parentCtrl.Invalidate(true);
        }

        public static void RepaintTreeNode(TreeNode treeNode)
        {
            if (treeNode != null)
            {
                treeNode.TreeView.Invalidate(treeNode.Bounds);
            }
        }

#endregion

    }
}
