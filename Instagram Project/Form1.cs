using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Instagram_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
            private CookieCollection loginCookies;
            public WebProxy proxy = null;
            private string answer;
            private void do_Login(string Username, string Password, string CSRF)
            {
                byte[] bytes = ASCIIEncoding.UTF8.GetBytes("username=" + Username + "&password=" + Password);
                HttpWebRequest postReq = (HttpWebRequest)WebRequest.Create("https://instagram.com/accounts/login/ajax/");
                WebHeaderCollection postHeaders = postReq.Headers;
                postReq.Proxy = proxy;
                postReq.Method = "POST";
                postReq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:38.0) Gecko/20100101 Firefox/38.0";
                postReq.Accept = "*/*";
                postHeaders.Add("Accept-Language", "it-IT,it;q=0.8,en-US;q=0.5,en;q=0.3");
                postHeaders.Add("Accept-Encoding", "gzip, deflate");
                postReq.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                postHeaders.Add("X-Instagram-AJAX", "1");
                postHeaders.Add("X-CSRFToken", CSRF);
                postHeaders.Add("X-Requested-With", "XMLHttpRequest");
                postReq.Referer = "https://instagram.com/accounts/login/";
                postReq.ContentLength = bytes.Length;
                var cookies = new CookieContainer();
                cookies.Add(new Cookie("csrftoken", CSRF) { Domain = "instagram.com" });
                postReq.CookieContainer = cookies;
                postReq.KeepAlive = true;
                postHeaders.Add("Pragma", "no-cache");
                postHeaders.Add("Cache-Control", "no-cache");
                Stream postStream = postReq.GetRequestStream();
                postStream.Write(bytes, 0, bytes.Length);
                postStream.Close();
                HttpWebResponse postResponse;
                postResponse = (HttpWebResponse)postReq.GetResponse();
                loginCookies = postResponse.Cookies;
                StreamReader reader = new StreamReader(postResponse.GetResponseStream());
                answer = reader.ReadToEnd();

            }
            private void doFollow(string profilelink, string followerlink, string CSRF)
            {
                HttpWebRequest postReq = (HttpWebRequest)WebRequest.Create(followerlink);
                WebHeaderCollection postHeaders = postReq.Headers;
                postReq.Proxy = proxy;
                postReq.Method = "POST";
                postReq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.155 Safari/537.36";
                postReq.Accept = "*/*";
                postReq.Referer = profilelink;
                postHeaders.Add("Accept-Language", "en-US,en;q=0.8,ro;q=0.6,de;q=0.4,es;q=0.2,ms;q=0.2");
                postHeaders.Add("Accept-Encoding", "gzip, deflate");
                postHeaders.Add("X-Instagram-AJAX", "1");
                postHeaders.Add("X-CSRFToken", CSRF);
                postHeaders.Add("X-Requested-With", "XMLHttpRequest");
                var cookies = new CookieContainer();
                cookies.Add(loginCookies);
                cookies.Add(new Cookie("csrftoken", CSRF) { Domain = "instagram.com" });
                postReq.CookieContainer = cookies;
                postReq.KeepAlive = true;
                postHeaders.Add("Pragma", "no-cache");
                postHeaders.Add("Cache-Control", "no-cache");
                Stream postStream = postReq.GetRequestStream();
                postStream.Close();
                HttpWebResponse postResponse;
                postResponse = (HttpWebResponse)postReq.GetResponse();
                StreamReader reader = new StreamReader(postResponse.GetResponseStream());

            }
            private string getRequest(string url)
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout =10000;
                request.Proxy = proxy;
                using (var response = request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            public void Follow(string profilelink)
            {
                string request = getRequest(profilelink);
                string csrf_token = Regex.Match(request, @"(?<=""csrf_token"":"")(.*?)(?="")").Value;
                string id = Regex.Match(request, @"(?<=""id"":"")(.*?)(?="")").Value;
                doFollow(profilelink, string.Format("https://instagram.com/web/friendships/{0}/follow/", id), csrf_token);
            }
            public void Login(string username, string password)
            {
                string test = getRequest("https://instagram.com/accounts/login/");
                string csrf_token = Regex.Match(test, @"(?<=""csrf_token"":"")(.*?)(?="")").Value;
                do_Login(username, password, csrf_token);
            }
        Thread t;
        Thread sc;
        Thread tt;
        Thread rd;
        string profURL;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabSignIn;
            tmrCounter.Start();
            
        }
        private void btnLogin_Click(object sender, EventArgs e)

        {
            alertSuccess.Visible = false;
            alertError.Visible = false;
            try
            {
                Login(tbUser.Text, tbPass.Text);
                if (answer.ToString().Contains(@"authenticated"":true"))
                {
                    alertSuccess.Visible = true;
                    alertSuccess.Text = "Welcome " + tbUser.Text + "!";
                    tbUser.Enabled = false;
                    tbPass.Enabled = false;
                    btnLogin.Enabled = false;
                    tabSignIn.ImageIndex = 1;

                }
                else
                {
                    alertError.Visible = true;
                    
                    alertError.Text = "Error trying to log in";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void FollowWOParameters2()
        {
            try {
                foreach (var url in lbScrapedUsernames.Items)
                {

                    profURL = url.ToString();
                    Follow(profURL);
                    tbConsole.Text += System.DateTime.Now + ": Just Followed: " + profURL + "\r\n";
                    Thread.Sleep((int)numSleep.Value);
                }
            }
            catch
            {

            }
        }
        void FollowWOParameters()
        {
            try
            { 
            foreach (var url in lbURLS.Items)
            {
                profURL = url.ToString();
                Follow(profURL);
                tbConsole.Text += System.DateTime.Now + ": Just Followed: " + profURL + "\r\n";
                Thread.Sleep((int)numSleep.Value);

            }
        }
            catch
            {
            }
        }
        private void OpenFileDialog()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text files (*.txt)|*.txt";
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                lblAccountsCount.Visible = true;
                
                 string[] lines = System.IO.File.ReadAllLines(openFile.FileName);

                foreach (string line in lines)
                    {
                        lbURLS.Items.Add(line);
                    
                }



                }
            
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog();
        }
        void scrapeUsers()
        {
            string HTML = tbHtml.Text;
            Match match = Regex.Match(HTML, @"<a href=""/n/(.*?)"" class=""userpic"">");
            while (match.Success)
            {
                lbScrapedUsernames.Items.Add("https://instagram.com/" + match.Groups[1].Value);
                match = match.NextMatch();

            }
            rd.Start();
        }
        private void btnScrape_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            tt= new Thread(getHTML);
            tt.Start();
            sc = new Thread(scrapeUsers);
            rd = new Thread(removeDupes);
            
        }
        private void getHTML()
        {
                var client = new WebClient();
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                string download = client.DownloadString("http://websta.me/keyword/"+tbKeyWord.Text+"?&page=" + (int)numPageScape.Value);
                tbHtml.Text = download;
            sc.Start();
        }
        private void removeDupes()
        {
            
            string[] arr = new string[lbScrapedUsernames.Items.Count];
            lbScrapedUsernames.Items.CopyTo(arr, 0);

            var arr2 = arr.Distinct();

            lbScrapedUsernames.Items.Clear();
            foreach (string s in arr2)
            {
                lbScrapedUsernames.Items.Add(s);
            }
        }
        void count()
        {
            lblScrapedCount.Text = lbScrapedUsernames.Items.Count.ToString();
            lblAccountsCount.Text = "Accounts imported: "+ lbURLS.Items.Count.ToString();
        }
        private void btnFollow_Click(object sender, EventArgs e)
        {

            if (cbImported.Checked == true)
            {
                try
                {
                    CheckForIllegalCrossThreadCalls = false;
                    t = new Thread(FollowWOParameters);
                    t.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Follow Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (cbScraped.Checked == true)
            {
                try
                {
                    CheckForIllegalCrossThreadCalls = false;
                    t = new Thread(FollowWOParameters2);
                    t.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Follow Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void tmrCounter_Tick(object sender, EventArgs e)
        {
            count();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text (*.txt)|*.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (var sw = new StreamWriter(sfd.FileName, false))
                    foreach (var item in lbScrapedUsernames.Items)
                        sw.Write(item.ToString() + Environment.NewLine);
                MessageBox.Show("Success");
            }
        }
    }
}

