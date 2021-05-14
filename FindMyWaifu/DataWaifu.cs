using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace FindMyWaifu
{
  public partial class DataWaifu : Form
  {
    static OleDbConnection conn;
    public DataWaifu()
    {
      InitializeComponent();
    }

    private void DataWaifu_Load(object sender, EventArgs e)
    {
      searchWaifu.Text = "";
      SelectCategory();
      catCombo.SelectedIndex = 0;
    }

    public void SelectCategory()
    {
      Dictionary<int, string> catList = new Dictionary<int, string>();
      catList.Add(0, "All Categories");

      string query = "select * from category";
      using (conn = new OleDbConnection(Config.connString))
      using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
      {
        conn.Open();
        DataTable category = new DataTable();
        adapter.Fill(category);

        foreach (DataRow catName in category.Rows)
          catList.Add(Int32.Parse(catName["ID"].ToString()), catName["name"].ToString());

        conn.Close();
      }
      catCombo.DisplayMember = "Value";
      catCombo.ValueMember = "Key";
      catCombo.DataSource = new BindingSource(catList, null);
    }

    private void AddWaifu()
    {
      using (WaifuFrm waifu = new WaifuFrm())
      {
        waifu.id = -1;
        if (catCombo.SelectedValue.ToString() != "0")
          waifu.id_category = Int32.Parse(catCombo.SelectedValue.ToString());
        else
          waifu.id_category = -1;

        waifu.FormClosed += WaifuClosed;
        waifu.ShowDialog();
      }
    }

    private void WaifuClosed(object sender, FormClosedEventArgs e)
    {
      GetDataWaifu();
    }

    private void CatClosed(object sender, FormClosedEventArgs e)
    {
      SelectCategory();
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      searchWaifu.Text = "";
      GetDataWaifu();

      bool checkCat = (catCombo.SelectedIndex != 0);
      editCatBtn.Enabled = checkCat;
      deleteCatBtn.Enabled = checkCat;
    }

    private void GetDataWaifu()
    {
      editWaifuBtn.Enabled = (WaifuList.SelectedItems.Count == 1);
      deleteWaifuBtn.Enabled = (WaifuList.SelectedItems.Count > 0);

      WaifuList.Items.Clear();
      string query = "SELECT w.ID, w.name, cj.categoryID, cj.webID, c.name AS category_name FROM";
      query += " ((waifu w INNER JOIN category_join cj ON w.ID = cj.waifuID)";
      query += " INNER JOIN category c ON cj.categoryID = c.ID)";
      bool catSelected = (catCombo.SelectedValue.ToString() != "0");
      string id_cat = ((KeyValuePair<int, string>)catCombo.SelectedItem).Key.ToString();

      if (catSelected)
        query += " WHERE cj.categoryID = @cid";

      if (searchWaifu.Text != "")
        query += ((catSelected) ? " AND" : " WHERE") + " LCASE([w.name]) LIKE @waifu";

      using (conn = new OleDbConnection(Config.connString))
      using (OleDbCommand com = new OleDbCommand(query, conn))
      using (OleDbDataAdapter adapter = new OleDbDataAdapter(com))
      {
        conn.Open();

        if (catCombo.SelectedValue.ToString() != "0")
          com.Parameters.AddWithValue("@cid", id_cat);

        if (searchWaifu.Text != "")
          com.Parameters.AddWithValue("@waifu", "%" + searchWaifu.Text.ToLower() + "%");

        DataTable waifus = new DataTable();
        adapter.Fill(waifus);

        int id_list = 1;
        foreach (DataRow waifu in waifus.Rows)
        {
          ListViewItem waifuItem = new ListViewItem(id_list++.ToString());
          waifuItem.SubItems.Add(waifu["name"].ToString());
          waifuItem.SubItems.Add(waifu["category_name"].ToString());
          WaifuList.Items.Add(waifuItem);
        }

        conn.Close();
      }
    }

    private void categoryCombo_Click(object sender, EventArgs e)
    {
      searchWaifu.Text = "";
      GetDataWaifu();
    }

    private void addWaifuBtn_Click(object sender, EventArgs e)
    {
      using (conn = new OleDbConnection(Config.connString))
      using (OleDbCommand com = new OleDbCommand("SELECT * from category", conn))
      {
        conn.Open();

        if (com.ExecuteScalar() == null)
        {
          DialogResult empty = MessageBox.Show("Category is empty, do you want to add a category?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
          if (empty == DialogResult.Yes)
          {
            using (CategoryFrm category = new CategoryFrm())
            {
              category.id = -1;
              category.FormClosed += CatClosed;
              category.ShowDialog();
            }
          }
          else
          {
            conn.Close();
            return;
          }

          conn.Close();
        }
      }
      AddWaifu();
    }

    private void searchWaifu_TextChanged(object sender, EventArgs e)
    {
      GetDataWaifu();
    }

    private void editCatBtn_Click(object sender, EventArgs e)
    {
      using (CategoryFrm category = new CategoryFrm())
      {
        category.id = ((KeyValuePair<int, string>)catCombo.SelectedItem).Key;
        category.categoryName = ((KeyValuePair<int, string>)catCombo.SelectedItem).Value;
        category.FormClosed += CatClosedEdit;
        category.ShowDialog();
        catCombo.SelectedValue = ((KeyValuePair<int, string>)catCombo.SelectedItem).Key;
      }
    }

    private void CatClosedEdit(object sender, FormClosedEventArgs e)
    {
      SelectCategory();
    }

    private void addCatBtn_Click(object sender, EventArgs e)
    {
      using (CategoryFrm category = new CategoryFrm())
      {
        category.id = -1;
        category.FormClosed += CatClosed;
        category.ShowDialog();

      }
    }

    private void deleteCatBtn_Click(object sender, EventArgs e)
    {
      DialogResult delete = MessageBox.Show("", "Deleting Category", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (delete == DialogResult.Yes)
      {
        string query = "";
        query = "DELETE cj.*, w.* FROM ((category c"
            + " INNER JOIN category_join cj ON c.ID = cj.categoryID)"
            + " INNER JOIN waifu w ON cj.waifuID = w.ID)"
            + " where c.ID = @cid";
        using (conn = new OleDbConnection(Config.connString))
        using (OleDbCommand com = new OleDbCommand(query, conn))
        {
          conn.Open();
          string cid = ((KeyValuePair<int, string>)catCombo.SelectedItem).Key.ToString();
          com.Parameters.AddWithValue("@cid", cid);
          com.ExecuteScalar();
          conn.Close();
        }

        query = "DELETE FROM category c"
            + " where c.ID = @cid";
        using (conn = new OleDbConnection(Config.connString))
        using (OleDbCommand com = new OleDbCommand(query, conn))
        {
          conn.Open();
          string cid = ((KeyValuePair<int, string>)catCombo.SelectedItem).Key.ToString();
          com.Parameters.AddWithValue("@cid", cid);
          com.ExecuteScalar();
          conn.Close();
        }

      catCombo.SelectedIndex = 0;
        SelectCategory();
        GetDataWaifu();
      }
    }

    private void editWaifuBtn_Click(object sender, EventArgs e)
    {
      using (WaifuFrm waifu = new WaifuFrm())
      {
        string name = WaifuList.SelectedItems[0].SubItems[1].Text;

        string query = "SELECT w.ID, w.name, cj.categoryID, cj.webID FROM";
        query += " (waifu w INNER JOIN category_join cj ON w.ID = cj.waifuID)";
        query += " where w.name = @name";

        using (conn = new OleDbConnection(Config.connString))
        using (OleDbCommand com = new OleDbCommand(query, conn))
        {
          conn.Open();
          com.Parameters.AddWithValue("@name", name);
          OleDbDataReader read = com.ExecuteReader(CommandBehavior.SingleRow);

          if (read.Read())
          {

            if (read["webID"].ToString() != "0")
            {
              MessageBox.Show("", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              return;
            }

            waifu.id = Int32.Parse(read["ID"].ToString());
            waifu.name = name;
            waifu.id_category = Int32.Parse(read["categoryID"].ToString());

            waifu.FormClosed += WaifuClosed;
            waifu.ShowDialog();
          }
          conn.Close();

        }

      }
    }

    private void WaifuList_SelectedIndexChanged(object sender, EventArgs e)
    {
      editWaifuBtn.Enabled = (WaifuList.SelectedItems.Count == 1);
      deleteWaifuBtn.Enabled = (WaifuList.SelectedItems.Count > 0);
    }

    private void deleteWaifuBtn_Click(object sender, EventArgs e)
    {
      DialogResult delete = MessageBox.Show("", "Deleting Category", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (delete == DialogResult.Yes)
      {
        foreach (ListViewItem item in WaifuList.SelectedItems)
          DeleteData(item.SubItems[1].Text);

        GetDataWaifu();
      }
    }

    private void DeleteData(string nama)
    {
      string query = "";
      query = "DELETE cj.* FROM (waifu w"
          + " INNER JOIN category_join cj ON w.ID = cj.waifuID)"
          + " where w.name = @name";
      using (conn = new OleDbConnection(Config.connString))
      using (OleDbCommand com = new OleDbCommand(query, conn))
      {
        conn.Open();
        com.Parameters.AddWithValue("@name", nama);
        com.ExecuteScalar();
        conn.Close();
      }

      query = "DELETE FROM waifu where name = @name";
      using (conn = new OleDbConnection(Config.connString))
      using (OleDbCommand com = new OleDbCommand(query, conn))
      {
        conn.Open();
        com.Parameters.AddWithValue("@name", nama);
        com.ExecuteScalar();
        conn.Close();
      }

    }

    private void ExportBtn_Click(object sender, EventArgs e)
    {
      using (SaveFileDialog save = new SaveFileDialog())
      {
        save.Title = "Export Data...";
        save.Filter = "Data Only|*.wif|Pack Data|*.wpk";
        save.ShowDialog();
        string location = save.FileName;

        if (location != "") 
          SaveData(location);

      }
    }

    private void SaveData(string location)
    {
      switch (Path.GetExtension(location))
      {
        case ".wif":
          
          break;
        case ".wpk":

          break;
      }
    }
  }
}
