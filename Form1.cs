using System;
using System.Drawing;
using System.Windows.Forms;

namespace SaveСкриншотКаждые5сек
{
    public partial class Form1 : Form
    {
        int i;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            i = 0;
            this.Text = "Запись каждые 5 секунд в файл";
            button1.Text = "Пуск";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            i = i + 1;
            this.Text = String.Format("Прошло {0} секунд", i);
            if (i >= 28) { timer1.Enabled = false; this.Close(); }
            Single Остаток = i % 5;
            if (Остаток != 0) return;
            SendKeys.Send("%{PRTSC}");
            var Получатель = Clipboard.GetDataObject();
            if (Получатель.GetDataPresent(DataFormats.Bitmap) == true)
            {
                var Объект = Получатель.GetData(DataFormats.Bitmap);
                var Растр = (Bitmap)Объект;
                var Имяфайла = String.Format(@"D:\Pic{0}.BMP", i / 5);
                Растр.Save(Имяфайла);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Text = String.Format("Прошло 0 секунд");
            timer1.Interval = 1000;
            timer1.Enabled = true;
        }
    }

}
