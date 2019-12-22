using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace KTP01
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        //string[] Romanlar = { "DoktorUyku", "Paylaço", "Göçebe" };
        //string[] hikayeler = { "NasrettinHoca", "Keloğlan" };
        //string[] tarih = { "hürremsultan", "osmanlıtarihi" };
        int[] basım = {1960,1961,1962,1963,1964,1965,1966,1967,1968,1969,1970,1971,1972,1973,1974
        ,1975,1976,1977,1978,1979,1980,1981,1982,1983,1984,1985,1986,1987,1988,1989,1990,1991,1992
        ,1993,1994,1995,1996,1997,1998,1999,2000,2001,2002,2003,2004,2005,2006,2007,2008,2009};
        string[] tür = { "roman", "hikaye", "tarih", "şiir", "coğrafya", "jooloji", "ansiklobedi" };


        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add(basım);
            comboBox2.Items.AddRange(tür);
        }

        bool IsNull(Control control)
        {
            errorProvider1.Clear();
            string _error = $"{control.Name} Zorunlu alandır!".Replace("txt", "").Replace("cmb", "");

            if (control is TextBox)
            {
                TextBox txt = (TextBox)control;
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    errorProvider1.SetError(txt, _error);
                    return true;
                }
            }

            else if (control is ComboBox)
            {
                ComboBox cmb = (ComboBox)control;
                if (cmb.SelectedIndex == -1) 
                {
                    errorProvider1.SetError(cmb, _error);
                    return true;
                }
            }
            return false;
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            Class1 kütüp = new Class1();



            kütüp.yazaradı = textBox3.Text;
            kütüp.yayınevi = textBox2.Text;
            kütüp.kitapadı = textBox1.Text;
            kütüp.baskısayısı = numericUpDown1.Value.ToString();
            kütüp.yazarsayısı = numericUpDown2.Value.ToString();
            kütüp.basımyılı = comboBox1.Text;
            kütüp.tür = comboBox2.Text;
            kütüp.ısb = textBox4.Text;

            listBox1.Items.Add(kütüp);
            Temizle(this);

           
        }
        void Temizle(Control ctrl)
        {
            foreach (Control control in ctrl.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = "";
                }
                else if (control is ComboBox)
                {
                    ComboBox cmb = (ComboBox)control;
                    cmb.SelectedIndex = -1;
                }
                else if (control is GroupBox)
                {
                    Temizle(control);
                }
            }

        }

        private void yeniKitapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox3.Text = FakeData.NameData.GetFirstName();

            textBox4.Text = FakeData.PhoneNumberData.GetPhoneNumber();

        }



        Class1 güncellenecek;
        int index = 0;
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            index = listBox1.SelectedIndex;
            güncellenecek = (Class1)listBox1.SelectedItem;
            if (güncellenecek == null)
            {
                MessageBox.Show("Lütfen güncellenecek bir eleman seç.:-)");
                return;
            }

            textBox1.Text = güncellenecek.kitapadı;
            textBox2.Text = güncellenecek.yazaradı;
            textBox3.Text = güncellenecek.yayınevi;
            comboBox1.Text = güncellenecek.basımyılı;
            comboBox2.Text = güncellenecek.tür;
            textBox4.Text = güncellenecek.ısb;
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            if (güncellenecek == null)
            {
                MessageBox.Show("Lütfen günncellenecek bir kayıt seçiniz!");
                return;
            }

            güncellenecek.kitapadı = textBox1.Text;
            güncellenecek.yayınevi = textBox2.Text;
            güncellenecek.yazaradı = textBox3.Text;
            güncellenecek.tür = comboBox2.Text;
            güncellenecek.basımyılı = comboBox1.Text;
            güncellenecek.ısb = textBox4.Text;
            listBox1.Items.RemoveAt(index);
            listBox1.Items.Insert(index, güncellenecek);

            güncellenecek = null;
            Temizle(this);
        }

        private void sİLDELETEToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir eleman seçiniz!");
                return;
            }

            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
    }
    
 }

