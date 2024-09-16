using LinqLabs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Starter
{
    public partial class FrmLinq_To_Entity : Form
    {
        public FrmLinq_To_Entity()
        {
            InitializeComponent();
            Console.Write("XXX");
            dbcontext.Database.Log = Console.Write;
        }
        NorthwindEntities dbcontext = new NorthwindEntities();
        private void button1_Click(object sender, EventArgs e)
        {
           
            var q = from p in dbcontext.Products
                    where p.UnitPrice >30
                    select p;

            dataGridView1.DataSource = q.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var q = dbcontext.Categories.FirstOrDefault().Products;


            dataGridView1.DataSource = q.ToList();

            MessageBox.Show(dbcontext.Products.FirstOrDefault().Category.CategoryName);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            var q = dbcontext.Products.OrderByDescending(p => p.UnitsInStock).ThenByDescending(p => p.ProductID).Select(p => p);

            dataGridView1.DataSource = q.ToList();

            var q2 = from p in dbcontext.Products
                     orderby p.UnitsInStock descending, p.ProductID
                     select p;
            //dataGridView1.DataSource = q2.ToList();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            var q = from p in dbcontext.Products
                    join c in dbcontext.Categories
                    on p.CategoryID equals c.CategoryID
                    select new
                    {
                        c.CategoryName,
                        p.ProductID,
                        p.ProductName,
                        p.UnitPrice,
                        p.UnitsInStock
                    };

            dataGridView1.DataSource = q.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var q = dbcontext.Products.Select(p => new { p.Category.CategoryName, p.ProductID, p.ProductName, p.UnitPrice, p.UnitsInStock });
            dataGridView2.DataSource = q.ToList();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            var q = from c in dbcontext.Categories
                    from p in c.Products
                    select new
                    {
                        c.CategoryID,
                        c.CategoryName,
                        p.ProductID,
                        p.ProductName,
                        p.UnitPrice,
                        p.UnitsInStock
                    };
            dataGridView1.DataSource = q.ToList();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var q = dbcontext.Products.AsEnumerable().GroupBy(p => p.Category.CategoryName).Select(p => new
            {
                類別名 = p.Key,
                數量 = p.Count(),
                平均單價 = $"{p.Average(a => a.UnitPrice):c2}"
            }).ToList();

            dataGridView1.DataSource = q;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            var q = dbcontext.Orders.GroupBy(p => p.OrderDate.Value.Year).Select(a => new { 年分 = a.Key, 數量 = a.Count() });
            dataGridView1.DataSource = q.ToList();
        }

        private void button55_Click(object sender, EventArgs e)
        {
            Product product = new Product {ProductName ="XXX", Discontinued =true };

            dbcontext.Products.Add(product);
            dbcontext.SaveChanges();
        }

        private void button53_Click(object sender, EventArgs e)
        {
            Product p = dbcontext.Products.Where(x => x.ProductName == "XXX").FirstOrDefault();
            dbcontext.Products.Remove(p);

            dbcontext.SaveChanges();
        }

        private void button56_Click(object sender, EventArgs e)
        {
            Product p = dbcontext.Products.Where(x => x.ProductName == "XXX").FirstOrDefault();
            p.ProductName = "XYZ";

            dbcontext.SaveChanges();
        }
    }
}
