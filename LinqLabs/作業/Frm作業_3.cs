using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqLabs.作業
{
    public partial class Frm作業_3 : Form
    {
        public Frm作業_3()
        {
            InitializeComponent();

            //hint
            List<Student> students_scores = new List<Student>()
                                         {
                                            new Student{ Name = "aaa", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Male" },
                                            new Student{ Name = "bbb", Class = "CS_102", Chi = 80, Eng = 80, Math = 100, Gender = "Male" },
                                            new Student{ Name = "ccc", Class = "CS_101", Chi = 60, Eng = 50, Math = 75, Gender = "Female" },
                                            new Student{ Name = "ddd", Class = "CS_102", Chi = 80, Eng = 70, Math = 85, Gender = "Female" },
                                            new Student{ Name = "eee", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Female" },
                                            new Student{ Name = "fff", Class = "CS_102", Chi = 80, Eng = 80, Math = 80, Gender = "Female" },
                                            new Student{ Name = "ggg", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Male" },
                                            new Student{ Name = "hhh", Class = "CS_102", Chi = 60, Eng = 90, Math = 70, Gender = "Male" },
                                            new Student{ Name = "iii", Class = "CS_101", Chi = 40, Eng = 80, Math = 95, Gender = "Female" },
                                            new Student{ Name = "jjj", Class = "CS_102", Chi = 85, Eng = 50, Math = 75, Gender = "Female" },
                                            new Student{ Name = "kkk", Class = "CS_101", Chi = 65, Eng = 95, Math = 85, Gender = "Female" },
                                            new Student{ Name = "lll", Class = "CS_102", Chi = 87, Eng = 93, Math = 70, Gender = "Female" },
                                            new Student{ Name = "mmm", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Male" },
                                            new Student{ Name = "nnn", Class = "CS_102", Chi = 80, Eng = 80, Math = 100, Gender = "Male" },
                                            new Student{ Name = "ooo", Class = "CS_101", Chi = 60, Eng = 50, Math = 75, Gender = "Female" },
                                            new Student{ Name = "ppp", Class = "CS_102", Chi = 80, Eng = 70, Math = 85, Gender = "Female" },
                                            new Student{ Name = "qqq", Class = "CS_101", Chi = 85, Eng = 80, Math = 50, Gender = "Female" },
                                            new Student{ Name = "rrr", Class = "CS_102", Chi = 80, Eng = 8, Math = 80, Gender = "Female" },
                                            new Student{ Name = "sss", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Male" },
                                            new Student{ Name = "ttt", Class = "CS_102", Chi = 60, Eng = 90, Math = 70, Gender = "Male" },
                                            new Student{ Name = "uuu", Class = "CS_101", Chi = 40, Eng = 80, Math = 95, Gender = "Female" },
                                            new Student{ Name = "vvv", Class = "CS_102", Chi = 85, Eng = 50, Math = 75, Gender = "Female" },
                                            new Student{ Name = "www", Class = "CS_101", Chi = 65, Eng = 95, Math = 85, Gender = "Female" },
                                            new Student{ Name = "xxx", Class = "CS_102", Chi = 87, Eng = 93, Math = 70, Gender = "Female" },
                                            new Student{ Name = "yyy", Class = "CS_101", Chi = 65, Eng = 85, Math = 70, Gender = "Female" },
                                            new Student{ Name = "zzz", Class = "CS_102", Chi = 87, Eng = 90, Math = 50, Gender = "Female" },
                                          };
            _students_scores = students_scores;
        }
        List<Student> _students_scores;
        private void button36_Click(object sender, EventArgs e)
        {
            #region 搜尋 班級學生成績

            // 
            // 共幾個 學員成績 ?		
            MessageBox.Show($"共{_students_scores.Count}個學生成績");

            // 找出 前面三個 的學員所有科目成績					
         
            
            var q = _students_scores.Select( x => x ).ToList();
            dataGridView1.DataSource = q;

            List<Student> s2 = new List<Student>();

            for (int i = 0; i < 3; i++) 
            {
                s2.Add(_students_scores[i]);
            }
            dataGridView1.DataSource = s2.ToList();

            // 找出 後面兩個 的學員所有科目成績

            List<Student> s3 = new List<Student>();

            for (int i = 4; i < 6; i++)
            {
                s3.Add(_students_scores[i]);
            }
            dataGridView2.DataSource = s3.ToList();

            // 找出 Name 'aaa','bbb','ccc' 的學員國文英文科目成績						

            var q2 = _students_scores.Where(x => x.Name == "aaa" || x.Name == "bbb" || x.Name == "ccc").Select(x => new { x.Name, x.Chi });
            dataGridView3.DataSource = q2.ToList();

            // 找出學員 'bbb' 的成績	                          

            var q3 = _students_scores.Where(x=>x.Name == "bbb").Select(x=>x);
            dataGridView4.DataSource = q3.ToList();

            // 找出除了 'bbb' 學員的學員的所有成績 ('bbb' 退學)	

            var q4 = _students_scores.Where(x => x.Name != "bbb").Select(x => x);
            dataGridView5.DataSource = q4.ToList();

            // 找出 'aaa', 'bbb' 'ccc' 學員 國文數學兩科 科目成績  |				
            
            var q5 = _students_scores.Where(x => x.Name == "aaa"|| x.Name == "bbb"||x.Name == "ccc").Select(x => new {x.Name,x.Chi,x.Math });
            dataGridView6.DataSource = q5.ToList();
            // 數學不及格 ... 是誰 
            var q6 = _students_scores.Where(x => x.Math < 60).Select(x => x);
            dataGridView7.DataSource = q6.ToList();
            #endregion
        }

        private void button37_Click(object sender, EventArgs e)
        {
            //個人 sum, min, max, avg

            var q = _students_scores.Select(x => new
            {
                姓名 = x.Name,
                總計 = new Dictionary<string, int>
                {
                    {"Chi",x.Chi},
                    {"Eng",x.Eng},
                    {"Math",x.Math},
                }.Sum(a => a.Value),
                最低分 = new Dictionary<string, int>
                {
                    {"Chi",x.Chi},
                    {"Eng",x.Eng},
                    {"Math",x.Math},
                }.Min(a => a.Value),
                最高分 = new Dictionary<string, int>
                {
                    {"Chi",x.Chi},
                    {"Eng",x.Eng},
                    {"Math",x.Math},
                }.Max(a => a.Value),
                平均 = new Dictionary<string, int>
                {
                    {"Chi",x.Chi},
                    {"Eng",x.Eng},
                    {"Math",x.Math},
                }.Average(a => a.Value),
            });
            dataGridView8.DataSource = q.ToList();
            // 統計 每個學生個人成績 並排序
            var q2 = _students_scores.Select(x => new
            {
                姓名 = x.Name,
                性別 = x.Gender,
                班級 =x.Class,
                國文 = x.Chi,
                英文 = x.Eng,
                數學 = x.Math,
                總計 = new Dictionary<string, int>
                {
                    {"Chi",x.Chi},
                    {"Eng",x.Eng},
                    {"Math",x.Math},
                }.Sum(a => a.Value),
                最低分 = new Dictionary<string, int>
                {
                    {"Chi",x.Chi},
                    {"Eng",x.Eng},
                    {"Math",x.Math},
                }.Min(a => a.Value),
                最高分 = new Dictionary<string, int>
                {
                    {"Chi",x.Chi},
                    {"Eng",x.Eng},
                    {"Math",x.Math},
                }.Max(a => a.Value),
                平均 = new Dictionary<string, int>
                {
                    {"Chi",x.Chi},
                    {"Eng",x.Eng},
                    {"Math",x.Math},
                }.Average(a => a.Value),
            }).OrderByDescending(a => a.平均);
            dataGridView9.DataSource = q2.ToList();
        }
    }
}
