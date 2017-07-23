using System;
using InstaFame.Instagram;
using System.Windows.Forms;
using InstaFame.Instagram.UserUtilities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using static InstaFame.Instagram.UserUtilities.User;
using System.Threading;
using System.Drawing;

namespace InstaFame.Forms
{
    public partial class MainForm : Form
    {
        /*
            TODO:
            ~ Better Proxy Support
            ~ Auto-Like & Auto-Comment 
            ~ Implement Post Count When Fetching Posts. / Like+Comment On Certain # Of Posts
            ~ Refactor Messy Code
            ~ Unfollow Individual Users
            ~ Unfollow Users While Worker IsBusy
        */

        private string username, followedFile, proxy;
        private bool likeAndComment;
        private List<string> comments, queries, proxies;
        private BackgroundWorker worker;
        private int proxyIndex, actions, proxySwitch, timeout;

        public MainForm()
        {
            InitializeComponent();

            proxy = string.Empty;
            username = string.Empty;
            likeAndComment = false;
            comments = new List<string>();
            queries = new List<string>();
            proxies = new List<string>();
            followedFile = $"{Directory.GetCurrentDirectory()}\\users\\followed_<currentuser>.txt";

            checkLikeComment.CheckedChanged += CheckLikeComment_CheckedChanged;
            lstUsers.MouseDown += LstUsers_MouseDown;

            worker = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };
            worker.DoWork += Worker_DoWork;
            proxyIndex = 0;
            actions = 0;
            proxySwitch = 0;
            timeout = 0;
            this.FormClosing += MainForm_FormClosing;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Environment.Exit(1);
        }

        Random r = new Random();
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (proxies.Count > 0 && proxyIndex == 0)
            {
                proxy = proxies[0];
            }

            for (int i = 0; i < queries.Count; i++)
            {
                string query = queries[i];
                Search search = new Search(query);
                List<string> searchResults = null;
                try
                {
                    searchResults = new List<string>(search.GetResults(proxy));
                    tsBottom.Invoke(new Action(() =>
                    {
                        lblStatus.ForeColor = Color.Green;
                        lblStatus.Text = "Status: Getting Search Results";
                    }));

                }
                catch
                {
                    proxy = SwitchProxy();
                    i = i - 1;
                    Thread.Sleep(TimeSpan.FromSeconds(timeout));
                    continue;
                }

                actions++;
                if (actions > proxySwitch)
                {
                    proxy = SwitchProxy();
                    actions = 0;
                }

                lstScrapedUsers.Invoke(new Action(() =>
                {
                    lstScrapedUsers.Items.AddRange(searchResults.ToArray());
                }));

                for (int ii = 0; ii < searchResults.Count; ii++)
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        tsBottom.Invoke(new Action(() =>
                        {
                            lblStatus.Text = "Status: Idle";
                            lblStatus.ForeColor = Color.Green;
                        }));
                        return;
                    }
                    string result = searchResults[ii];

                    if (File.Exists(followedFile.Replace("<currentuser>", username)))
                    {
                        List<string> contents = new List<string>(File.ReadAllLines(followedFile.Replace("<currentuser>", username)));
                        if (contents.Contains(result))
                            continue;
                    }

                    User user = new User(result);
                    try
                    {
                        if (user.Follow(proxy))
                        {
                            tsBottom.Invoke(new Action(() =>
                            {
                                lblStatus.ForeColor = Color.Green;
                                lblStatus.Text = "Status: Followed User";
                            }));
                            actions++;
                            if (actions > proxySwitch)
                            {
                                proxy = SwitchProxy();
                                actions = 0;
                            }

                            File.AppendAllText($"{followedFile.Replace("<currentuser>", username)}", $"{result}{Environment.NewLine}");
                            ListViewItem lvi = new ListViewItem(result);
                            lvi.SubItems.Add(Helpers.FollowsCurrent(result, proxy).ToString());
                            lstUsers.Invoke(new Action(() =>
                            {
                                lstUsers.Items.Add(lvi);
                            }));

                            if (likeAndComment)
                            {
                                List<string> recentPosts = new List<string>(user.GetRecentPosts());

                                for (int iii = 0; iii < recentPosts.Count; iii++)
                                {
                                    string postUrl = recentPosts[iii];
                                    Post post = new Post(postUrl);
                                    try
                                    {
                                        post.Like(proxy);
                                        tsBottom.Invoke(new Action(() =>
                                        {
                                            lblStatus.ForeColor = Color.Green;
                                            lblStatus.Text = "Status: Adding Like";
                                        }));
                                        actions++;
                                        if (actions > proxySwitch)
                                        {
                                            proxy = SwitchProxy();
                                            actions = 0;
                                        }
                                    }
                                    catch
                                    {
                                        proxy = SwitchProxy();
                                        iii = iii - 1;
                                        Thread.Sleep(TimeSpan.FromSeconds(timeout));
                                        continue;
                                    }

                                    string comment = comments[r.Next(0, comments.Count)];
                                    try
                                    {
                                        post.Comment(comment, proxy);
                                        tsBottom.Invoke(new Action(() =>
                                        {
                                            lblStatus.ForeColor = Color.Green;
                                            lblStatus.Text = "Status: Adding Comment";
                                        }));
                                        actions++;
                                        if (actions > proxySwitch)
                                        {
                                            proxy = SwitchProxy();
                                            actions = 0;
                                        }
                                    }
                                    catch
                                    {
                                        proxy = SwitchProxy();
                                        iii = iii - 1;
                                        Thread.Sleep(TimeSpan.FromSeconds(timeout));
                                        continue;
                                    }
                                    Thread.Sleep(TimeSpan.FromSeconds(timeout));
                                }
                            }
                        }
                    }
                    catch
                    {
                        proxy = SwitchProxy();
                        ii = ii - 1;
                        Thread.Sleep(TimeSpan.FromSeconds(timeout));
                        continue;
                    }

                    Thread.Sleep(TimeSpan.FromSeconds(timeout));
                }
                Thread.Sleep(TimeSpan.FromSeconds(timeout));
            }

            tsBottom.Invoke(new Action(() =>
            {
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "Status: Done!";
            }));
            worker.CancelAsync();
         }

        private void LstUsers_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenu.Show(lstUsers, e.Location);
            }
        }

        private void CheckLikeComment_CheckedChanged(object sender, EventArgs e)
        {
            if (worker.IsBusy)
                return;

            likeAndComment = checkLikeComment.Checked;
            txtComments.Enabled = checkLikeComment.Checked;
        }

        private void tsUpdate_Click(object sender, EventArgs e)
        {
            if (worker.IsBusy || !Cookies.Authenticated)
                return;

            new Thread(() =>
            {
                string fileName = followedFile.Replace("<currentuser>", username);
                if (File.Exists(fileName))
                {
                    lstUsers.Invoke(new Action(() =>
                    {
                        lstUsers.Items.Clear();
                    }));

                    List<string> lines = new List<string>(File.ReadAllLines(fileName));
                    lines.ForEach(x =>
                    {
                        ListViewItem lvi = new ListViewItem(x);
                        lvi.SubItems.Add($"{Helpers.FollowsCurrent(username)}");
                        lstUsers.Invoke(new Action(() =>
                        {
                            lstUsers.Items.Add(lvi);
                        }));
                    });
                }
            }).Start();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists($"{Directory.GetCurrentDirectory()}\\users\\"))
            {
                Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}\\users\\");
            }

            checkRemember.Checked = Properties.Settings.Default.Remember;
            if (Properties.Settings.Default.Remember)
            {
                txtUsername.Text = Properties.Settings.Default.Username;
                txtPassword.Text = Properties.Settings.Default.Password;
            }

            Helpers.Init();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == string.Empty || txtPassword.Text == string.Empty || worker.IsBusy)
                return;

            Auth auth = new Auth(txtUsername.Text, txtPassword.Text);
            new Thread(() =>
            {
                if (auth.Authenticate())
                {
                    username = txtUsername.Text;
                    int followers = Helpers.GetFollowers(username);

                    Properties.Settings.Default.Remember = checkRemember.Checked;
                    if (Properties.Settings.Default.Remember)
                    {
                        Properties.Settings.Default.Username = txtUsername.Text;
                        Properties.Settings.Default.Password = txtPassword.Text;
                        Properties.Settings.Default.Save();
                    }

                    if (Properties.Settings.Default.Followers == -1)
                    {
                        Properties.Settings.Default.Followers = followers;
                        Properties.Settings.Default.Save();
                    }

                    int gained = 0;
                    tsBottom.Invoke(new Action(() =>
                    {
                        lblStatus.Text = "Status: Logged in";
                        lblStatus.ForeColor = Color.Green;
                        lblFollowers.Text = $"Followers: {followers}";
                        lblFollowersGained.Text = $"Followers Gained: {gained}";
                    }));

                    string fileName = followedFile.Replace("<currentuser>", username);
                    if (File.Exists(fileName))
                    {
                        tsBottom.Invoke(new Action(() =>
                        {
                            lblStatus.Text = "Status: Grabbing Users Followed";
                            lblStatus.ForeColor = Color.Green;
                        }));

                        List<string> lines = new List<string>(File.ReadAllLines(fileName));
                        lines.ForEach(x =>
                        {
                            bool followsYou = Helpers.FollowsCurrent(username);
                            if (followsYou)
                                gained++;
                            ListViewItem lvi = new ListViewItem(x);
                            lvi.SubItems.Add($"{followsYou}");
                            lstUsers.Invoke(new Action(() =>
                            {
                                lstUsers.Items.Add(lvi);
                            }));
                        });
                    }
                }
                else
                {
                    username = string.Empty;
                    tsBottom.Invoke(new Action(() =>
                    {
                        lblStatus.Text = "Status: Failed to log in";
                        lblStatus.ForeColor = Color.Red;
                        lblFollowers.Text = $"Followers: 0";
                        lblFollowersGained.Text = $"Followers Gained: 0";
                    }));
                }

                tsBottom.Invoke(new Action(() =>
                {
                    lblStatus.Text = "Status: Idle";
                    lblStatus.ForeColor = Color.Green;
                }));
            }).Start();
        }

        private void btnUnfollowUsers_Click(object sender, EventArgs e)
        {
            if (!Cookies.Authenticated || worker.IsBusy)
                return;

            string fileName = followedFile.Replace("<currentuser>", username);
            if (File.Exists(fileName))
            {
                List<string> lines = new List<string>(File.ReadAllLines(fileName));
                new Thread(() =>
                {
                    lstUsers.Invoke(new Action(() =>
                    {
                        lstUsers.Items.Clear();
                    }));

                    proxy = SwitchProxy();
                    for (int i = 0; i < lines.Count; i++)
                    {
                        string username = lines[i];
                        if (Helpers.FollowsCurrent(username))
                        {
                            User user = new User(username);
                            try
                            {
                                if (user.Unfollow(proxy))
                                {
                                    tsBottom.Invoke(new Action(() =>
                                    {
                                        lblStatus.ForeColor = Color.Green;
                                        lblStatus.Text = "Status: Unfollowed User";
                                    }));
                                    lines.Remove(username);
                                    File.WriteAllLines(fileName, lines.ToArray());
                                }
                            }
                            catch
                            {
                                proxy = SwitchProxy();
                                i = i - 1;
                                Thread.Sleep((int)numericTimeout.Value);
                                continue;
                            }
                        }
                        else
                        {
                            ListViewItem lvi = new ListViewItem(username);
                            lvi.SubItems.Add(Helpers.FollowsCurrent(username).ToString());
                            lstUsers.Invoke(new Action(() =>
                            {
                                lstUsers.Items.Add(lvi);
                            }));
                        }
                        Thread.Sleep((int)numericTimeout.Value);
                    }

                    tsBottom.Invoke(new Action(() =>
                    {
                        lblStatus.Text = "Status: Idle";
                        lblStatus.ForeColor = Color.Green;
                    }));
                }).Start();
            }
        }

        private void tsUnfollowAll_Click(object sender, EventArgs e)
        {
            if (!Cookies.Authenticated || worker.IsBusy)
                return;

            string fileName = followedFile.Replace("<currentuser>", username);
            if (File.Exists(fileName))
            {
                List<string> lines = new List<string>(File.ReadAllLines(fileName));
                new Thread(() =>
                {
                    lstUsers.Invoke(new Action(() =>
                    {
                        lstUsers.Items.Clear();
                    }));

                    proxy = SwitchProxy();
                    for (int i = 0; i < lines.Count; i++)
                    {
                        string username = lines[i];
                        User user = new User(username);
                        try
                        {
                            if (user.Unfollow(proxy))
                            {
                                tsBottom.Invoke(new Action(() =>
                                {
                                    lblStatus.ForeColor = Color.Green;
                                    lblStatus.Text = "Status: Unfollowed User";
                                }));
                                lines.Remove(username);
                                File.WriteAllLines(fileName, lines.ToArray());
                            }
                        }
                        catch
                        {
                            proxy = SwitchProxy();
                            i = i - 1;
                            Thread.Sleep((int)numericTimeout.Value);
                            continue;
                        }
                        Thread.Sleep((int)numericTimeout.Value);
                    }

                    tsBottom.Invoke(new Action(() =>
                    {
                        lblStatus.Text = "Status: Idle";
                        lblStatus.ForeColor = Color.Green;
                    }));
                }).Start();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (worker.IsBusy || !Cookies.Authenticated)
                return;

            proxySwitch = (int)numericProxySwitch.Value;
            timeout = (int)numericTimeout.Value;

            comments.Clear();
            queries.Clear();

            comments.AddRange(txtComments.Lines);
            queries.AddRange(txtQueries.Lines);

            lstScrapedUsers.Items.Clear();

            lblStatus.ForeColor = Color.Green;
            lblStatus.Text = "Status: Running";

            worker.RunWorkerAsync();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (!worker.IsBusy)
                return;

            worker.CancelAsync();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = "Text Files (*.txt) | *.txt",
                Multiselect = true
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                new Thread(() =>
                {
                    foreach (string fileName in ofd.FileNames)
                    {
                        proxies.AddRange(File.ReadAllLines(fileName));
                    }
                }).Start();
            }
        }

        private void btnClearProxies_Click(object sender, EventArgs e)
        {
            proxies.Clear();
        }

        private string SwitchProxy()
        {
            if (proxies.Count > 0 && proxyIndex != -1 && proxyIndex++ < proxies.Count)
            {
                proxyIndex = proxyIndex + 1;
                return proxies[proxyIndex];
            }
            else
            {
                proxyIndex = -1;
                return string.Empty;
            }
        }
    }
}
