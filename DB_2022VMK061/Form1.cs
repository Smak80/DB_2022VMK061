using System.ComponentModel;

namespace DB_2022VMK061
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private BindingList<Student> students = new ();

        private string connStr =
            @"Data Source=SMAKNOVO\SQLEXPRESS;Initial Catalog=db09-063;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private void button1_Click(object sender, EventArgs e)
        {
            students.Clear();
            students.Add(new Student(1, "Иван", "Иванов", "09-060", 4.11, DateTime.Parse("2002-09-11"), true));
            students.Add(new Student(2, "Елизавета", "Петрова", "09-060", 3.71, DateTime.Parse("2003-03-04"), false));
            dataGridView1.DataSource = students;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            students[1].LastName = "Иванова";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (DBHelper.Connect(connStr))
                {
                    //DBHelper.CreateMainTable();
                    DBHelper.InsertData(students.ToArray());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Упс!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (DBHelper.Connect(connStr))
                {
                    students = DBHelper.GetData();
                    dataGridView1.DataSource=students;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Упс!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (DBHelper.Connect(connStr))
                {
                    DBHelper.CreateMainTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Упс!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}