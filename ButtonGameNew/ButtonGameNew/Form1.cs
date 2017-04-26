using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ButtonGameNew
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        List<Image> _imageList;
        int _counter = 0 , firstNo = 0 , secondNo = 0 , point = 0;
        bool _butonAvaliable = false;
        String pointStr = "Score: ";
        Image i0 , i1, i2, i3, i4, i5, i6, i7, i8, i9, i10, i11, i12, i13, i14, i15, i16, i17, i18, i19, i20;

        public Form1()
        {
            InitializeComponent();
            this.Width = 1100;
            this.Height = 900;
        }

        private void Form1_Load(object sender, EventArgs e)          //form açılırken yapılacak işlemler
        {

            SetButtonImages();

            for (int i = 1; i < 6; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    _counter++;
                    Button btn = new Button();
                    btn.Name = "btn" + _counter;
                    btn.Tag = _counter;
                    btn.Size = new Size(150, 150);
                    btn.Location = new Point(155 * i, 155 * j);
                    btn.BackgroundImage = i0;

                    this.Controls.Add(btn);
                    btn.Click += Btn_Click;

                 

                    
                }
            }

            ChangeLocation();
            lblPoints.Text = pointStr + point;
        }
        
        public void SetButtonImages()                        // imageleri ekleme yeri
        {

            _imageList = new List<Image>();

            i0 = ButtonGameNew.Properties.Resources.lol;
            i1 = ButtonGameNew.Properties.Resources.jinx;
            i2 = ButtonGameNew.Properties.Resources.kata;
            i3 = ButtonGameNew.Properties.Resources.leesin;
            i4 = ButtonGameNew.Properties.Resources.mf;
            i5 = ButtonGameNew.Properties.Resources.morgana;
            i6 = ButtonGameNew.Properties.Resources.rammus;
            i7 = ButtonGameNew.Properties.Resources.riven;
            i8 = ButtonGameNew.Properties.Resources.thresh;
            i9 = ButtonGameNew.Properties.Resources.varus;
            i10 = ButtonGameNew.Properties.Resources.zerat;
            i11 = ButtonGameNew.Properties.Resources.jinx1;
            i12 = ButtonGameNew.Properties.Resources.kata1;
            i13 = ButtonGameNew.Properties.Resources.leesin1;
            i14 = ButtonGameNew.Properties.Resources.mf1;
            i15 = ButtonGameNew.Properties.Resources.morgana1;
            i16 = ButtonGameNew.Properties.Resources.rammus1;
            i17 = ButtonGameNew.Properties.Resources.riven1;
            i18 = ButtonGameNew.Properties.Resources.thresh1;
            i19 = ButtonGameNew.Properties.Resources.varus1;
            i20 = ButtonGameNew.Properties.Resources.zerat1;

            _imageList.Add(i0);
            _imageList.Add(i1);
            _imageList.Add(i2);
            _imageList.Add(i3);
            _imageList.Add(i4);
            _imageList.Add(i5);
            _imageList.Add(i6);
            _imageList.Add(i7);
            _imageList.Add(i8);
            _imageList.Add(i9);
            _imageList.Add(i10);
            _imageList.Add(i11);
            _imageList.Add(i12);
            _imageList.Add(i13);
            _imageList.Add(i14);
            _imageList.Add(i15);
            _imageList.Add(i16);
            _imageList.Add(i17);
            _imageList.Add(i18);
            _imageList.Add(i19);
            _imageList.Add(i20);

        } 
        
          private void Btn_Click(object sender, EventArgs e)   //Buton tıklama yeri ve imageleri atama yeri
        {
            int number = (int)((Button)sender).Tag;
            ((Button)sender).BackgroundImage = _imageList[number];

            if (_butonAvaliable == false)              // ilk butonu alma metotu
            {
               firstNo = FirstButton(number);
            }
            else                                         // ikinci butonu alma metodu
            {
                
                secondNo = SecondButton(number);
                CompareNumbers(firstNo,secondNo);        //buton kıyaslama metodu
            }

        }
        private int FirstButton(int number)
        {
            _butonAvaliable = true;
            return number;
        }

        private int SecondButton(int number)
        {
            _butonAvaliable = false;
            return number;
        }

        private void CompareNumbers(int number1, int number2)
        {
            int n1 = number1;
            int n2 = number2;

            if (n1 == n2 + 10 || n1 == n2 - 10)                               //butonlar aynıysa yapılan işlemler
            {
                point = point + 10;
                lblPoints.Text = pointStr + point;
                int finalGame = 0;
                for (int i = 1; i < 21; i++)                             //oyun bittiyse yapılan işlemler
                {
                    if (this.Controls["btn" + i].BackgroundImage != i0)
                    {
                        finalGame++;
                    }

                    if (finalGame == 20)
                    {
                        MessageBox.Show("TEBRİKLER!");
                    }
                    
                } 

            }
            else
            {
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)                     //buton farklıysa yapılan işlemler
        {
            timer1.Stop();
            this.Controls["btn" + firstNo].BackgroundImage = i0;
            this.Controls["btn" + secondNo].BackgroundImage = i0;

         
        }

        private void ChangeLocation()                                     //butonların yerini değiştirme metodu
        {
            int[] randomArray = new int[20];
            int rndNumber = 0;
            for (int k = 0; k<20; k++){ randomArray[k] = 0; }
            int i = 0;
            while(true)
            {
                rndNumber = rnd.Next(1, 21);
                for (int j = 0; j < 20; j++)
                {
                    if (rndNumber != randomArray[j])
                    {
                        randomArray[i] = rndNumber;
                        i++;
                        break;
                    }
                }

                if (i == 20)
                {
                    break;
                }
            }

            for (i = 0; i < 20; i = i + 2)
            {
                System.Drawing.Point temp = this.Controls["btn" + randomArray[i]].Location;
                this.Controls["btn" + randomArray[i]].Location = this.Controls["btn" + randomArray[i + 1]].Location;
                this.Controls["btn" + randomArray[i + 1]].Location = temp;
            }
        }
    }
}