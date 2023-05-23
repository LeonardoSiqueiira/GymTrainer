using GymProject.Funcoes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;

namespace GymProject
{
    public partial class Receita : Form
    {
        Func Con;
        public Receita()
        {
            InitializeComponent();
            Con = new Func();
            ShowReceita();
            GetReceita();
        }
        private void ShowReceita()
        {
            string Query = "select * from Receita";
            ReceitaList.DataSource = Con.GetData(Query);
        }
        private void GetReceita()
        {
            string Query = "select * from Clientes ";
            RecCli.DisplayMember = Con.GetData(Query).Columns["CliNome"].ToString();
            RecCli.ValueMember = Con.GetData(Query).Columns["CliId"].ToString();
            RecCli.DataSource = Con.GetData(Query);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Gerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (RecCli.Text == "" || ValorRec.Text == "")
                {
                    MessageBox.Show("Dados invalidos");
                }
                else
                {

                    string Cliente = RecCli.SelectedValue.ToString();
                    string Periodo = AfiliacaoRec.Text;
                    int Agent = Login.Id;
                    string Data = DataRec.Text;
                    string Valor = ValorRec.Text;
                    string Query = "insert into Receita values ('{0}','{1}','{2}','{3}', '{4}') ";
                    Query = string.Format(Query, Cliente, Periodo, Agent, Data, Valor);
                    Con.setData(Query);
                    ShowReceita();
                    MessageBox.Show("Dados inseridos!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            ValorRec.Text = "";
            RecCli.SelectedIndex = -1;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Trainer obj = new Trainer();
            obj.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Controle obj = new Controle();
            obj.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
