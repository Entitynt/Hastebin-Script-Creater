using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastebinCreateScript
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private static readonly Regex regex = new Regex("{\"key\":\"(?<key>[a-z].*)\"}", RegexOptions.Compiled);
        public async void createscript(string script)
        {
            using (WebClient client = new WebClient())
            {
                string response = await client.UploadStringTaskAsync("https://hastebin.com/documents", script);
                Match match = regex.Match(response);
                Process.Start("https://hastebin.com/" + (object)match.Groups["key"]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createscript(richTextBox1.Text);
        }
    }
}
