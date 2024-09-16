using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Starter
{
    public partial class FrmLINQ架構介紹_InsideLINQ : Form
    {
        public FrmLINQ架構介紹_InsideLINQ()
        {
            InitializeComponent();

            productsTableAdapter1.Fill(nwDataSet1.Products);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            ArrayList array = new ArrayList();
            array.Add(3);
            array.Add(12);


            var q = from n in array.Cast<int>()
                    where n > 3
                    select new {N=n};

            dataGridView1.DataSource = q.ToList();



            int[] nums = { 1, 2, 3 };

            //List<int> list = new List<int>();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var q = nwDataSet1.Products.OrderByDescending(x => x.UnitPrice).Select(x => x).Take(5);

            dataGridView1 .DataSource = q.ToList();
                    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            

            listBox1.Items.Add("總和:"+nums.Sum());
            listBox1.Items.Add("最大值:" + nums.Max());
            listBox1.Items.Add("最小值:" + nums.Min());
            listBox1.Items.Add("平均:" + nums.Average());
            listBox1.Items.Add("數量:" + nums.Count());
            //===========================================================
            listBox1.Items.Add("平均庫存量" + nwDataSet1.Products.Average(p => p.UnitsInStock));
            listBox1.Items.Add("最高單價" + nwDataSet1.Products.Max(p => p.UnitPrice));
        }
    }
}