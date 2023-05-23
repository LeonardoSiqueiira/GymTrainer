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

        private void btnClitEditar_Click(object sender, EventArgs e)
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

                    string Query = "update  Clientes set CliNome = '{0}'," +
                        " CliFone = '{1}', CliSenha = '{2}', CliSex = '{3}'," +
                        " CliNasc = '{4}', CliAfiliado = '{5}', CliPersonal = '{6}', CliStatus = '{7}', CControle = '{8}' ";
                    Query = string.Format(Query, CliNome, CliFone, CliSenha, CliSex, CliNasc, CliAfiliado, CliPersonal, CliStatus, CControle, Key);
                    Con.setData(Query);
                    ShowClientes();
                    MessageBox.Show("Dados atualizados!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int Key = 0;
        private void CliList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NomeCliTxt.Text = CliList.SelectedRows[0].Cells[1].Value.ToString();
            FoneCliTxt.Text = CliList.SelectedRows[0].Cells[2].Value.ToString();
            SenhaCliTxt.Text = CliList.SelectedRows[0].Cells[3].Value.ToString();
            SexCliTxt.Text = CliList.SelectedRows[0].Cells[4].Value.ToString();
            NascCliTxt.Text = CliList.SelectedRows[0].Cells[5].Value.ToString();
            AssiCliTxt.Text = CliList.SelectedRows[0].Cells[6].Value.ToString();
            PersonalCliTxt.Text = CliList.SelectedRows[0].Cells[7].Value.ToString();
            AtiCliTxt.Text = CliList.SelectedRows[0].Cells[8].Value.ToString();
            ControlCliTxt.Text = CliList.SelectedRows[0].Cells[9].Value.ToString();
            if (NomeCliTxt.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CliList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCliExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (Key == 0)
                {
                    MessageBox.Show("Selecione um cliente");
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

                    string Query = " delete from Clientes where CliId = {0}  ";
                    Query = string.Format(Query, Key);
                    Con.setData(Query);
                    ShowClientes();
                    MessageBox.Show("Dados removidos!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PersonalCliTxt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }
    }
}
