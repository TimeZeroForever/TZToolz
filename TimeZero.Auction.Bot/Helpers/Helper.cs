using System;
using System.IO;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
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

#region Static private fields

        private static byte[] _salt = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        private static byte[] _uniqueHardwareID = GetUniqueHardwareID();

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

        private static string GetHardwareIdentifier(string wmiClass, string wmiProperty)
        {
            ManagementObjectCollection moc = new ManagementClass(wmiClass).GetInstances();
            foreach (ManagementObject mo in moc)
            {
                try
                {
                    return mo[wmiProperty].ToString();
                }
                catch {}
            }
            return string.Empty;
        }

        public static byte[] GetUniqueHardwareID()
        {
            string cpuID = GetHardwareIdentifier("Win32_Processor", "ProcessorID");
            string mbSerial = GetHardwareIdentifier("Win32_BaseBoard", "SerialNumber");
            string biosSerial = GetHardwareIdentifier("Win32_BIOS", "SerialNumber");
            string result = string.Format("{0}|{1}|{2}", cpuID, mbSerial, biosSerial);
            byte[] bResult = new ASCIIEncoding().GetBytes(result);
            return new MD5CryptoServiceProvider().ComputeHash(bResult);
        }

        public static string EncryptStringByHardwareID(string data)
        {
            return EncryptString(data, _uniqueHardwareID);
        }

        public static string EncryptString(string data, byte[] key)
        {
            RijndaelManaged aesAlg = new RijndaelManaged();
            try
            {
                Rfc2898DeriveBytes pwddb = new Rfc2898DeriveBytes(key, _salt, 1);
                aesAlg.Key = pwddb.GetBytes(aesAlg.KeySize / 8);
                ICryptoTransform enc = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(BitConverter.GetBytes(aesAlg.IV.Length), 0, sizeof(int));
                    ms.Write(aesAlg.IV, 0, aesAlg.IV.Length);
                    using (CryptoStream cs = new CryptoStream(ms, enc, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(data);
                        }
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
            catch
            {
                return string.Empty;
            }
            finally
            {
                aesAlg.Clear();
            }
        }

        public static string DecryptStringByHardwareID(string data)
        {
            return DecryptString(data, _uniqueHardwareID);
        }

        public static string DecryptString(string data, byte[] key)
        {
            RijndaelManaged aesAlg = new RijndaelManaged();
            try
            {
                byte[] bytes = Convert.FromBase64String(data);
                Rfc2898DeriveBytes pwddb = new Rfc2898DeriveBytes(key, _salt, 1);
                aesAlg.Key = pwddb.GetBytes(aesAlg.KeySize / 8);
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    aesAlg.IV = ReadByteArray(ms);
                    ICryptoTransform dec = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                    using (CryptoStream cs = new CryptoStream(ms, dec, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
            catch
            {
                return string.Empty;
            }
            finally
            {
                aesAlg.Clear();
            }
        }

        private static byte[] ReadByteArray(Stream s)
        {
            byte[] rawLength = new byte[sizeof(int)];
            s.Read(rawLength, 0, rawLength.Length);
            byte[] buffer = new byte[BitConverter.ToInt32(rawLength, 0)];
            s.Read(buffer, 0, buffer.Length);
            return buffer;
        }

#endregion

    }
}
