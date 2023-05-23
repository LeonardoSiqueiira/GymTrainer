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
    public partial class Login : Form
    {
        Func Con;
        public Login()
        {
            InitializeComponent();
            Con = new Func();
        }
        public static int Id;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Adminlbl_Click(object sender, EventArgs e)
        {
            Trainer obj = new Trainer();
            obj.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UserLogin.Text == "" || UserSenha.Text == "")
            {
                MessageBox.Show("Dados invalidos!!!");
            } else
            {
                try
                {
                    string Query = "select * from Personal where PNome = '{0}' and PSenha = '{1}' ";
                    Query = string.Format(Query, UserLogin.Text, UserSenha.Text); 
                    DataTable dt = Con.GetData(Query);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Personal Invalido!!");
                    } else
                    {
                        Id = Convert.ToInt32(dt.Rows[0][0].ToString());
                        Clientes obj = new Clientes();
                        obj.Show();
                        this.Hide();
                    }

                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
