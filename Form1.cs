using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BedwarsStats
{
    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        int height;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public string clientBeingUsed = "";

        public string theLogLocation = "";
        public Form1()
        {
            string verNumber = "1.33";
            if (!new WebClient().DownloadString("https://pastebin.com/raw/iwgxBDvi").Contains(verNumber))
            {
                MessageBox.Show("Your version is outdated!..", "....", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //normally this is where download link would go
                Application.Exit();
                Environment.Exit(0);
                this.Close();
            }
            InitializeComponent();        
            timer1.Start();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            height = this.Size.Height;
            this.timer1.Enabled = true;
            this.timer2.Enabled = false;
            listBox2.DrawItem += new DrawItemEventHandler(listBox2_DrawItem);
            listBox5.DrawItem += new DrawItemEventHandler(listBox5_DrawItem);
            listBox3.DrawItem += new DrawItemEventHandler(listBox3_DrawItem);
            listBox4.DrawItem += new DrawItemEventHandler(listBox4_DrawItem);
            listBox8.DrawItem += new DrawItemEventHandler(listBox8_DrawItem);
            DateTime localDate = DateTime.Now;
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            DateTime badlionClient = new DateTime(), regularClient = new DateTime(), pvplounge = new DateTime(), lunar = new DateTime();
            if (Directory.Exists(appdata + "\\.minecraft\\logs\\") || Directory.Exists(appdata + "\\.pvplounge\\logs\\") || Directory.Exists(appdata + "\\lunarclient\\logs\\"))
            {
                badlionClient = File.GetLastWriteTime(appdata + "\\.minecraft\\logs\\blclient\\minecraft\\latest.log");
                pvplounge = File.GetLastWriteTime(appdata + "\\.pvplounge\\logs\\latest.log");
                lunar = File.GetLastWriteTime(appdata + "\\lunarclient\\logs\\latest.log");
                regularClient = File.GetLastWriteTime(appdata + "\\.minecraft\\logs\\latest.log");

                if (badlionClient > regularClient && !(pvplounge > badlionClient) && !(lunar > badlionClient))
                {
                    clientBeingUsed = "Badlion";
                }
                else if (regularClient > badlionClient && !(pvplounge > regularClient) && !(lunar > regularClient))
                {
                    clientBeingUsed = "Vanilla";
                }
                else if (pvplounge > regularClient && pvplounge > badlionClient && !(lunar > pvplounge))
                {
                    clientBeingUsed = "Pvplounge";
                }
                else if (lunar > pvplounge && lunar > badlionClient && lunar > regularClient)
                {
                    clientBeingUsed = "Lunar";
                }
            }
            else 
            {
                MessageBox.Show("Could not find minecraft's %appdata% folder! (Have you installed and ran minecraft at least once?)");
            }
            switch (clientBeingUsed)
            {
                case "Vanilla":
                    theLogLocation = "\\.minecraft\\logs\\latest.log";
                    break;
                case "Badlion":
                    theLogLocation = "\\.minecraft\\logs\\blclient\\minecraft\\latest.log";
                    break;
                case "Pvplounge":
                    theLogLocation = "\\.pvplounge\\logs\\latest.log";
                    break;
                case "Lunar":
                    theLogLocation = "\\lunarclient\\logs\\latest.log";
                    break;
            }
        }
        public int starssss;
        public ArrayList asd; //stores all usernames for later reference
        private void listBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                e.DrawBackground();
                Brush myBrush = Brushes.White;

                int sayi = Convert.ToInt32(Regex.Match(((ListBox)sender).Items[e.Index].ToString(), @"\d+").Value);
                if (sayi >= 0 && sayi < 100) { myBrush = Brushes.Gray; } 
                else if (sayi >= 100 && sayi < 200) { myBrush = Brushes.White; } 
                else if (sayi >= 200 && sayi < 300) { myBrush = Brushes.Gold; } 
                else if (sayi >= 300 && sayi < 400) { myBrush = Brushes.Aqua; } 
                else if (sayi >= 400 && sayi < 500) { myBrush = Brushes.Green; }
                else if (sayi >= 500 && sayi < 600) { myBrush = Brushes.DarkCyan; }
                else if (sayi >= 600 && sayi < 700) { myBrush = Brushes.DarkRed; } 
                else if (sayi >= 700 && sayi < 800) { myBrush = Brushes.Pink; } 
                else if (sayi >= 800 && sayi < 900) { myBrush = Brushes.Blue; } 
                else if (sayi >= 900 && sayi < 1000) { myBrush = Brushes.Purple; } 
                else if (sayi >= 1000) { myBrush = Brushes.Brown; }
                e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
                e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

                e.DrawFocusRectangle();
            }
            catch 
            {
                return;
            }
        }

        private void listBox9_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                e.DrawBackground();
                Brush myBrush = Brushes.White;

                int sayi = Convert.ToInt32(Regex.Match(((ListBox)sender).Items[e.Index].ToString(), @"\d+").Value);
                if (sayi >= 0 && sayi < 100) { myBrush = Brushes.Gray; }
                else if (sayi >= 100 && sayi < 200) { myBrush = Brushes.White; }
                else if (sayi >= 200 && sayi < 300) { myBrush = Brushes.Gold; }
                else if (sayi >= 300 && sayi < 400) { myBrush = Brushes.Aqua; }
                else if (sayi >= 400 && sayi < 500) { myBrush = Brushes.Green; }
                else if (sayi >= 500 && sayi < 600) { myBrush = Brushes.DarkCyan; }
                else if (sayi >= 600 && sayi < 700) { myBrush = Brushes.DarkRed; }
                else if (sayi >= 700 && sayi < 800) { myBrush = Brushes.Pink; }
                else if (sayi >= 800 && sayi < 900) { myBrush = Brushes.Blue; }
                else if (sayi >= 900 && sayi < 1000) { myBrush = Brushes.Purple; }
                else if (sayi >= 1000) { myBrush = Brushes.Brown; }
                e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
                e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

                e.DrawFocusRectangle();
            }
            catch
            {
                return;
            }
        }

        private void listBox5_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                e.DrawBackground();
                Brush myBrush = Brushes.White;

                double sayi = Convert.ToDouble(Regex.Match(((ListBox)sender).Items[e.Index].ToString(), @"\d+").Value);
                if (sayi >= 0 && sayi < 0.55) { myBrush = Brushes.Gray; }
                else if (sayi >= 0.55 && sayi < 1.55) { myBrush = Brushes.White; }
                else if (sayi >= 1.55 && sayi < 3.00) { myBrush = Brushes.Gold; }
                else if (sayi >= 3.00 && sayi < 4.00) { myBrush = Brushes.Aqua; }
                else if (sayi >= 4.00 && sayi < 5.00) { myBrush = Brushes.Green; }
                else if (sayi >= 5.00 && sayi < 6.00) { myBrush = Brushes.DarkCyan; }
                else if (sayi >= 6.00 && sayi < 7.00) { myBrush = Brushes.DarkRed; }
                else if (sayi >= 7.00 && sayi < 8.00) { myBrush = Brushes.Pink; }
                else if (sayi >= 8.00 && sayi < 9.00) { myBrush = Brushes.Blue; }
                else if (sayi >= 9.00 && sayi < 10.00) { myBrush = Brushes.Purple; }
                else if (sayi >= 10.00) { myBrush = Brushes.Red; }
                e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
                e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
                e.DrawFocusRectangle();
            }
            catch
            {
                return;
            }
        }

        private void listBox8_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                e.DrawBackground();
                Brush myBrush = Brushes.White;

                string sayi = ((ListBox)sender).Items[e.Index].ToString();
                if (sayi == "MVP" || sayi == "MVP+") { myBrush = Brushes.Aqua; }
                else if (sayi == "VIP" || sayi == "VIP+") { myBrush = Brushes.Green; }
                else if (sayi == "MVP++") { myBrush = Brushes.Orange; }
                else if (sayi == "NON") { myBrush = Brushes.Gray; }
                e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
                e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
                e.DrawFocusRectangle();
            }
            catch
            {
                return;
            }
        }


        private void listBox3_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                e.DrawBackground();
                Brush myBrush = Brushes.White;
                int sayi = Convert.ToInt32(((ListBox)sender).Items[e.Index].ToString().Replace(",", "").Replace("#", ""));
                if (sayi >= 2000 && sayi < 4999) { myBrush = Brushes.Yellow; }
                else if (sayi >= 5000 && sayi < 9999) { myBrush = Brushes.Gold; }
                else if (sayi >= 10000 && sayi < 19999) { myBrush = Brushes.Aqua; }
                else if (sayi >= 20000) { myBrush = Brushes.Aqua; }
                else { myBrush = Brushes.Gray; }

                e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
                e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

                e.DrawFocusRectangle();
            }
            catch
            {
                return;
            }
        }

        private void listBox4_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                e.DrawBackground();
                Brush myBrush = Brushes.White;
                double sayi = Convert.ToDouble(((ListBox)sender).Items[e.Index].ToString());
                if (sayi >= 0 && sayi < 0.55) { myBrush = Brushes.Gray; } 
                else if (sayi >= 0.55 && sayi < 1.55) { myBrush = Brushes.White; } 
                else if (sayi >= 1.55 && sayi < 3.00) { myBrush = Brushes.Gold; }
                else if (sayi >= 3.00 && sayi < 4.00) { myBrush = Brushes.Aqua; } 
                else if (sayi >= 4.00 && sayi < 5.00) { myBrush = Brushes.Green; }
                else if (sayi >= 5.00 && sayi < 6.00) { myBrush = Brushes.DarkCyan; }
                else if (sayi >= 6.00 && sayi < 7.00) { myBrush = Brushes.DarkRed; } 
                else if (sayi >= 7.00 && sayi < 8.00) { myBrush = Brushes.Pink; } 
                else if (sayi >= 8.00 && sayi < 9.00) { myBrush = Brushes.Blue; } 
                else if (sayi >= 9.00 && sayi < 10.00) { myBrush = Brushes.Purple; } 
                else if (sayi >= 10.00) { myBrush = Brushes.Red; }


                e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
                e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

                e.DrawFocusRectangle();
            }
            catch
            {
                return;
            }
        }
        #region MouseHover

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0xA0 || System.Windows.Forms.Cursor.Position.Y == 537 || System.Windows.Forms.Cursor.Position.X == 494) // WM_NCMOUSEMOVE
            {
                this.Height = 619;
            }
            else if (m.Msg == 0x2A2) // WM_NCMOUSELEAVE
            {
              //  this.Height = 0;
            }

            base.WndProc(ref m);


        }
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            AppendText(richTextBox1, Color.White, "Please do \"/api new\" and \"/who\" when in game before clicking anything.");
        }
        public string[] backtoSbr, splittedUsernames;
        public string ApiKey;

        public ArrayList previousUsernames = new ArrayList(); //stores all usernames for later reference
        public ArrayList starArrayList = new ArrayList();
        public ArrayList rankArrayList = new ArrayList();
        public ArrayList finalsList = new ArrayList();
        public ArrayList winLossList = new ArrayList();
        public ArrayList FKDRList = new ArrayList();
        public ArrayList partyList = new ArrayList();
        public ArrayList nickedList = new ArrayList();
        //public ArrayList sorter = new ArrayList();

        public string botNames = new WebClient().DownloadString("https://pastebin.com/b5fZntN5");
        public async void firstcheck()
        {
            try
            {

                if (backtoSbr == null)
                {
                    splittedUsernames = null;
     


                    Stream stream = File.Open(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + theLogLocation, FileMode.Open, FileAccess.Read, FileShare.ReadWrite); //readalllines doesnt work because of processexception meaning blc cant have it open
                    AppendText(richTextBox1, Color.White, "[+] Getting textlog....");

                    StreamReader streamReader = new StreamReader(stream);
                    string[] str = streamReader.ReadToEnd().Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None); //incase enviornment.newline doesnt work, this means it is required to use all the types (sad face)
                    streamReader.Close();
                    stream.Close();
                    AppendText(richTextBox1, Color.Green, "[+] Got textlog!");


                    var t = str.Where(file => file.Contains("ONLINE:")); // lambda expression to check file
                    foreach (var item in t)
                    {
                        splittedUsernames = item.Split(new string[] { "ONLINE: " }, StringSplitOptions.None);
                    }


                    AppendText(richTextBox1, Color.Green, "[+] Got usernames!");

                    // This code will get the latest text (closest to the bottom) meaning there is no need to check for beforehand statements
                    
                    try
                    {
                        backtoSbr = splittedUsernames[1].Replace(" ", "").Split(','); // 0th index is stuff before, 1st index will get everyone's username. Here, for every comma i split it into a new array element
                    }
                    catch
                    {
                        AppendText(richTextBox1, Color.Red, "[+] Please do /who and try again!"); // literally 0 chance of this happening but if you manage to be goofy then ig
                    }

                    listBox1.Items.AddRange(backtoSbr);
                    

                    AppendText(richTextBox1, Color.Green, "[+] Added usernames!");
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        try
                        {

                            string gatheredName = "https://api.hypixel.net/player?key=" + ApiKey + "&name=" + listBox1.Items[i];
                            if (!previousUsernames.Contains(gatheredName))
                            {
                                previousUsernames.Add(gatheredName);
                                WebClient webClient = new WebClient();
                                webClient.Headers.Add("User-Agent: Other"); //incase security validation on firefox
                                string innerworkings = webClient.DownloadString(gatheredName);
                                await Task.Delay(110);
                                if (innerworkings == ("{\"success\":true,\"player\":null}") || innerworkings.Replace(" ", "").Contains("\"player\":null"))
                                {

                                    nickedList.Add(listBox1.Items[i]);
                                    starArrayList.Add(" ");
                                    rankArrayList.Add(" ");
                                    FKDRList.Add(0);
                                    winLossList.Add(0);
                                    finalsList.Add(" ");
                                    partyList.Add(" ");
                                }
                                else
                                {
                                    JObject json = JObject.Parse(innerworkings);
                                    int finalkills, losses, wins, finaldeaths/*, winstreak, networkexp*/;
                                    string finalkillswithcomma;
                                    bool isbotOrNot = false;
                                    if (botNames.Contains(("\"" + listBox1.Items[i]) + "\""))
                                    {
                                        isbotOrNot = true;
                                    }

                                    finalkills = json["player"]["stats"]["Bedwars"]["final_kills_bedwars"] != null ? (int)json["player"]["stats"]["Bedwars"]["final_kills_bedwars"] : 0;
                                    losses = json["player"]["stats"]["Bedwars"]["losses_bedwars"] != null ? (int)json["player"]["stats"]["Bedwars"]["losses_bedwars"] : 1; //to not cause a dividebyzeroexception when finding WLR
                                    finaldeaths = json["player"]["stats"]["Bedwars"]["final_deaths_bedwars"] != null ? (int)json["player"]["stats"]["Bedwars"]["final_deaths_bedwars"] : 1;
                                    wins = json["player"]["stats"]["Bedwars"]["wins_bedwars"] != null ? (int)json["player"]["stats"]["Bedwars"]["wins_bedwars"] : 0;
                                    int theStars = json["player"]["achievements"]["bedwars_level"] != null ? (int)json["player"]["achievements"]["bedwars_level"] : 0;
                                    starArrayList.Add(theStars + " ✰");
                                    //winstreak = json["player"]["stats"]["Bedwars"]["winstreak"] != null ? (int)json["player"]["stats"]["Bedwars"]["wins_bedwars"] : 0;

                                    // networkexp = json["player"]["networkExp"] != null ? (int)json["player"]["networkExp"] : 0;
                                    string converted = "\"" + listBox1.Items[i] + "\"";




                                    if ((string)json["player"]["channel"] == "ALL" || (string)json["player"]["channel"] == null) { partyList.Add(" ");  } else partyList.Add("✓"); // party array
                                    if (isbotOrNot) rankArrayList.Add("BOT!!"); // below code if - else statements are for ranks
                                    else if ((string)json["player"]["newPackageRank"] == null) rankArrayList.Add(" ");
                                    else
                                    {

                                        string therank = (string)json["player"]["newPackageRank"];
                                        if ((string)json["player"]["monthlyPackageRank"] != null && (string)json["player"]["monthlyPackageRank"] != "NONE")
                                        {
                                            rankArrayList.Add("MVP++");
                                        }
                                        else
                                        {
                                            if (therank == "VIP_PLUS") therank = "VIP+";
                                            if (therank == "MVP_PLUS") therank = "MVP+";


                                            rankArrayList.Add(therank);
                                        }
                                    }
                                    finalkillswithcomma = "#" + finalkills.ToString("N0");
                                    finalsList.Add(finalkillswithcomma); // final kills array
                                    
                                    FKDRList.Add(Math.Round((double)finalkills / finaldeaths, 2)); // fkdr array
                                    winLossList.Add(Math.Round((double)wins / losses, 2)); // win loss ratio
                                    //listBox2.Items.Add(starssss + " ✰");
                                    //listBox3.Items.Add(finalkillswithcomma);
                                    //listBox4.Items.Add(wlr);
                                    //listBox5.Items.Add(fkdr);
                                    //listBox9.Items.Add(getLevel(networkexp));
                                    // json values wont return a value if null so this is required


                                    if (i == listBox1.Items.Count - 1)
                                    {
                                        listBox2.Items.AddRange(starArrayList.ToArray());
                                        listBox8.Items.AddRange(rankArrayList.ToArray());
                                        listBox3.Items.AddRange(finalsList.ToArray());
                                        listBox4.Items.AddRange(winLossList.ToArray());
                                        listBox5.Items.AddRange(FKDRList.ToArray());
                                        listBox7.Items.AddRange(partyList.ToArray());
                                        listBox6.Items.AddRange(nickedList.ToArray());
                                        starArrayList.Clear();
                                        rankArrayList.Clear();
                                        finalsList.Clear();
                                        winLossList.Clear();
                                        FKDRList.Clear();
                                        partyList.Clear();
                                        nickedList.Clear();
                                        previousUsernames.Clear();
                                    }
                                }
                                
                            }
                            
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                            System.Threading.Thread.Sleep(10);
                        }
                    }

                    
                }
            }
            catch { }
            // fkdr * fkdr + wlr
            //for (int i = 0; i < winLossList.Count; i++)
            //{
          
            //    double fkdr = (double)FKDRList[i];
            //    double winloss = (double)winLossList[i];
            //    double theRank = (fkdr * fkdr) + winloss;
            //    sorter.Add(theRank); //adds indexes 
            //} //calculate avgs.
            //  //  int[] array = sorter.ToArray().ToList().IndexOf(sorter.ToArray().Max());
            //ArrayList sorterWithIndexes = new ArrayList();
            //for (int i = 0; i < sorter.Count; i++)
            //{
            //    int max = sorter.ToArray().ToList().IndexOf(sorter.ToArray().Max());
            //    sorterWithIndexes.Add(max); // store indexes EX{4, 2, 1, 6}
            //}
            //// sort {4, 2, 1 , 6}  {20, 10, 5, 30}
            //Array.Sort(sorterWithIndexes, sorter);

            for (int i = listBox1.Items.Count - 1; i >= 0; i--)
            { // remove nickname
                try
                {
                    if (listBox3.Items[i].ToString() == " ")
                    {
                        listBox1.Items.RemoveAt(i);
                        listBox2.Items.RemoveAt(i);
                        listBox3.Items.RemoveAt(i);
                        listBox4.Items.RemoveAt(i);
                        listBox5.Items.RemoveAt(i);
                        listBox7.Items.RemoveAt(i);
                        listBox8.Items.RemoveAt(i);
                    }
                }
                catch { continue;  }
            }
            
            //sortListBoxes();

        }

        public void sortListBoxes()
        {

        }
        //public bool sortedYesOrno = false;
        /*public void sortListBoxes()
        {
            double[] indexing = new double[listBox1.Items.Count];
            double[] arrangedBySize = new double[listBox1.Items.Count];

            ArrayList usernames = new ArrayList();
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                usernames.Add(listBox1.Items[i]);
            }
            ArrayList listbox1items = new ArrayList();
            for (int i = 0; i < listBox5.Items.Count; i++)
            {
                double math = (double)listBox5.Items[i] * (double)listBox5.Items[i] * (double)listBox4.Items[i];
                indexing[i] = math;
                // need a new method to find greatest via index, this only finds the calculations.
            }
            for (int i = 0; i < indexing.Length; i++)
            {
                double maxinteger = indexing.Max();
                arrangedBySize[i] = indexing.ToList().IndexOf(maxinteger);
                // this will find greatest index (using calculations and not listbox)
                // arrangedBySize returns something along the lines of 
                // { 5, 3, 2, 1, 0, 6 }
                // EX:  123, 378, 7128, 12985, 12, 8      
               

                
            }
            listBox1.Items.Clear();
            for (int i = 0; i < arrangedBySize.Length; i++)
            {
                listBox1.Items.Add(usernames[i]);
            }



        }

        */
        public void AppendText(RichTextBox box, Color color, string text)
        {
            int start = box.TextLength;
            box.AppendText(text);
            int end = box.TextLength;
            box.Select(start, end - start);
            {
                box.SelectionColor = color;
            }
            box.SelectionLength = 0; // clear
            AppendText2(richTextBox1, Color.White, "\n");
        }
        public static void AppendText2(RichTextBox box, Color color, string text)
        {
            int start = box.TextLength;
            box.AppendText(text);
            int end = box.TextLength;
            box.Select(start, end - start);
            {
                box.SelectionColor = color;
            }
            box.SelectionLength = 0;
        }  
        bool apikeyexists = false;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            repeat();
        }
        private void repeat()
        {
            if (!apikeyexists)
            {
                richTextBox1.ScrollToCaret();
                AppendText(richTextBox1, Color.White, "[+] Getting api key....");
                try
                {

                    Stream stream = File.Open(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + theLogLocation, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                    StreamReader streamReader = new StreamReader(stream);
                    string[] str = streamReader.ReadToEnd().Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                    streamReader.Close();
                    stream.Close();

                    var t = str.Where(file => file.Contains("[CHAT] Your new API key is")); // lambda expression to check file, gets text for this part
                    foreach (var item in t)
                    {
                        string[] lol = item.Split(new string[] { "[CHAT] Your new API key is " }, StringSplitOptions.None);
                        ApiKey = lol[1]; //sets apIKEY
                        AppendText(richTextBox1, Color.Green, "[+] Got api key!");
                        AppendText(richTextBox1, Color.White, "[+] Testing key...");
                        label3.Text = "Your Api Key: " + ApiKey;
                        apikeyexists = true;
                        timer1.Enabled = false;
                        timer2.Enabled = true;
                    }
                }
                catch { }
            }
        }

        ArrayList linesvariables = new ArrayList();
        private void Form1_MouseHover(object sender, EventArgs e)
        {           
            this.Height = 619;
            this.Focus();
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            this.Focus();
            this.Opacity = 1;
        }

        private async void Form1_MouseLeave(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        public const int WM_NCLBUTTONDOWN1 = 0xA1;
        public const int HT_CAPTION1 = 0x2;

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN1, HT_CAPTION1, 0);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
            Process.GetCurrentProcess().Kill();
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void listBox4_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        // gets index via position of mouse.
                        int index = listBox4.IndexFromPoint(e.X, e.Y);
                        string username = (string)listBox1.Items[index];
                        // creates new context menu.

                        listBox4.ContextMenu = new ContextMenu();
                        int fourwins, doublewins, solowins, threeswins;
                        int fourlosses, doublelosses, sololosses, threeslosses;
                       
                       // string[] wow = { "player", "stats", "Bedwars", "four_three_losses_bedwars", "four_three_wins_bedwars", "four_four_wins_bedwars", "four_four_losses_bedwars", "eight_two_wins_bedwars", "eight_two_wins_bedwars", "eight_two_losses_bedwars", "eight_one_wins_bedwars", "eight_one_losses_bedwars"  };
                        string innerworkings = new WebClient().DownloadString("https://api.hypixel.net/player?key=" + ApiKey + "&name=" + username);
                        JObject json = JObject.Parse(innerworkings);

                        fourwins = json["player"]["stats"]["Bedwars"]["four_four_wins_bedwars"] != null ? (int)json["player"]["stats"]["Bedwars"]["four_four_wins_bedwars"] : 0;
                        doublewins = json["player"]["stats"]["Bedwars"]["eight_two_wins_bedwars"] != null ? (int)json["player"]["stats"]["Bedwars"]["eight_two_wins_bedwars"] : 0;
                        solowins = json["player"]["stats"]["Bedwars"]["eight_one_wins_bedwars"] != null ? (int)json["player"]["stats"]["Bedwars"]["eight_one_wins_bedwars"] : 0;
                        threeswins = json["player"]["stats"]["Bedwars"]["four_three_wins_bedwars"] != null ? (int)json["player"]["stats"]["Bedwars"]["four_three_wins_bedwars"] : 0;

                        fourlosses = json["player"]["stats"]["Bedwars"]["four_four_losses_bedwars"] != null ? (int)json["player"]["stats"]["Bedwars"]["four_four_losses_bedwars"] : 1;
                        doublelosses = json["player"]["stats"]["Bedwars"]["eight_two_losses_bedwars"] != null ? (int)json["player"]["stats"]["Bedwars"]["eight_two_losses_bedwars"] : 1;
                        threeslosses = json["player"]["stats"]["Bedwars"]["four_three_losses_bedwars"] != null ?  (int)json["player"]["stats"]["Bedwars"]["four_three_losses_bedwars"] : 1;
                        sololosses = json["player"]["stats"]["Bedwars"]["eight_one_losses_bedwars"] != null ?  (int)json["player"]["stats"]["Bedwars"]["eight_one_losses_bedwars"] : 1;


                        // TODO: MAKE COLORING FOR THE CONTEXT MENU
                        //  listBox4.ContextMenu.GetCurrentParent() = Color.FromArgb(1, 1, 1);
                        listBox4.ContextMenu.MenuItems.Add("Solo: " + Math.Round((double) solowins / (double)sololosses, 3));
                        listBox4.ContextMenu.MenuItems.Add("Duos: " + Math.Round((double)doublewins / (double)doublelosses, 3));
                        listBox4.ContextMenu.MenuItems.Add("Trios: " + Math.Round((double)threeswins / (double)threeslosses, 3));
                        listBox4.ContextMenu.MenuItems.Add("Fours: " + Math.Round((double)fourwins / (double)fourlosses, 3));
                        foreach (MenuItem item in listBox4.ContextMenu.MenuItems)
                        {
                            item.OwnerDraw = true;
                            item.DrawItem += item_DrawItem;
                            item.MeasureItem += MeasureMenuItem;
                        }


                        listBox4.ContextMenu.Show(listBox4, new Point(e.X, e.Y));//places the menu at the pointer position
                    }
                    break;
            }
        }

        private void listBox5_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        // gets index via position of mouse.
                        int index = listBox5.IndexFromPoint(e.X, e.Y);
                        string username = (string)listBox1.Items[index];
                        // creates new context menu.

                        listBox5.ContextMenu = new ContextMenu();
                        int fourwins, doublewins, solowins, threeswins;
                        int fourlosses, doublelosses, sololosses, threeslosses;

                       // string[] wow = { "player", "stats", "Bedwars", "four_three_losses_bedwars", "four_three_wins_bedwars", "four_four_wins_bedwars", "four_four_losses_bedwars", "eight_two_wins_bedwars", "eight_two_wins_bedwars", "eight_two_losses_bedwars", "eight_one_wins_bedwars", "eight_one_losses_bedwars" };
                        string innerworkings = new WebClient().DownloadString("https://api.hypixel.net/player?key=" + ApiKey + "&name=" + username);
                        JObject json = JObject.Parse(innerworkings);

                        fourwins = json["player"]["stats"]["Bedwars"]["four_four_final_kills_bedwars"] != null ? (int)json["player"]["stats"]["Bedwars"]["four_four_final_kills_bedwars"] : 0;
                        doublewins = json["player"]["stats"]["Bedwars"]["eight_two_final_kills_bedwars"] != null ? (int)json["player"]["stats"]["Bedwars"]["eight_two_final_kills_bedwars"] : 0;
                        solowins = json["player"]["stats"]["Bedwars"]["eight_one_final_kills_bedwars"] != null ? (int)json["player"]["stats"]["Bedwars"]["eight_one_final_kills_bedwars"] : 0;
                        threeswins = json["player"]["stats"]["Bedwars"]["four_three_final_kills_bedwars"] != null ? (int)json["player"]["stats"]["Bedwars"]["four_three_final_kills_bedwars"] : 0;

                        fourlosses = json["player"]["stats"]["Bedwars"]["four_four_final_deaths_bedwars"] != null ? (int)json["player"]["stats"]["Bedwars"]["four_four_final_deaths_bedwars"] : 1;
                        doublelosses = json["player"]["stats"]["Bedwars"]["eight_two_final_deaths_bedwars"] != null ? (int)json["player"]["stats"]["Bedwars"]["eight_two_final_deaths_bedwars"] : 1;
                        threeslosses = json["player"]["stats"]["Bedwars"]["four_three_final_deaths_bedwars"] != null ? (int)json["player"]["stats"]["Bedwars"]["four_three_final_deaths_bedwars"] : 1;
                        sololosses = json["player"]["stats"]["Bedwars"]["eight_one_final_deaths_bedwars"] != null ? (int)json["player"]["stats"]["Bedwars"]["eight_one_final_deaths_bedwars"] : 1;


                        // TODO: MAKE COLORING FOR THE CONTEXT MENU
                        //  listBox4.ContextMenu.GetCurrentParent() = Color.FromArgb(1, 1, 1);
                        listBox5.ContextMenu.MenuItems.Add("Solo: " + Math.Round((double)solowins / (double)sololosses, 3));
                        listBox5.ContextMenu.MenuItems.Add("Duos: " + Math.Round((double)doublewins / (double)doublelosses, 3));
                        listBox5.ContextMenu.MenuItems.Add("Trios: " + Math.Round((double)threeswins / (double)threeslosses, 3));
                        listBox5.ContextMenu.MenuItems.Add("Fours: " + Math.Round((double)fourwins / (double)fourlosses, 3));
                        foreach (MenuItem item in listBox5.ContextMenu.MenuItems)
                        {
                            item.OwnerDraw = true;
                            item.DrawItem += item_DrawItem;
                            item.MeasureItem += MeasureMenuItem;
                        }


                        listBox5.ContextMenu.Show(listBox5, new Point(e.X, e.Y));//places the menu at the pointer position
                    }
                    break;
            }
        }
        private void listBox3_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        // gets index via position of mouse.
                        int index = listBox3.IndexFromPoint(e.X, e.Y);
                        string username = (string)listBox1.Items[index];
                        // creates new context menu.

                        listBox3.ContextMenu = new ContextMenu();
                        int fourwins, doublewins, solowins, threeswins;

                        
                        string innerworkings = new WebClient().DownloadString("https://api.hypixel.net/player?key=" + ApiKey + "&name=" + username);
                        JObject json = JObject.Parse(innerworkings);

                        fourwins = json["player"]["stats"]["Bedwars"]["four_four_final_kills_bedwars"] != null ? (int)json["player"]["stats"]["Bedwars"]["four_four_final_kills_bedwars"] : 0;
                        doublewins = json["player"]["stats"]["Bedwars"]["eight_two_final_kills_bedwars"] != null ? (int)json["player"]["stats"]["Bedwars"]["eight_two_final_kills_bedwars"] : 0;
                        solowins = json["player"]["stats"]["Bedwars"]["eight_one_final_kills_bedwars"] != null ? (int)json["player"]["stats"]["Bedwars"]["eight_one_final_kills_bedwars"] : 0;
                        threeswins = json["player"]["stats"]["Bedwars"]["four_three_final_kills_bedwars"] != null ? (int)json["player"]["stats"]["Bedwars"]["four_three_final_kills_bedwars"] : 0;

                        // TODO: MAKE COLORING FOR THE CONTEXT MENU
                        //  listBox4.ContextMenu.GetCurrentParent() = Color.FromArgb(1, 1, 1);
                        listBox3.ContextMenu.MenuItems.Add("Solo: " + Math.Round((double)solowins, 3));
                        listBox3.ContextMenu.MenuItems.Add("Duos: " + Math.Round((double)doublewins, 3));
                        listBox3.ContextMenu.MenuItems.Add("Trios: " + Math.Round((double)threeswins, 3));
                        listBox3.ContextMenu.MenuItems.Add("Fours: " + Math.Round((double)fourwins, 3));
                        foreach (MenuItem item in listBox3.ContextMenu.MenuItems)
                        {
                            item.OwnerDraw = true;
                            item.DrawItem += item_DrawItem;
                            item.MeasureItem += MeasureMenuItem;
                        }


                        listBox3.ContextMenu.Show(listBox3, new Point(e.X, e.Y));//places the menu at the pointer position
                    }
                    break;
            }
        }
        void item_DrawItem(object sender, DrawItemEventArgs e)
        {
            var item = (MenuItem)sender;
            var g = e.Graphics;
            var font = new Font("Segoe UI", 11, FontStyle.Regular);
            var brush = new SolidBrush(System.Drawing.Color.White);
            g.FillRectangle(new SolidBrush(Color.Black), e.Bounds);
            g.DrawString(item.Text, font, brush, e.Bounds.X, e.Bounds.Y);
        }

        void MeasureMenuItem(object sender, MeasureItemEventArgs e)
        {
            MenuItem m = (MenuItem)sender;
            Font font = new Font(Font.FontFamily, Font.Size, Font.Style);
            SizeF sze = e.Graphics.MeasureString(m.Text, font);
            e.ItemHeight = (int)sze.Height + 10;
            e.ItemWidth = (int)sze.Width + 15;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }




        //private KeyMessageFilter m_filter = new KeyMessageFilter();

        private void Label2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN1, HT_CAPTION1, 0);
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = checkBox1.Checked;
        }
        private async void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (apikeyexists)
            {
                try
                {

                    Stream stream = File.Open(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + theLogLocation, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                    StreamReader streamReader = new StreamReader(stream);
                    string[] str = streamReader.ReadToEnd().Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                    streamReader.Close();
                    stream.Close();
                    foreach (var match in str.Select((text, index) => new { text, lineNumber = index + 1 }).Where(x => x.text.Contains("[CHAT] ONLINE:")))
                    {
                        if (!linesvariables.Contains(match.lineNumber))
                        {
                            linesvariables.Add(match.lineNumber);
                            foreach(ListBox a in this.Controls.OfType<ListBox>())
                            {
                                a.Items.Clear();
                            }
                            this.Focus();
                            splittedUsernames = null;
                            backtoSbr = null;
                            firstcheck();                           
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private bool Active;
        private async void Form1_Activated(object sender, EventArgs e)
        {
            this.Active = true;
            base.Opacity = 0.75;
            for (int i = 1; i <= 93; i++)
            {
                bool active = this.Active;
                bool flag = active;
                if (flag)
                {
                    base.Opacity += 0.01;
                    await Task.Delay(1);
                }
            }
        }
        private async void Form1_Deactivate(object sender, EventArgs e)
        {
            this.Active = false;
            base.Opacity = 0.95;
            for (int i = 1; i <= 93; i++)
            {
                bool flag = !this.Active;
                bool flag2 = flag;
                if (flag2)
                {
                    base.Opacity -= 0.01;
                    await Task.Delay(1);
                }
            }
        }
    }
}
