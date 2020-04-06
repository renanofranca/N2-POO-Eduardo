using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Folha_de_Pagamento.VO;
using Folha_de_Pagamento.Core;

namespace Folha_de_Pagamento.UserControls
{
    public partial class uclCadastroFuncionario : UserControl
    {
        public uclCadastroFuncionario()
        {
            InitializeComponent();
            rbtnFuncionario.Checked = true;
        }

        private void CarregarItens()
        {
            CarregarComboDepartamentos();
        }

        private void CarregarComboDepartamentos()
        {
            List<Departamento> departamentos = Core.ControleDados.GetAllDepartamentos();

            foreach (Departamento departamento in departamentos)
            {
                ComboBoxItem item = new ComboBoxItem((departamento.Codigo.ToString() + " - " + departamento.Descricao), departamento.Codigo);

                cbxDepartamento.Items.Add(item);
            }



        }
        //precisa pegar da lista que ja existe dos funcionarios
        List<Funcionario> funcionarios = new List<Funcionario>();
        private void btnAplicarAumento_Click(object sender, EventArgs e)
        {
            //if (rdbPercentual.Checked)
            //    AplicarAumento(Convert.ToDouble(txtPercentualAumento), true);
            //else if (rdbValorFixo.Checked)
            //    AplicarAumento(Convert.ToDouble(txtValorAumento));
            //else
            //    MessageBox.Show("Selecione uma forma de aumento");

            //Precisa salvar a lista de funcionarios alterada no txt, porem agora estou com preguica
            //abraco
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Funcionario f = GetFuncionarioValidado();

            if (f != null)
            {
                Core.ControleDados.GravarFuncionario(f);
                MessageBox.Show("Cadastro Realizado com sucesso.");
                LimparDados();
            }
        }

        private void LimparDados()
        {
            txtCpf.Text = "";
            nudCodigo.Value = 0;
            dtpNascimento.Value = DateTime.Now;
            cbxDepartamento.SelectedItem = null;
            txtNome.Text = "";
            nudSalario.Value = 0;
            rbtnFuncionario.Checked = true;
        }

        private Funcionario GetFuncionarioValidado()
        {
            try
            {
                string cpf = txtCpf.Text;
                int codigo = Convert.ToInt32(nudCodigo.Value);
                DateTime dataNascimento = dtpNascimento.Value;
                int departamento = cbxDepartamento.SelectedItem == null? -1 : Convert.ToInt32(cbxDepartamento.SelectedItem);
                string nome = txtNome.Text;
                double salario = Convert.ToDouble(nudSalario.Value);
                char tipo;

                if (rbtnFuncionario.Checked)
                    tipo = 'F';
                else if(rbtnGerente.Checked)
                    tipo = 'G';
                else
                    tipo = ' ';

                return new Funcionario(codigo, nome, cpf, dataNascimento, salario, departamento, tipo);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            

        }
    }
}
