using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Folha_de_Pagamento
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            //Necessario carregar a cbxDepartamentos do cadastro de funcionarios com os 
            //departamentos cadastrados
        }
        List<Funcionario> funcionarios = new List<Funcionario>();
        private void Função_Enter(object sender, EventArgs e)
        {

        }

        private void Cadastro_Click(object sender, EventArgs e)
        {
            Funcionario f;

            try
            {
                int codigo = Convert.ToInt16(txtCodigo.Value);
                string nome = txtNomeFuncionario.Text;
                string cPF = txtCPF.Text;
                DateTime dataNascimento = Convert.ToDateTime(txtNascimento.Text);
                double salario = Convert.ToDouble(txtSalario.Text);

                char tipo = ' ';
                if (btnSelectFuncionario.Checked)
                    tipo = 'F';
                else if (btnSelectGerente.Checked)
                    tipo = 'G';

                int departamento = 1;
                if (btnSelectFuncionario.Checked)
                {
                    //aqui a cbxDepartamento precisa ter algum valor (nao obrigatorio para gerentes)
                }
                f = new Funcionario(codigo, nome, cPF, dataNascimento, salario, departamento, tipo);
            }
            catch(FormatException)
            {
                MessageBox.Show("Informe valores de cadastro válidos", "Cadastro", MessageBoxButtons.OK);
                return;
            }
            funcionarios.Add(f);

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
