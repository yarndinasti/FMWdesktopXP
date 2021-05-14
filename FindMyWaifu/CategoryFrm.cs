using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace FindMyWaifu
{
    public partial class CategoryFrm : Form
    {
        public int id;
        public string categoryName;
        OleDbConnection conn;
        public CategoryFrm()
        {
            InitializeComponent();
        }

        private void CategoryFrm_Load(object sender, EventArgs e)
        {
            addBtn.Enabled = (textBox1.Text != "");
            if (id < 0)
            {
                this.Text = "Add Category";
                textBox1.Text = "";
                addBtn.Text = "Add";
            }
            else
            {
                this.Text = "Edit " + categoryName;
                textBox1.Text = categoryName;
                addBtn.Text = "Edit";
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string query = "";

            query = "select name from category where name = @name";

            using (conn = new OleDbConnection(Config.connString))
            using (OleDbCommand com = new OleDbCommand(query, conn))
            {
                conn.Open();
                com.Parameters.AddWithValue("@name", textBox1.Text);
                if (com.ExecuteScalar() != null)
                {
                    MessageBox.Show(textBox1.Text + " is Exsist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                conn.Close();
            }

            if (id < 0)
                query = "insert into category (name) VALUES (@CategoryName)";
            else
                query = "update category set name = @CategoryName where id = @id";

            using (conn = new OleDbConnection(Config.connString))
            using (OleDbCommand com = new OleDbCommand(query, conn))
            {
                conn.Open();
                com.Parameters.AddWithValue("@CategoryName", textBox1.Text);
                if (id >= 0)
                    com.Parameters.AddWithValue("@id", id);

                com.ExecuteNonQuery();
                conn.Close();
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            addBtn.Enabled = (textBox1.Text != "");
        }
    }
}
