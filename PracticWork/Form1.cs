using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Runtime.CompilerServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

using dllMesage;

namespace PracticWork
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        SQLiteConnection baglan = new SQLiteConnection("Data source=PrakRab.db");

        public void listele()
        {
            baglan.Open();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("Select * From DBPrakRab", baglan);
            DataSet dset = new DataSet();
            adapter.Fill(dset, "info");
            dataGridView1.DataSource = dset.Tables[0];
            baglan.Close();

        }

        class DBconText
        {
            public DBcon DBcon { get; set; }
            public void showtext(string dbText)
            {
                DBcon = DBcon.getInstance(dbText);
            }
        }
        class DBcon
        {
            private static DBcon instance;

            public string ShowTextDB { get; private set; }

            protected DBcon(string showtextdb)
            {
                this.ShowTextDB = showtextdb;
            }

            public static DBcon getInstance(string showtextdb)
            {
                if (instance == null)
                    instance = new DBcon(showtextdb);
                return instance;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DBconText dbcontex = new DBconText();
            dbcontex.showtext("База данных PrakRab успешно подключена");
            MessageBox.Show(dbcontex.DBcon.ShowTextDB);
            listele();
        }

        private void Insert_btn_Click(object sender, EventArgs e) //Кнопка добавить
        {
            baglan.Open();
            string inventnum = Convert.ToString(inventnum_txt.Text);
            string fio = Convert.ToString(name_txt.Text);
            string depart = Convert.ToString(depart_txt.Text);
            string equip = Convert.ToString(equip_txt.Text);
            string condition = Convert.ToString(condition_txt.Text);
            string sql = "insert into DBPrakRab(InventoryNumber, FIO, Department, Equipment, Condition) Values ('" + inventnum + "', '" + fio + "' , '" + depart + "' , '" + equip + "', '" + condition + "')";
            SQLiteCommand komutislet = new SQLiteCommand(sql, baglan);
            komutislet.ExecuteNonQuery();
            baglan.Close();
            listele();
        }
        private void Update_Click(object sender, EventArgs e) //Кнопка изменить
        {
            baglan.Open();
            string inventnum = Convert.ToString(inventnum_txt.Text);
            string fio = Convert.ToString(name_txt.Text);
            string depart = Convert.ToString(depart_txt.Text);
            string equip = Convert.ToString(equip_txt.Text);
            string condition = Convert.ToString(condition_txt.Text);
            string sqlInvNumb = "UPDATE DBPrakRab SET InventoryNumber='" + inventnum + "'";
            string sqlFIO = "UPDATE DBPrakRab SET FIO='" + fio + "'";
            string sqlDepartment = "UPDATE DBPrakRab SET Department='" + depart + "'";
            string sqlEquipment = "UPDATE DBPrakRab SET Equipment='" + equip + "'";
            string sqlCondition = "UPDATE DBPrakRab SET Condition='" + condition + "'";
            SQLiteCommand komutisletInvNumb = new SQLiteCommand(sqlInvNumb, baglan);
            komutisletInvNumb.ExecuteNonQuery();
            SQLiteCommand komutisletFIO = new SQLiteCommand(sqlFIO, baglan);
            komutisletFIO.ExecuteNonQuery();
            SQLiteCommand komutisletDepartment = new SQLiteCommand(sqlDepartment, baglan);
            komutisletDepartment.ExecuteNonQuery();
            SQLiteCommand komutisletEquipment = new SQLiteCommand(sqlEquipment, baglan);
            komutisletEquipment.ExecuteNonQuery();
            SQLiteCommand komutisletCondition = new SQLiteCommand(sqlCondition, baglan);
            komutisletCondition.ExecuteNonQuery();
            baglan.Close();
            listele();
        }
        private void Delete_Click(object sender, EventArgs e) //Кнопка удалить
        {
            baglan.Open();
            string fio = Convert.ToString(name_txt.Text);
            string sql = "DELETE  FROM DBPrakRab WHERE FIO='"+fio+"'";
            SQLiteCommand komutislet = new SQLiteCommand(sql, baglan);
            komutislet.ExecuteNonQuery();
            baglan.Close();
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            inventnum_txt.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            name_txt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            depart_txt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            equip_txt.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            condition_txt.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void GetWarning_Click(object sender, EventArgs e)
        {
            MessageTitle messageTitle = new MessageTitle();
            messageTitle.getMessage();
        }
    }
}
