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
            CarregarListaFuncionarios();
            CarregarListaDepartamentos();
        }
        List<Funcionario> funcionarios = new List<Funcionario>();
        List<Departamento> departamentos = new List<Departamento>();
        private void Função_Enter(object sender, EventArgs e)
        {

        }

        //Cadastros 
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
                string cpf = txtCPF.Text.Replace(",",".");
                DateTime dataNascimento = Convert.ToDateTime(txtNascimento.Text);
                double salario = Convert.ToDouble(txtSalario.Text);
                int departamento = Convert.ToInt16(cbxDepartamentos.SelectedItem);
        
                if (btnSelectFuncionario.Checked)
                    tipo = 'F';
                else if (btnSelectGerente.Checked)
                    tipo = 'G';

                //ChecarFuncaoFuncionario
                if (btnSelectFuncionario.Checked)
                {
                    if (cbxDepartamentos.SelectedItem == null)
                    {
                        MessageBox.Show("Informe um departamento para o funcionario");
                        return;
                    }
                }

                f = new Funcionario(codigo, nome, cpf, dataNascimento, salario, departamento, tipo);
                if (tipo == 'G')
                    cbxCodigoGerente.Items.Add(codigo);
                File.AppendAllText("Funcionario.txt", codigo + "|" + nome + "|" + cpf + "|" + dataNascimento + "|"
                                    + salario + "|" + departamento + "|" + tipo+"|"+Environment.NewLine);
            }
            catch (FormatException)
            {
                MessageBox.Show("Informe valores de cadastro válidos", "Cadastro", MessageBoxButtons.OK);
                return;
            }
            funcionarios.Add(f);     
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
                File.AppendAllText("Departamento.txt", codigoDepartamento + "|" + descricao + "|" 
                                    + codigoGerente +"|"+ Environment.NewLine);
            }
            catch (FormatException)
            {
                MessageBox.Show("Informe valores de cadastro válidos", "Cadastro", MessageBoxButtons.OK);
                return;
            }
            departamentos.Add(d);
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
        private void CarregarListaFuncionarios()
        {
            Funcionario f;
            // int qtdLinhas= File.ReadAllLines("Funcionario.txt").Count();
            string[] linhas = File.ReadAllLines("Funcionario.txt");

            foreach (string linha in linhas)
            {
                string[] dados =linha.Split('|');

                int codigo= Convert.ToInt16(dados[0]);
                string nome = dados[1];
                string cpf = dados[2];
                DateTime dataNascimento = Convert.ToDateTime(dados[3]);
                double salario = Convert.ToDouble(dados[4]);
                int departamento = Convert.ToInt16(dados[5]);
                char tipo = Convert.ToChar(dados[6]);

                f = new Funcionario(codigo, nome, cpf, dataNascimento, salario, departamento, tipo);
                funcionarios.Add(f);

                if (tipo == 'G')
                    cbxCodigoGerente.Items.Add(codigo);
            }
        }
        public void CarregarListaDepartamentos()
        {
            Departamento d;
            string[] linhas = File.ReadAllLines("Departamento.txt");

            foreach(string linha in linhas)
            {
                string[] dados = linha.Split('|');

                int codigoDepartamento = Convert.ToInt16(dados[0]);
                string descricao = dados[1];
                int codigoGerente = Convert.ToInt16(dados[2]);

                d = new Departamento(codigoDepartamento, descricao, codigoGerente);
                departamentos.Add(d);

                cbxDepartamentos.Items.Add(codigoDepartamento);

            }
        }

       
    }
}
