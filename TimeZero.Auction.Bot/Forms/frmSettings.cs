using System;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using TimeZero.Auction.Bot.Classes.Common;
using TimeZero.Auction.Bot.Helpers;

namespace TimeZero.Auction.Bot.Forms
{
    public partial class frmSettings : Form
    {

#region Static private fields

        private static readonly Regex _regexIpCheck = new Regex(@"^(\d{1,3}\.){3}\d{1,3}$");

#endregion

#region Private fields

        private string _oldGameServer;
        private string _oldGamePort;
        private string _oldGameFolder;
        private string _oldClientVer1;
        private string _oldClientVer2;
        private string _oldLogin;
        private string _oldPassword;

#endregion

#region Properties

        public bool IsGameFolderChanged { get; private set; }
        public bool IsGameSettingsChanged { get; private set; }

#endregion

#region Class methods

        public frmSettings()
        {
            InitializeComponent();
            tbSettings.Top -= 22;
            tbSettings.Height += 22;
            lvSettings.Items[0].Selected = true;
        }

        private void PopulateSettings()
        {
            //General settings
            tbGameServer.Text = AppSettings.Instance["Server"];
            tbGamePort.Text = AppSettings.Instance["Port"];
            tbGameFolder.Text = AppSettings.Instance["GameFolder"];
            tbClientVer1.Text = AppSettings.Instance["ClientVersion"];
            tbClientVer2.Text = AppSettings.Instance["ClientVersion2"];
            tbLogin.Text = AppSettings.Instance["Login"];

            string password = AppSettings.Instance["Password"];
            tbPassword.Text = Helper.DecryptStringByHardwareID(password);

            //Main windows settings

            //Init local variables
            _oldGameServer = tbGameServer.Text;
            _oldGamePort = tbGamePort.Text;
            _oldGameFolder = tbGameFolder.Text;
            _oldClientVer1 = tbClientVer1.Text;
            _oldClientVer2 = tbClientVer2.Text;
            _oldLogin = tbLogin.Text;
            _oldPassword = tbPassword.Text;
        }

        public bool Execute(bool firstRun)
        {
            PopulateSettings();
            if (firstRun)
            {
                BtnBrowseGameFolderClick(null, null);
            }
            return ShowDialog() == DialogResult.OK;
        }

        private int GetTabIndex(int itemIndex)
        {
            int tabIdx = itemIndex;
            for (int i = tabIdx - 1; i >= 0; i--)
            {
                ListViewItem item = lvSettings.Items[i];
                if (item.Text == "-")
                {
                    tabIdx--;
                }
            }
            return tabIdx;
        }

        private void LvSettingsSelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSettings.SelectedIndices.Count > 0 && lvSettings.SelectedIndices[0] != -1)
            {
                tbSettings.SelectedIndex = GetTabIndex(lvSettings.SelectedIndices[0]);
                tbSettings.SelectedTab.Focus();
            }
        }

        private void BtnBrowseGameFolderClick(object sender, EventArgs e)
        {
            if (fbdGameFolder.ShowDialog() == DialogResult.OK)
            {
                tbGameFolder.Text = fbdGameFolder.SelectedPath;
            }
        }

        private bool SaveAppSettings()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                //Check game server
                string gameServer = tbGameServer.Text.Trim();
                if (string.IsNullOrEmpty(gameServer))
                {
                    tbGameServer.Focus();
                    throw new Exception("Game server is not defined");
                }
                if (!_regexIpCheck.IsMatch(gameServer))
                {
                    tbGameServer.Focus();
                    throw new Exception("Game server IP address is not valid");
                }

                //Parse game port value
                int gamePort;
                if (!int.TryParse(tbGamePort.Text.Trim(), out gamePort) ||
                    gamePort <= 1024 || gamePort > 65535)
                {
                    tbGamePort.Focus();
                    throw new Exception("Invalid game port");
                }

                //Check client version 1
                string clientVer1 = tbClientVer1.Text.Trim();
                if (string.IsNullOrEmpty(clientVer1))
                {
                    tbClientVer1.Focus();
                    throw new Exception("Client version 1 is not defined");
                }

                //Check client version 2
                string clientVer2 = tbClientVer2.Text.Trim();
                if (string.IsNullOrEmpty(clientVer2))
                {
                    tbClientVer2.Focus();
                    throw new Exception("Client version 2 is not defined");
                }

                //Check game folder
                string gameFolder = tbGameFolder.Text.Trim();
                string mainSwfFile = Path.Combine(gameFolder, "tz.swf");
                if (string.IsNullOrEmpty(gameFolder) || !File.Exists(mainSwfFile))
                {
                    tbGameFolder.Focus();
                    throw new Exception("Game folder is incorrect");
                }
                if (gameFolder[gameFolder.Length - 1] == '\\')
                {
                    gameFolder = gameFolder.Remove(gameFolder.Length - 1, 1);
                }

                //Check login
                string login = tbLogin.Text.Trim();
                if (string.IsNullOrEmpty(login))
                {
                    tbLogin.Focus();
                    throw new Exception("Game login is empty");
                }

                //Check password
                string password = tbPassword.Text;
                if (string.IsNullOrEmpty(password))
                {
                    tbPassword.Focus();
                    throw new Exception("Password is empty");
                }

                //Store settings

                //1. General settings
                AppSettings.Instance["Server"] = gameServer;
                AppSettings.Instance["Port"] = gamePort.ToString();
                AppSettings.Instance["GameFolder"] = gameFolder;
                AppSettings.Instance["ClientVersion"] = clientVer1;
                AppSettings.Instance["ClientVersion2"] = clientVer2;
                AppSettings.Instance["Login"] = login;

                string encPassword = Helper.EncryptStringByHardwareID(password);
                AppSettings.Instance["Password"] = encPassword;

                //2. Main windows settings

                //3. Set properties
                IsGameFolderChanged = !gameFolder.Equals(_oldGameFolder ?? "", StringComparison.InvariantCultureIgnoreCase);
                IsGameSettingsChanged = gameServer != _oldGameServer ||
                                        gamePort.ToString() != _oldGamePort ||
                                        clientVer1 != _oldClientVer1 ||
                                        clientVer2 != _oldClientVer2 ||
                                        !login.Equals(_oldLogin ?? "", StringComparison.InvariantCultureIgnoreCase) ||
                                        password != _oldPassword;

                //Save settings
                AppSettings.Instance.Save();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Saving error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void SaveSettings()
        {
            if (SaveAppSettings())
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void BtnApplyClick(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void FrmSettingsKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    {
                        Close();
                        break;
                    }
                case Keys.Enter:
                    {
                        SaveSettings();
                        break;
                    }
            }
        }

#endregion

    }
}
