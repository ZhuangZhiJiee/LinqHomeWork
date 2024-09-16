using LinqLabs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHomeWork
{
    public partial class Frm作業_2 : Form
    {
        public Frm作業_2()
        {
            InitializeComponent();
            productPhotoTableAdapter1.Fill(awDataSet1.ProductPhoto);
            IEnumerable<int> q = awDataSet1.ProductPhoto.Select(x => x.ModifiedDate.Year).Distinct();
            foreach (var y in q) 
            {
                _years.Add(y);
                comboBox3.Items.Add(y);
            }
            comboBox3.Text = _years[0].ToString();

        }

        int index = -1;
        List<byte[]> picturelist = new List<byte[]>();
        List<int> _years = new List<int>();
        private void button11_Click(object sender, EventArgs e)
        {
  
            var q = from p in awDataSet1.ProductPhoto
                    orderby p.ModifiedDate
                    select new
                    {
                        產品ID = p.ProductPhotoID,
                        圖片 = p.ThumbNailPhoto,
                        圖片檔名 = p.ThumbnailPhotoFileName,
                        大圖 = p.LargePhoto,
                        大圖檔名 = p.LargePhotoFileName,
                        修改日期 = p.ModifiedDate
                    };

            var bycleList = q.ToList();

            foreach (var n in bycleList) 
            {
                picturelist.Add(n.大圖);
            }

            dataGridView1.DataSource = q.ToList();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //index = e.RowIndex;

            //byte[] photobyte = picturelist[index];

            //Stream imagestream = new MemoryStream(photobyte);
            //pictureBox1.Image = Bitmap.FromStream(imagestream);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            DateTime d1 = dateTimePicker1.Value;
            DateTime d2 = dateTimePicker2.Value;

            var q = from p in awDataSet1.ProductPhoto
                    where p.ModifiedDate >= d1 && p.ModifiedDate <= d2
                    orderby p.ModifiedDate
                    select new 
                    {
                        產品ID = p.ProductPhotoID,
                        圖片 = p.ThumbNailPhoto,
                        圖片檔名 = p.ThumbnailPhotoFileName,
                        大圖 = p.LargePhoto,
                        大圖檔名 = p.LargePhotoFileName,
                        修改日期 = p.ModifiedDate
                    };

            dataGridView1.DataSource = q.ToList();
                   
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            int year = Convert.ToInt32(comboBox3.Text);

            var q = from p in awDataSet1.ProductPhoto
                    where p.ModifiedDate.Year == year
                    select new
                    {
                        產品ID = p.ProductPhotoID,
                        圖片 = p.ThumbNailPhoto,
                        圖片檔名 = p.ThumbnailPhotoFileName,
                        大圖 = p.LargePhoto,
                        大圖檔名 = p.LargePhotoFileName,
                        修改日期 = p.ModifiedDate
                    };
            dataGridView1.DataSource = q.ToList();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            int year = Convert.ToInt32(comboBox3.Text);

            var q = from p in awDataSet1.ProductPhoto
                    where p.ModifiedDate.Year == year
                    select p;

            if (comboBox2.Text == "第一季")
            {
                var q2 = from p in q
                         where p.ModifiedDate.Month == 1 || p.ModifiedDate.Month == 2 || p.ModifiedDate.Month == 3
                         select new
                         {
                             產品ID = p.ProductPhotoID,
                             圖片 = p.ThumbNailPhoto,
                             圖片檔名 = p.ThumbnailPhotoFileName,
                             大圖 = p.LargePhoto,
                             大圖檔名 = p.LargePhotoFileName,
                             修改日期 = p.ModifiedDate
                         };
                dataGridView1.DataSource = q2.ToList();
                MessageBox.Show($"有{q2.Count()}筆");
            }
            else if (comboBox2.Text == "第二季")

            {
                var q2 = from p in q
                         where p.ModifiedDate.Month == 4 || p.ModifiedDate.Month == 5 || p.ModifiedDate.Month == 6
                         select new
                         {
                             產品ID = p.ProductPhotoID,
                             圖片 = p.ThumbNailPhoto,
                             圖片檔名 = p.ThumbnailPhotoFileName,
                             大圖 = p.LargePhoto,
                             大圖檔名 = p.LargePhotoFileName,
                             修改日期 = p.ModifiedDate
                         };
                dataGridView1.DataSource = q2.ToList();
                MessageBox.Show($"有{q2.Count()}筆");
            }
            else if (comboBox2.Text == "第三季")

            {
                var q2 = from p in q
                         where p.ModifiedDate.Month == 7 || p.ModifiedDate.Month == 8 || p.ModifiedDate.Month == 9
                         select new
                         {
                             產品ID = p.ProductPhotoID,
                             圖片 = p.ThumbNailPhoto,
                             圖片檔名 = p.ThumbnailPhotoFileName,
                             大圖 = p.LargePhoto,
                             大圖檔名 = p.LargePhotoFileName,
                             修改日期 = p.ModifiedDate
                         };
                dataGridView1.DataSource = q2.ToList();
                MessageBox.Show($"有{q2.Count()}筆");
            }
            else
            {
                var q2 = from p in q
                         where p.ModifiedDate.Month == 10 || p.ModifiedDate.Month == 11 || p.ModifiedDate.Month == 12
                         select new
                         {
                             產品ID = p.ProductPhotoID,
                             圖片 = p.ThumbNailPhoto,
                             圖片檔名 = p.ThumbnailPhotoFileName,
                             大圖 = p.LargePhoto,
                             大圖檔名 = p.LargePhotoFileName,
                             修改日期 = p.ModifiedDate
                         };
                dataGridView1.DataSource = q2.ToList();
                MessageBox.Show($"有{q2.Count()}筆");
            }
        }
    }
}
