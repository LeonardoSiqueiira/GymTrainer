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
    public partial class Controle : Form
    {
        Func Con;
        public Controle()
        {
            InitializeComponent();
            Con = new Func();
            ShowControle();
        }
        private void ShowControle()
        {
            string Query = "select * from Controle";
            ConList.DataSource = Con.GetData(Query);
        }

        private void btnConSal_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConNomeTxt.Text == "" || ConTempoTxt.Text == "" || ConExerTxt.Text == "" || ConValorTxt.Text == "")
                {
                    MessageBox.Show("Dados invalidos");
                }
                else
                {
                    string CNome = ConNomeTxt.Text;
                    string CTempo = ConTempoTxt.Text;
                    string CExer = ConExerTxt.Text;
                    string CValor = ConValorTxt.Text;
                    string Query = "insert into Controle values ('{0}','{1}','{2}','{3}') ";
                    Query = string.Format(Query, CNome, CTempo, CExer, CValor);
                    Con.setData(Query);
                    ShowControle();
                    MessageBox.Show("Dados inseridos!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
            int Key = 0;
        private void ConList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ConNomeTxt.Text = ConList.SelectedRows[0].Cells[1].Value.ToString();
            ConTempoTxt.Text = ConList.SelectedRows[0].Cells[2].Value.ToString();
            ConExerTxt.Text = ConList.SelectedRows[0].Cells[3].Value.ToString();
            ConValorTxt.Text = ConList.SelectedRows[0].Cells[4].Value.ToString();
            if (ConNomeTxt.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ConList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        private void btnConEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConNomeTxt.Text == "" || ConTempoTxt.Text == "" || ConExerTxt.Text == "" || ConValorTxt.Text == "")
                {
                    MessageBox.Show("Dados invalidos");
                }
                else
                {
                    string CNome = ConNomeTxt.Text;
                    string CTempo = ConTempoTxt.Text;
                    string CExer = ConExerTxt.Text;
                    string CValor = ConValorTxt.Text;
                    string Query = "update Controle set CNome = '{0}', CTempo = '{1}', CExer = '{2}', CValor = '{3}' where CId = {4}";
                    Query = string.Format(Query, CNome, CTempo, CExer, CValor, Key);
                    Con.setData(Query);
                    ShowControle();
                    MessageBox.Show("Dados atualizados!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConExcl_Click(object sender, EventArgs e)
        {
            try
            {
                if (Key == 0)
                {
                    MessageBox.Show("Selecione um Exercicio!");
                }
                else
                {
                    string CNome = ConNomeTxt.Text;
                    string CTempo = ConTempoTxt.Text;
                    string CExer = ConExerTxt.Text;
                    string CValor = ConValorTxt.Text;
                    string Query = "delete from Controle where CId = {0}";
                    Query = string.Format(Query, Key);
                    Con.setData(Query);
                    ShowControle();
                    MessageBox.Show("Dados removidos!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblPersonal_Click(object sender, EventArgs e)
        {
            Trainer obj = new Trainer();
            obj.Show();
            this.Hide();
        }

        private void lblClient_Click(object sender, EventArgs e)
        {
            Controle obj = new Controle();
            obj.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
