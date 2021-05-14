using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace FindMyWaifu
{
    public partial class WaifuFrm : Form
    {
        public int id;
        public int id_category;
        public string name;

        OleDbConnection conn;

        public WaifuFrm()
        {
            InitializeComponent();
        }

        private void WaifuFrm_Load(object sender, EventArgs e)
        {
            string query = "select * from category";

            using (conn = new OleDbConnection(Config.connString))
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
            {
                conn.Open();
                DataTable category = new DataTable();
                adapter.Fill(category);

                catCombo.DisplayMember = "name";
                catCombo.ValueMember = "ID";
                catCombo.DataSource = category;
                conn.Close();
            }

            if (id < 0)
            {
                this.Text = "Add Waifu";
                addBtn.Text = "Add";
            }
            else
            {
                Text = "Edit Waifu";
                addBtn.Text = "Edit";

                nameTxt.Text = name;
                txtImg.Text = Path.GetFileName(Path.Combine(Config.GetFolder(@"data\img\"), nameTxt.Text));
            }

            if (id_category >= 0)
                catCombo.SelectedValue = id_category;
            else
                catCombo.SelectedIndex = 0;

            checkData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (id < 0)
                AddData();
            else
                EditData();
            Close();
        }

        private void EditData()
        {
            string query = "";
            if (name != nameTxt.Text)
            {
                query = "select name from waifu where name = @name";

                using (conn = new OleDbConnection(Config.connString))
                using (OleDbCommand com = new OleDbCommand(query, conn))
                {
                    conn.Open();
                    com.Parameters.AddWithValue("@name", nameTxt.Text);
                    if (com.ExecuteScalar() != null)
                    {
                        MessageBox.Show(nameTxt.Text + " is Exsist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    conn.Close();
                }
            }

            if (txtImg.Text.Contains(@"\"))
            {
                string img = Path.Combine(Config.GetFolder(@"data\img\"), nameTxt.Text + Path.GetExtension(txtImg.Text));
                if (File.Exists(img))
                    File.Delete(img);

                File.Copy(txtImg.Text, img);
            }

            if (name != nameTxt.Text)
            {
                query = "update waifu set name = @Name where id = @id";

                using (conn = new OleDbConnection(Config.connString))
                using (OleDbCommand com = new OleDbCommand(query, conn))
                {
                    conn.Open();
                    com.Parameters.AddWithValue("@Name", nameTxt.Text);
                    com.Parameters.AddWithValue("@id", id);

                    com.ExecuteNonQuery();
                    conn.Close();
                }
            }

            if (id_category != Int32.Parse(catCombo.SelectedValue.ToString()))
            {

                query = "update category_join set categoryID = @cid where waifuID = @id";

                using (conn = new OleDbConnection(Config.connString))
                using (OleDbCommand com = new OleDbCommand(query, conn))
                {
                    conn.Open();
                    com.Parameters.AddWithValue("@cid", catCombo.SelectedValue.ToString());
                    com.Parameters.AddWithValue("@id", id);

                    com.ExecuteNonQuery();
                    conn.Close();
                }
            }

        }

        private void AddData()
        {
            string query = "";
            query = "select name from waifu where name = @name";

            using (conn = new OleDbConnection(Config.connString))
            using (OleDbCommand com = new OleDbCommand(query, conn))
            {
                conn.Open();
                com.Parameters.AddWithValue("@name", nameTxt.Text);
                if (com.ExecuteScalar() != null)
                {
                    MessageBox.Show(nameTxt.Text + " is Exsist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                conn.Close();
            }

            // Memindahkan gambar ke data
            if (txtImg.Text != "")
            {
                string img = Path.Combine(Config.GetFolder(@"data\img\"), nameTxt.Text + Path.GetExtension(txtImg.Text));
                if (File.Exists(img))
                    File.Delete(img);

                File.Copy(txtImg.Text, img);
            }

            // Add Waifu Data
            query = "insert into waifu (name) VALUES (@name)";
            int ID = 0;

            using (conn = new OleDbConnection(Config.connString))
            using (OleDbCommand com = new OleDbCommand(query, conn))
            {
                conn.Open();
                com.Parameters.AddWithValue("@name", nameTxt.Text);
                com.ExecuteNonQuery();
                if (id < 0)
                {
                    com.CommandText = "select @@Identity";
                    ID = (int)com.ExecuteScalar();
                }
                conn.Close();
            }

            query = "insert into category_join (waifuID, categoryID) VALUES (@wid, @cid)";
            using (conn = new OleDbConnection(Config.connString))
            using (OleDbCommand com = new OleDbCommand(query, conn))
            {
                conn.Open();
                com.Parameters.AddWithValue("@wid", ID.ToString());
                com.Parameters.AddWithValue("@cid", catCombo.SelectedValue.ToString());
                com.ExecuteScalar();
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog())
            {
                open.Title = "Open Image...";
                open.Filter = "All Supported Image|*.jpg;*.jpeg;*.png;*.gif";
                open.ShowDialog();
                if (open.FileName != "")
                {
                    txtImg.Text = open.FileName;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            checkData();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkData();
        }

        private void checkData()
        {
            if (id < 0)
            {
                addBtn.Enabled = nameTxt.Text != "";
            }
            else
            {
                if (name == nameTxt.Text && id_category == Int32.Parse(catCombo.SelectedValue.ToString()))
                    addBtn.Enabled = false;
                else
                    addBtn.Enabled = nameTxt.Text != "";
            }
        }
    }
}
