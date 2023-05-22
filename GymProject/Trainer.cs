using GymProject.Funcoes;
using System;
using System.Windows.Forms;


namespace GymProject
{
    public partial class Trainer : Form
    {
        Func Con;

        
        public Trainer()
        {
            InitializeComponent();
            Con = new Func();
            ShowPersonal();
        }
        private void ShowPersonal()
        {
            string Query = "select * from Personal";
            PList.DataSource = Con.GetData(Query);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if(nomeTxt.Text == "" || crefTxt.Text == "" || sexTxt.SelectedIndex == -1 || foneTxt.Text == "" || senhaTxt.Text == "" || nascTxt.Text == "")
                {
                    MessageBox.Show("Dados invalidos");
                } else
                {
                    string PNome = nomeTxt.Text;
                    string PSex = sexTxt.SelectedItem.ToString();
                    string PCref = crefTxt.Text;
                    string PData = nascTxt.Text;
                    string PFone = foneTxt.Text;
                    string PSenha = senhaTxt.Text;
                    string Query = "insert into Personal values ('{0}','{1}','{2}','{3}', '{4}','{5}') ";
                    Query = string.Format(Query, PNome, PSex,PCref, PData, PFone, PSenha);
                    Con.setData(Query);
                    ShowPersonal();
                    MessageBox.Show("Dados inseridos!");
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int Key = 0;
        private void PList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            nomeTxt.Text = PList.SelectedRows[0].Cells[1].Value.ToString();
            sexTxt.SelectedItem = PList.SelectedRows[0].Cells[2].Value.ToString();
            crefTxt.Text = PList.SelectedRows[0].Cells[3].Value.ToString();
            nascTxt.Text = PList.SelectedRows[0].Cells[4].Value.ToString();
            foneTxt.Text = PList.SelectedRows[0].Cells[5].Value.ToString();
            senhaTxt.Text = PList.SelectedRows[0].Cells[6].Value.ToString();
            if(nomeTxt.Text == "")
            {
                Key = 0;
            } else
            {
                Key = Convert.ToInt32(PList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (Key == 0)
                {
                    MessageBox.Show("Selecione um Personal");
                }
                else
                {
                    string PNome = nomeTxt.Text;
                    string PSex = sexTxt.SelectedItem.ToString();
                    string PCref = crefTxt.Text;
                    string PData = nascTxt.Text;
                    string PFone = foneTxt.Text;
                    string PSenha = senhaTxt.Text;
                    string Query = "delete from Personal where PId = {0} ";
                    Query = string.Format(Query,Key);
                    Con.setData(Query);
                    ShowPersonal();
                    MessageBox.Show("Dados removidos!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (nomeTxt.Text == "" || crefTxt.Text == "" || sexTxt.SelectedIndex == -1 || foneTxt.Text == "" || senhaTxt.Text == "" || nascTxt.Text == "")
                {
                    MessageBox.Show("Dados invalidos");
                }
                else
                {
                    string PNome = nomeTxt.Text;
                    string PSex = sexTxt.SelectedItem.ToString();
                    string PCref = crefTxt.Text;
                    string PData = nascTxt.Text;
                    string PFone = foneTxt.Text;
                    string PSenha = senhaTxt.Text;
                    string Query = "update Personal set PNome = '{0}', PSex = '{1}', PCref = '{2}', PData = '{3}', PFone = '{4}', PSenha = '{5}' where PId = {6} ";
                    Query = string.Format(Query, PNome, PSex, PCref, PData, PFone, PSenha, Key);
                    Con.setData(Query);
                    ShowPersonal();
                    MessageBox.Show("Dados atualizados!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblClient_Click(object sender, EventArgs e)
        {
            Clientes obj = new Clientes();
            obj.Show();
            this.Hide();
        }

        private void lblControle_Click(object sender, EventArgs e)
        {
            Controle obj = new Controle();
            obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void nascTxt_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
