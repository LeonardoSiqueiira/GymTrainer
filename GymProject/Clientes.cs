using GymProject.Funcoes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymProject
{
    public partial class Clientes : Form
    {
        Func Con;
        public Clientes()
        {
            InitializeComponent();
            Con = new Func();
            ShowClientes();
            GetPersonal();
            GetControle();
        }
        private void ShowClientes()
        {
            string Query = "select * from Clientes";
            CliList.DataSource = Con.GetData(Query);
        }

        private void Membros_Load(object sender, EventArgs e)
        {

        }
        private void GetPersonal()
        {
            string Query = "select * from Personal ";
            PersonalCliTxt.DisplayMember = Con.GetData(Query).Columns["PNome"].ToString();
            PersonalCliTxt.ValueMember = Con.GetData(Query).Columns["PId"].ToString();
            PersonalCliTxt.DataSource = Con.GetData(Query);
        }
        private void GetControle()
        {
            string Query = "select * from Controle ";
            ControlCliTxt.DisplayMember = Con.GetData(Query).Columns["CNome"].ToString();
            ControlCliTxt.ValueMember = Con.GetData(Query).Columns["CId"].ToString();
            ControlCliTxt.DataSource = Con.GetData(Query);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (NomeCliTxt.Text == "" || FoneCliTxt.Text == "" || SenhaCliTxt.Text == ""
                    || SexCliTxt.SelectedIndex == -1 || NascCliTxt.Text == "" || AssiCliTxt.Text == ""
                    || PersonalCliTxt.SelectedIndex == -1 || ControlCliTxt.SelectedIndex == -1 || AtiCliTxt.SelectedIndex == -1)
                {
                    MessageBox.Show("Dados invalidos");
                }
                else
                {
                    string CliNome = NomeCliTxt.Text;
                    string CliFone = FoneCliTxt.Text;
                    string CliSenha = SenhaCliTxt.Text;
                    string CliSex = SexCliTxt.SelectedItem.ToString();
                    string CliNasc = NascCliTxt.Text;
                    string CliAfiliado = AssiCliTxt.Text;
                    int CliPersonal = Convert.ToInt32(PersonalCliTxt.SelectedValue.ToString());
                    string CliStatus = AtiCliTxt.SelectedItem.ToString();
                    int CControle = Convert.ToInt32(ControlCliTxt.SelectedValue.ToString()); 

                    string Query = "insert into Clientes values ('{0}','{1}','{2}','{3}', '{4}','{5}', '{6}', '{7}', '{8}') ";
                    Query = string.Format(Query, CliNome, CliFone, CliSenha, CliSex, CliNasc, CliAfiliado, CliPersonal, CliStatus, CControle);
                    Con.setData(Query);
                    ShowClientes();
                    MessageBox.Show("Dados inseridos!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblPerso_Click(object sender, EventArgs e)
        {
            Trainer obj = new Trainer();
            obj.Show();
            this.Hide();
        }

        private void lblControle_Click(object sender, EventArgs e)
        {
            Controle obj = new Controle();
            obj.Show();
            this.Hide();
        }
    }
}
