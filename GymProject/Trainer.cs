using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GymProject.Funcoes;

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
                if (PNome.Text == "" || PFone.Text == "" || PCREF.Text == "" || PSenha.Text == "" || PSex.SelectedIndex == -1 )
                {
                    MessageBox.Show("Dados Invalidos!");
                } else
                {
                    string PeNome = PNome.Text;
                    string PeCref = PCREF.Text;
                    string PeSex = PSex.SelectedIndex.ToString();
                    string PeFone = PFone.Text;
                    string PeSenha = PSenha.Text;
                    string Query = "insert into Personal values ('{0}', '{1}', '{2}', '{3}', '{4}')";
                    Query = string.Format(Query,PeNome, PeCref, PSex, PeFone, PeSenha );
                    Con.setData(Query);
                    MessageBox.Show("Personal Adicionado!");
                }
            } catch (Exception Ex){
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
