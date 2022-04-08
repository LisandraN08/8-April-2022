using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _8_April_2022
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public MySqlConnection sqlConnect = new MySqlConnection("server=localhost;uid=root;pwd=;database=premier_league");
        public MySqlCommand sqlCommand;
        public MySqlDataAdapter sqlAdapter;
        public string sqlQuery;

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dtTeam = new DataTable();
            sqlQuery = "SELECT team_name as 'Nama Tim', team_id as 'ID_Team' FROM team";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtTeam);
            cBoxTeam.DataSource = dtTeam;
            cBoxTeam.DisplayMember = "Nama Tim";
            cBoxTeam.ValueMember = "ID_Team";
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            sqlConnect.Open();
            sqlQuery = txtBoxQuery.Text;
            DataTable dtPlayer = new DataTable();
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtPlayer);
            dgvPlayer.DataSource = dtPlayer;
        }

        private void cBoxTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblValue.Text = cBoxTeam.SelectedValue.ToString();
            DataTable dtPlayer = new DataTable();
            sqlQuery = "SELECT * FROM player WHERE team_id = '" + cBoxTeam.SelectedValue.ToString() + "'";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtPlayer);
            dgvPlayer.DataSource = dtPlayer;
        }
    }
}
