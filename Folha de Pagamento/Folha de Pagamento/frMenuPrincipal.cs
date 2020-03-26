using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Folha_de_Pagamento
{
    public partial class frMenuPrincipal : Form
    {
        public frMenuPrincipal()
        {
            InitializeComponent();
            TratarArquivosTXT("Departamento.txt");
            TratarArquivosTXT("Funcionario.txt");
        }
        List<Funcionario> funcionarios = new List<Funcionario>();
        List<Departamento> departamentos = new List<Departamento>();
        private void Função_Enter(object sender, EventArgs e)
        {

        }
        #region
        /// <summary>
        /// Cadastro de Funcionarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cadastro_Click(object sender, EventArgs e)
        {
            Funcionario f;
            char tipo = ' ';
            try
            {
                int codigo = Convert.ToInt16(txtCodigo.Value);
                string nome = txtNomeFuncionario.Text;
                string cPF = txtCPF.Text;
                DateTime dataNascimento = Convert.ToDateTime(txtNascimento.Text);
                double salario = Convert.ToDouble(txtSalario.Text);
                int departamento = Convert.ToInt16(cbxDepartamentos.SelectedItem);

                if (btnSelectFuncionario.Checked)
                    tipo = 'F';
                else if (btnSelectGerente.Checked)
                    tipo = 'G';
                
                ChecarFuncaoFuncionario();

                f = new Funcionario(codigo, nome, cPF, dataNascimento, salario, departamento, tipo);
                if (tipo == 'G')
                    cbxCodigoGerente.Items.Add(codigo);
            }
            catch (FormatException)
            {
                MessageBox.Show("Informe valores de cadastro válidos", "Cadastro", MessageBoxButtons.OK);
                return;
            }
            funcionarios.Add(f);
            //adicionar no txt de funcionarios     
            MessageBox.Show("Novo usuario cadastrado");
        }
        /// <summary>
        /// Cadastro de Departamentos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Departamento d;
            try
            {
                int codigoDepartamento = Convert.ToInt16(txtCodigiDepartamento.Value);
                string descricao = txtDescricao.Text;
                int codigoGerente = Convert.ToInt16(cbxCodigoGerente.SelectedItem);

                d = new Departamento(codigoDepartamento, descricao, codigoGerente);
                cbxDepartamentos.Items.Add(codigoDepartamento);
            }
            catch (FormatException)
            {
                MessageBox.Show("Informe valores de cadastro válidos", "Cadastro", MessageBoxButtons.OK);
                return;
            }
            departamentos.Add(d);
            //adicionar no txt de funcionarios
            MessageBox.Show("Novo Departamento cadastrado");
        }
        #endregion

        private void label6_Click(object sender, EventArgs e)
        {

        }


        //---------------------------------METODOS
        private void TratarArquivosTXT(string nomeArquivo)
        {
            if (!File.Exists(nomeArquivo))
                File.Create(nomeArquivo).Close();
        }
        private void ChecarFuncaoFuncionario()
        {
            if (btnSelectFuncionario.Checked)
            {
                if (cbxDepartamentos.SelectedItem == null)
                {
                    MessageBox.Show("Informe um departamento para o funcionario");
                    return;
                }
            }
        }

        private void CarregarFuncionarioTXT()
        {

        }

       
    }
}
