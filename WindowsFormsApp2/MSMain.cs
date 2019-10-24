using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class MSMain : Form
    {
        private String username;
        public int score;
        private int n;
        int[,] MSTabla;
        public bool igraUtoku = false;
        int[] elementi;
        List<int> korisceniElementi;
        private int suma;
        // private PNParovi[] PNkomb;
        public int brPNK = 0;
        public int brpoena = 0;
        int[,] PNVrste;


        private bool igraPocela = false;
        private Timer timer = new Timer();
        private int timeLeft;
        private int brojElemenata;



        public int Suma
        {
            get { return suma; }
            set { suma = value; }
        }

        //public int MyProperty { get; set; }

        public int N
        {
            get
            {
                return n;
            }

            set
            {
                n = value;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public MSMain()
        {
            InitializeComponent();
            korisceniElementi = new List<int>();
            Username = "";

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        //private void label1_Click(object sender, EventArgs e)
        //{

        //}

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitter3_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (igraPocela == true)
            {
                timer.Stop();
                timer.Dispose();
                MessageBox.Show("Odustali ste od igre!", "KRAJ");
                panel1.Controls.Clear();
                lblIgrac.Text = "Igrač ";
                label3.Text = "00:00";
                igraPocela = false;
            }
            else
            {
                MessageBox.Show("Ne odustajte pre nego sto ste poceli!", "GRESKA");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(igraPocela)
                ispitajKraj();
        }

        public int[] izracunajSumuVrsta()
        {
            int[] sume = new int[n];
            int trenutno;
            for (int i = 0; i < n; i++)
            {
                trenutno = 0;
                for (int j = 0; j < n; j++)
                    trenutno += MSTabla[i, j];
                sume[i] = trenutno;
            }
            return sume;
        }

        public int[] izracunajSumuKolona()
        {
            int[] sume = new int[n];
            int trenutno;
            for (int i = 0; i < n; i++)
            {
                trenutno = 0;
                for (int j = 0; j < n; j++)
                    trenutno += MSTabla[j, i];
                sume[i] = trenutno;
            }
            return sume;
        }

        public int izracunajSumuGlavneDijagonale()
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
                sum += MSTabla[i, i];
            return sum;
        }

        public int izracunajSumuSporedneDijagonale()
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
                sum += MSTabla[i, n - 1 - i];
            return sum;
        }


        public string ispitajVrste()
        {
            string pogresne = "";
            int[] s = izracunajSumuVrsta();
            for (int i = 0; i < n; i++)
                if (s[i] != suma)
                {
                    pogresne += (i + 1).ToString();
                    pogresne += ", ";
                }
            if (pogresne.Equals(""))
                return "Suma u svim vrstama je tacna!";
            else
            {
                string prikaz = "Pogresna suma u vrstama: ";
                prikaz += pogresne;
                prikaz = prikaz.Remove(prikaz.Length - 2);
                prikaz += "!";
                return prikaz;
            }
        }


        public string ispitajKolone()
        {
            string pogresne = "";
            int[] s = izracunajSumuKolona();
            for (int i = 0; i < n; i++)
                if (s[i] != suma)
                {
                    pogresne += (i + 1).ToString();
                    pogresne += ", ";
                }
            if (pogresne.Equals(""))
                return "Suma u svim kolonama je tacna!";
            else
            {
                string prikaz = "Pogresna suma u kolonama: ";
                prikaz += pogresne;
                prikaz = prikaz.Remove(prikaz.Length - 2);
                prikaz += "!";
                return prikaz;
            }
        }

        public string ispitajGlavnuDijagonalu()
        {
            string pogresne = "";
            int s = izracunajSumuGlavneDijagonale();
            if (s == suma)
                return "Suma glavne dijagonale je tacna!";
            else
                return "Pogresna suma glavne dijagonale!";
        }


        public string ispitajSporednuDijagonalu()
        {
            string pogresne = "";
            int s = izracunajSumuSporedneDijagonale();
            if (s == suma)
                return "Suma sporedne dijagonale je tacna!";
            else
                return "Pogresna suma sporedne dijagonale!";
        }

        public void ispitajKraj()
        {
            string s1 = ispitajVrste();
            string s2 = ispitajKolone();
            string s3 = ispitajGlavnuDijagonalu();
            string s4 = ispitajSporednuDijagonalu();
            if (s1.Equals("Suma u svim vrstama je tacna!") && s2.Equals("Suma u svim kolonama je tacna!") && s3.Equals("Suma glavne dijagonale je tacna!") && s4.Equals("Suma sporedne dijagonale je tacna!"))
            {
                MessageBox.Show("Uspesno ste resili magicni kvadrat!", "CESTITAMO");
                label4.Text = (n * n + timeLeft).ToString();
                int sc = Int32.Parse(label4.Text);
            }
            else
            {
                string messageBox = "";
                if (!s1.Equals("Suma u svim vrstama je tacna!"))
                {
                    messageBox = string.Concat(messageBox, s1);
                }
                if (!s2.Equals("Suma u svim kolonama je tacna!"))
                {
                    messageBox = string.Concat(messageBox, "\n");
                    messageBox = string.Concat(messageBox, s2);
                }
                if (!s3.Equals("Suma glavne dijagonale je tacna!"))
                {
                    messageBox = string.Concat(messageBox, "\n");
                    messageBox = string.Concat(messageBox, s3);
                }
                if (!s4.Equals("Suma sporedne dijagonale je tacna!"))
                {
                    messageBox = string.Concat(messageBox, "\n");
                    messageBox = string.Concat(messageBox, s4);
                }
                MessageBox.Show(messageBox, "GRESKA");
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                string min = (timeLeft / 60).ToString();
                if (Int32.Parse(min) / 10 == 0)
                    min = "0" + min;
                string sec = (timeLeft % 60).ToString();
                if (Int32.Parse(sec) / 10 == 0)
                    sec = "0" + sec;
                label3.Text = min + ":" + sec;
            }
            else
            {
                timer.Stop();
                timer.Dispose();
                MessageBox.Show("Vase vreme je isteklo!", "GAME OVER");
                panel1.Controls.Clear();
                lblIgrac.Text = "Igrač ";
                igraPocela = false;
            }
        }

        private void newGame_Click(object sender, EventArgs e)
        {
            NovaIgra ng = new NovaIgra(this, Username);
            ng.ShowDialog();
            //Ovde se N i username setuje
            panel1.Controls.Clear();
            lblIgrac.Text = "Igrač " + Username;
            elementi = new int[N * N];
            for (int i = 0; i < N * N; i++)
            {
                elementi[i] = i + 1;
            }
            korisceniElementi = new List<int>();
            MSTabla = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    MSTabla[i, j] = 0;
                }
            }
            NapraviKockice(N);

            suma = (n * (n * n + 1)) / 2;

            igraPocela = true;
            string min = (timeLeft / 60).ToString();
            if (Int32.Parse(min) / 10 == 0)
                min = "0" + min;
            string sec = (timeLeft % 60).ToString();
            if (Int32.Parse(sec) / 10 == 0)
                sec = "0" + sec;
            label3.Text = min + ":" + sec;


            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = (1000) * (1);              // Timer otkucava na svaku sekundu
            timer.Enabled = true;
            timer.Start();

        }

        private void NapraviKockice(int n)
        {
            int lokX = 50;
            int lokY = 32;
            Random rnd = new Random();
            int boja = rnd.Next(0, 8);
            int size = 0;
            int FontSize = 0;
            int razmak = 0;
            switch (n)
            {
                case 3:
                    size = 140;
                    FontSize = 80;
                    razmak = 30;
                    timeLeft = 600;
                    break;
                case 4:
                    size = 105;
                    FontSize = 55;
                    razmak = 15;
                    timeLeft = 900;
                    break;
                case 5:
                    size = 85;
                    FontSize = 45;
                    razmak = 18;
                    timeLeft = 1200;
                    break;
                case 6:
                    size = 76;
                    FontSize = 42;
                    razmak = 7;
                    timeLeft = 1800;
                    break;
                case 7:
                    size = 66;
                    FontSize = 35;
                    razmak = 7;
                    timeLeft = 2400;
                    break;
                case 8:
                    size = 53;
                    FontSize = 30;
                    razmak = 9;
                    timeLeft = 3000;
                    break;
                case 9:
                    size = 48;
                    FontSize = 26;
                    razmak = 9;
                    timeLeft = 3599;
                    break;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    TextBox txt = new TextBox();
                    txt.ForeColor = Color.FromArgb(11, 51, 83);
                    txt.Font = new Font("Microsoft Sans Serif", FontSize);
                    txt.Location = new Point(lokX, lokY);
                    txt.Size = new System.Drawing.Size(size, size);
                    txt.BorderStyle = BorderStyle.None;
                    txt.TextAlign = HorizontalAlignment.Center;
                    if (n == 3)
                        txt.MaxLength = 1;
                    else
                        txt.MaxLength = 2;

                    txt.Tag = "i" + i.ToString() + "j" + j.ToString(); // za izvlacenje vrednosti

                    if (boja % 4 == 0)
                        txt.BackColor = Color.FromArgb(140, 168, 159);
                    if (boja % 4 == 1)
                        txt.BackColor = Color.FromArgb(218, 87, 100);
                    if (boja % 4 == 2)
                        txt.BackColor = Color.FromArgb(252, 194, 114);
                    if (boja % 4 == 3)
                        txt.BackColor = Color.FromArgb(236, 226, 208);


                    txt.TextChanged += new EventHandler(txtChanged);
                    txt.Leave += new EventHandler(txtLeave);

                    panel1.Controls.Add(txt);
                    boja = rnd.Next(0, 8);

                    lokX += size + razmak;
                    //lokY = 32;
                }

                lokX = 50;
                lokY += size + razmak / 2;
            }

        }

        private void txtLeave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            string tag = txt.Tag.ToString();
            string ii = tag.Substring(1, 1);
            string jj = tag.Substring(3, 1);

            int i = Convert.ToInt32(ii);
            int j = Convert.ToInt32(jj);

            if (MSTabla[i, j] != 0) // ako korisnik menja prethodno uneseni broj
            {
                korisceniElementi.Remove(MSTabla[i, j]);
            }

            int unetBr = 0;
            if (!String.IsNullOrEmpty(txt.Text))
            {
                unetBr = Convert.ToInt32(txt.Text);
                if (korisceniElementi.Contains(unetBr))
                {
                    MessageBox.Show("Unesite samo one brojeve koje niste prethodno koristili!", "POGRESAN UNOS");
                    txt.Text = "";
                    return;
                }
                korisceniElementi.Add(unetBr);


                if (korisceniElementi.Count == n * n)
                {
                    ispitajVrste();
                    ispitajKolone();
                    ispitajGlavnuDijagonalu();
                    ispitajSporednuDijagonalu();
                }

            }
            MSTabla[i, j] = unetBr;
        }

        private void txtChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            int unetBr = 0;
            if (!String.IsNullOrEmpty(txt.Text))
            {


                string last = txt.Text.Substring(txt.Text.Length - 1, 1);
                // MessageBox.Show(last);
                if (System.Text.RegularExpressions.Regex.IsMatch(last, "[^0-9]"))
                {
                    MessageBox.Show("Unesite samo brojeve!", "POGRESAN UNOS");
                    txt.Text = "";
                    return;
                }

                unetBr = Convert.ToInt32(txt.Text);
                if (!elementi.Contains(unetBr))
                {
                    MessageBox.Show("Unesite samo brojeve iz opsega 1 - " + (N * N).ToString() + "!", "POGRESAN UNOS");
                    txt.Text = "";
                    return;
                }
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Magični kvadrat je tablica popunjena brojevima od 1 do N^2 (gde je N velicina magicnog kvadrata) tako da zbir tih brojeva vertikalno, horizontalno i po dijagonalama bude isti. Svaki broj iz opsega 1-N^2 se sme upotrebiti samo jednom!" + "\n\n" + "Nakon sto resite magicni kvadrat kliknite na dugme REZULTAT da proverite da li ste uspesno resili." + "\n\n" + "SRECNO!", "PRAVILA IGRE");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (igraPocela == false)
                return;
            string s1 = ispitajVrste();
            string s2 = ispitajKolone();
            string s3 = ispitajGlavnuDijagonalu();
            string s4 = ispitajSporednuDijagonalu();
            if (s1.Equals("Suma u svim vrstama je tacna!") && s2.Equals("Suma u svim kolonama je tacna!") && s3.Equals("Suma glavne dijagonale je tacna!") && s4.Equals("Suma sporedne dijagonale je tacna!"))
            {
                MessageBox.Show("Uspesno ste resili magicni kvadrat!", "CESTITAMO");
                label4.Text = (n * n + timeLeft).ToString();
                int sc = Int32.Parse(label4.Text);
            }
            else
            {
                MessageBox.Show("Niste uspesno resili magicni kvadrat. Za pomoc, kliknite na dugme POMOĆ. Ako ne znate pravila igre, kliknite na dugme PRAVILA IGRE.", "PROBAJTE PONOVO");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Magični kvadrat je tablica popunjena brojevima od 1 do N^2 (gde je N velicina magicnog kvadrata) tako da zbir tih brojeva vertikalno, horizontalno i po dijagonalama bude isti. Svaki broj iz opsega 1-N^2 se sme upotrebiti samo jednom!" + "\n\n" + "Nakon sto resite magicni kvadrat kliknite na dugme REZULTAT da proverite da li ste uspesno resili." + "\n\n" + "SRECNO!", "PRAVILA IGRE");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblIgrac_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}