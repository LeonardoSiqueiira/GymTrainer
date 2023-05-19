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
                    MessageBox.Show("Dados inseridos!");
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
