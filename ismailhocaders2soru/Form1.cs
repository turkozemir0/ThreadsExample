using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ismailhocaders2soru
{
    public partial class Form1 : Form
    {
        Thread islem1;
        Thread islem2;
        Thread islem3;
        Thread islem4;
        Thread islem5;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1.CheckForIllegalCrossThreadCalls = false;
            islem1 = new Thread(new ThreadStart(ogrenciuret));
            
            islem2 = new Thread(new ThreadStart(subeuret));
            
            islem3 = new Thread(new ThreadStart(bolumuret));
            islem1.Start();
            islem2.Start();
            islem3.Start();
        }
        int ogrno = 707001;
        string[] subeler = { "a", "b", "c", "d", "e" };
        string[] bolumler = { "elektronik", "bilgisayar", "elektrik", "matematik" };
        string[] bolumlerinkodlari = { "elektronik101", "bilgisayar101", "elektrik101", "matematik101" };
      //  string[] dersadlari = { "Adana 25.10.2001", "Balikesir 10.10.2000", "Erzurum 05.05.1999", "Adıyaman 01.01.1994" };
        string[] sehirler = { "Adana", "Balikesir", "Şırnak", "Adıyaman", "Hakkari", "Diyarbakır", "Muğla", "Aydın" };
        int[] dogumtarihleri = { 2021, 1999, 2000, 2003, 2004 };
        
        //listbox5 dyeri dogumtarihi
        void ogrenciuret()
        {
            while (true)
            {
                listBox1.Items.Add("2021"+ogrno++);
                Thread.Sleep(1000);
            }
        }
        void subeuret()
        {
            while (true)
            {
                foreach (var item in subeler)
                {
                    listBox2.Items.Add(item);
                    Thread.Sleep(1000);
                }
            }
        }
        
        void bolumuret()
        {
            while (true)
            {
                Random rnd = new Random();
                int sayi = rnd.Next(0, bolumler.Length);
                Random rnd2 = new Random();
                int sayi2 = rnd.Next(0, sehirler.Length);
                Random rnd3 = new Random();
                int sayi3 = rnd.Next(0, dogumtarihleri.Length);
                listBox3.Items.Add(bolumler[sayi]);
                listBox4.Items.Add(bolumlerinkodlari[sayi]);
                
                listBox5.Items.Add(sehirler[sayi2]+" "+dogumtarihleri[sayi3]);
                Thread.Sleep(1000);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            islem1.Abort();
            islem2.Abort();
            islem3.Abort();

        }



        //1 buton 2 listbox form load list box 100de n itibaren 1 er artarak listbox2de ise 115ten baslayip 15 er artsın buton tıkaldıgında isslem dursun
        //listbox 1 ve 2 deki sayilar esdeger hareket etmeli

        //5 listbox 1 button form load edildiği zaman
        //listbox1 içinde sayı değerleri 2021707001den baslasın ve 1 er 1 er artsın.
        //list box 2 içinde şube olarak a,b,c,d,e ye kadar dönsün
        //listbox3 içinde mekatronik bilgisayar elektrik elektronik bölümleri rastgele görüntülensin
        //listbox4 de gelen bölümegöre ders adı görüntülensin
    }
}
