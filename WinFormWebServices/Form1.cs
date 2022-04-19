using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormWebServices
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
             - Web service'ler http protokolünü kullanarak hizmet sağlar
             - İstemci yani client istek atar ve bir geri dönüş gerçekleşir
             - Bu geri dönüşte kullanılan servise göre XML, JSON vb yapılar kıllanılır
             - Ve bilgi alışverişi sağlanmış olur.
             - Burada textboxlar üzerinden girilen veriler alınıp sorgulama yapılır ve geri dönüş olarak 
             true ya da false bir değer döndürülür.
             - Ayrıca projemize url ile service refenrence ekledik
             */

            long kimlikNo = long.Parse(txt_tc.Text);
            int yil = int.Parse(txt_yil.Text);
            bool durum;

            try
            {
                using (TcDogrula.KPSPublicSoapClient service = new TcDogrula.KPSPublicSoapClient { })
                {
                    durum = service.TCKimlikNoDogrula(kimlikNo, txt_isim.Text, txt_soyisim.Text, yil);
                }
            }
            catch (Exception)
            {
                throw;
            }

            MessageBox.Show(durum.ToString());
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
