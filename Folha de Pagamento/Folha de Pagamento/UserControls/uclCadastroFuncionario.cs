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
            rdbPercentual.Checked = true;
            CarregarItens();
        }

        /// <summary>
        /// Carrega os Controles da Tela
        /// </summary>
        private void CarregarItens()
        {
            CarregarComboDepartamentos();
        }

        /// <summary>
        /// Carrega o ComboBox de Departamentos
        /// </summary>
        private void CarregarComboDepartamentos()
        {
            List<Departamento> departamentos = Core.ControleDados.GetAllDepartamentos();

            foreach (Departamento departamento in departamentos)
            {
                ComboBoxItem item = new ComboBoxItem((departamento.Codigo.ToString() + " - " + departamento.Descricao), departamento.Codigo);

                cbxDepartamento.Items.Add(item);
            }
        }

        private void btnAplicarAumento_Click(object sender, EventArgs e)
        {
            if (rdbPercentual.Checked)
            {
                ControleFuncionarios.AplicarAumento(Convert.ToDouble(nudPercentualAumento.Value / 100), ControleFuncionarios.EnumTipoAumento.Percentual);
                MessageBox.Show("Aumento Aplicado com Sucesso");
                nudPercentualAumento.Value = 0;
                nudValorAumento.Value = 0;
            }
            else if (rdbValorFixo.Checked)
            {
                ControleFuncionarios.AplicarAumento(Convert.ToDouble(nudValorAumento.Value));
                MessageBox.Show("Aumento Aplicado com Sucesso");
                nudPercentualAumento.Value = 0;
                nudValorAumento.Value = 0;
            }
            else
                MessageBox.Show("Selecione uma forma de aumento");
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

        /// <summary>
        /// Limpa os controles da Tela
        /// </summary>
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

        /// <summary>
        /// Valida os dados que serão inseridos para o funcionario
        /// </summary>
        /// <returns></returns>
        private Funcionario GetFuncionarioValidado()
        {
            try
            {
                string cpf = txtCpf.Text;
                int codigo = Convert.ToInt32(nudCodigo.Value);
                DateTime dataNascimento = dtpNascimento.Value;
                int departamento = cbxDepartamento.SelectedItem == null? -1 : (int)(cbxDepartamento.SelectedItem as ComboBoxItem).Value; ;
                string nome = txtNome.Text;
                double salario = Convert.ToDouble(nudSalario.Value);
                char tipo;

                if (rbtnFuncionario.Checked)
                    tipo = 'F';
                else if(rbtnGerente.Checked)
                    tipo = 'G';
                else
                    tipo = ' ';

                List<Funcionario> funcionarios = ControleDados.GetAllFuncionarios();

                foreach (Funcionario f in funcionarios)
                {
                    if (f.Codigo == codigo)
                        throw new Exception("Código já existente");
                }

                if(tipo == 'F' && departamento == -1)
                    throw new Exception("Funcionario deve possuir departamento");
                
                return new Funcionario(codigo, nome, cpf, dataNascimento, salario, departamento, tipo);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            

        }

        private void rdbPercentual_CheckedChanged(object sender, EventArgs e)
        {
            BloquearNudAumento();
        }

        /// <summary>
        /// Bloqueia o controle de parametro de aumento que não será necessário.
        /// </summary>
        private void BloquearNudAumento()
        {
            if(rdbPercentual.Checked)
            {
                nudValorAumento.Enabled = false;
                nudPercentualAumento.Enabled = true;
            }
            if (rdbValorFixo.Checked)
            {
                nudValorAumento.Enabled = true;
                nudPercentualAumento.Enabled = false;
            }
        }

        private void rdbValorFixo_CheckedChanged(object sender, EventArgs e)
        {
            BloquearNudAumento();
        }
    }
}
