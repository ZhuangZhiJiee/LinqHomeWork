using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace Starter
{
    public partial class FrmLangForLINQ : Form
    {
        public FrmLangForLINQ()
        {
            InitializeComponent();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int n1 = 100;
            int n2 = 200;


            MessageBox.Show($"{n1},{n2}");
            SwapAnyType(ref n1, ref n2);
            MessageBox.Show($"{n1},{n2}");
        }

        private void SwapAnyType<T>(ref T n1, ref T n2)
        {
            var temp = n2;
            n2 = n1;
            n1 = temp;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string s1 = "aaa";
            string s2 = "bbb";

            MessageBox.Show(s1 + "," + s2);
            SwapAnyType(ref s1, ref s2);
            MessageBox.Show(s1 + "," + s2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttonX.Click += ButtonX_Click;
            buttonX.Click += aaa;
            buttonX.Click += delegate (object sender1, EventArgs e1)
                                      {
                                          MessageBox.Show("匿名方法1.0");
                                      };
            buttonX.Click += (object sender1, EventArgs e1) =>
            {
                MessageBox.Show("匿名方法2.0");
            };
            buttonX.Click += (s1, e1) => MessageBox.Show("匿名方法3.0");

        }

        private void aaa(object sender, EventArgs e)
        {
            MessageBox.Show("aaa");
        }

        private void ButtonX_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" ButtonX_Click");
        }


        private bool Test(int n)
        {
            return n > 5;
        }
        private bool isEven(int n)
        {
            return n % 2 == 0;
        }
        private bool isOdd(int n)
        {
            return n % 2 == 1;
        }

        delegate bool MyDelegate(int n);

        private void button9_Click(object sender, EventArgs e)
        {
            //bool result= Test(3);

            MyDelegate md = new MyDelegate(Test);
            bool result;
            //===================================================================
            //result = md.Invoke(7);
            //MessageBox.Show($"{result}");
            //md += isEven;
            //result = md.Invoke(7);
            //MessageBox.Show($"{result}");
            //md += isOdd;
            //result = md.Invoke(7);
            //MessageBox.Show($"{result}");
            //===================================================================
            md = delegate (int n)
            {
                return n > 5;
            };

            result = md.Invoke(7);
            MessageBox.Show($"{result}");
            //======================================================================
            md = (int n) =>
            {
                return n > 5;
            };
            result = md.Invoke(3);
            MessageBox.Show($"{result}");
            //===========================================================================
            md = n => n > 5;

            result = md.Invoke(8);
            MessageBox.Show($"{result}");
        }

        List<int> MyWhere(int[] nums, MyDelegate md)
        {
            List<int> list = new List<int>();


            foreach (int n in nums)
            {
                if (md(n))
                {
                    list.Add(n);
                }
            }


            return list;

        }


        string s;
        private void button10_Click(object sender, EventArgs e)
        {
            MyDelegate md = isEven;

            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 16, 204 };
            List<int> returnlist = MyWhere(nums, md);

            List<int> methodList = MyWhere(nums, Test);

            List<int> oddList = MyWhere(nums, n => n % 2 == 1);

            List<int> EvevnList = MyWhere(nums, n => n % 2 == 0);

            foreach (int n in oddList)
            {
                listBox1.Items.Add(n);
            }
            foreach (int n in EvevnList)
            {
                listBox2.Items.Add(n);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //IEnumerable<int> q = from n in nums
            //        where n > 5
            //        select n;

            IEnumerable<int> q = nums.Where(n => n > 5);

            foreach (int n in q)
                listBox1.Items.Add(n);

            string[] words = { "aaa", "bbbbb", "cccc" };
            IEnumerable<string> q2 = words.Where(n => n.Length > 3);

            foreach (string n in q2)
                listBox2.Items.Add(n);
        }

        IEnumerable<int> MyIterator(int[] nums, MyDelegate md)
        {

            foreach (int n in nums)
            {
                if (md(n))
                {
                    yield return n;
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            IEnumerable<int> q = MyIterator(nums, n => n % 2 == 0);

            foreach (int n in q)
            {
                listBox1.Items.Add(n);
            }
        }

        private void button45_Click(object sender, EventArgs e)
        {
            var s = "abc";
            s = s.ToUpper();
            MessageBox.Show(s);

            var p = new Point(100, 200);
            MessageBox.Show($"x:{p.X},Y:{p.Y}");
        }

        private void button41_Click(object sender, EventArgs e)
        {
            MyPoint pt1 = new MyPoint();
            pt1.P1 = 100;
            pt1.P2 = 200;

            List<MyPoint> pointList = new List<MyPoint>();
            pointList.Add(pt1);
            pointList.Add(new MyPoint(11));
            pointList.Add(new MyPoint(22, 22));
            pointList.Add(new MyPoint { P1 = 33, P2 = 33 });
            pointList.Add(new MyPoint { P2 = 44 });


            dataGridView1.DataSource = pointList;

            //=================================================
            List<MyPoint> list2 = new List<MyPoint>
            {
                new MyPoint{ P1=56,P2=38 },
                new MyPoint{ P1=44,P2=113 },
                new MyPoint{ P1=58,P2=77},
                new MyPoint{ P1=85,P2=69}
            };
            dataGridView2.DataSource = list2;
        }


        class MyPoint
        {
            public MyPoint()
            {

            }
            public MyPoint(int p1)
            {
                P1 = p1;
            }
            public MyPoint(int p1, int p2)
            {
                P1 = p1;
                P2 = p2;
            }

            private int _P1;
            public int P1
            {
                get
                {
                    return _P1;
                }
                set { _P1 = value; }
            }
            public int P2 { get; set; }
            public int f1 = 999;
            public int f2 = 888;
        }

        private void button43_Click(object sender, EventArgs e)
        {
            var pt1 = new { P1 = 25, P2 = 33, P3 = 38 };
            var pt2 = new { P1 = 44, P2 = 36, P3 = 988 };
            var pt3 = new { X = 73, Y = 36 };

            //MessageBox.Show(pt1.P2.ToString());
            //MessageBox.Show(pt2.P3.ToString());
            //MessageBox.Show(pt3.Y.ToString());

            listBox1.Items.Add(pt1.GetType());
            listBox1.Items.Add(pt2.GetType());
            listBox1.Items.Add(pt3.GetType());


            //=============================================
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //var q = from n in nums
            //        where n > 5
            //        select new
            //        {
            //            N = n,
            //            Square = n * n,
            //            Cube = n * n * n
            //        };

            var q2 = nums.Where(x => x > 5).Select(x => new { N = x, Square = x * x, Cube = x * x * x });


            dataGridView1.DataSource = q2.ToList();

            productsTableAdapter1.Fill(nwDataSet1.Products);

            //var q3 = from p in nwDataSet1.Products
            //         where p.UnitPrice > 30
            //         select new
            //         {
            //             產品編號 = p.ProductID,
            //             產品名稱 = p.ProductName,
            //             產品單價 = p.UnitPrice.ToString("0"),
            //             庫存 = p.UnitsInStock,
            //             總價 = (p.UnitPrice * p.UnitsInStock).ToString("0")
            //         };

            var q4 = nwDataSet1.Products.Where(x => x.UnitPrice > 30).Select(x => new
            {
                產品編號 = x.ProductID,
                產品名稱 = x.ProductName,
                產品單價 = x.UnitPrice.ToString("0"),
                庫存 = x.UnitsInStock,
                總價 = (x.UnitPrice * x.UnitsInStock).ToString("0")
            }).ToList();
            dataGridView2.DataSource = q4;

        }

        private void button32_Click(object sender, EventArgs e)
        {
            string s = "abcde";

            int count = s.WordCount();

            char c = s.Chars(3);

            MessageBox.Show(count.ToString());
            MessageBox.Show(c.ToString());
        }

}
    public static class MyStringExtend
    {
        public static int WordCount(this string s)
        {
            return s.Length;
        }

        public static char Chars(this string s, int index) 
        {
            return s[index];
        }
    }
}
