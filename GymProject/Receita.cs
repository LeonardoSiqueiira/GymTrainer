using GymProject.Funcoes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            string Query = "select * from Receita ";
            ClienteRec.DisplayMember = Con.GetData(Query).Columns["Cliente"].ToString();
            ClienteRec.ValueMember = Con.GetData(Query).Columns["RecId"].ToString();
            ClienteRec.DataSource = Con.GetData(Query);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Gerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClienteRec.Text == "" || ValorRec.Text == "")
                {
                    MessageBox.Show("Dados invalidos");
                }
                else
                {
                    string Cliente = ClienteRec.SelectedValue.ToString();
                    string Periodo = AfiliacaoRec.Value.Date.Month + "-" + AfiliacaoRec.Value.Date.Year;
                    int Agent = Login.Id;
                    string Data = DataRec.Value.Date.ToString();
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
    }
}
