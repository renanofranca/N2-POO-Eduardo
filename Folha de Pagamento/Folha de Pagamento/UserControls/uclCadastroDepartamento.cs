using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Folha_de_Pagamento.Core;
using Folha_de_Pagamento.VO;

namespace Folha_de_Pagamento.UserControls
{
    public partial class uclCadastroDepartamento : UserControl
    {
        public uclCadastroDepartamento()
        {
            InitializeComponent();

            CarregarItens();
        }

        private void CarregarItens()
        {
            CarregarComboGerente();
        }

        private void CarregarComboGerente()
        {
            List<Funcionario> gerentes = Core.ControleDados.GetFuncionariosTipados(ControleDados.EnumTipoFuncionario.Gerente);

            foreach (Funcionario gerente in gerentes)
            {
                ComboBoxItem item = new ComboBoxItem((gerente.Codigo.ToString() + " - " + gerente.Nome), gerente.Codigo);

                cbxCodGerente.Items.Add(item);
            }
        }

        private void LimparCampos()
        {
            nudCodigo.Value = 0;
            cbxCodGerente.SelectedIndex = -1;
            txtDescricao.Text = "";
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            int codigoDepartamento = Convert.ToInt16(nudCodigo.Value);
            string descricao = txtDescricao.Text;
            int codigoGerente = (int)(cbxCodGerente.SelectedItem as ComboBoxItem).Value;

            try
            {
                Departamento d = new Departamento(codigoDepartamento, descricao, codigoGerente);

                ControleDados.GravarDepartamento(d);
                
                MessageBox.Show("Novo Departamento cadastrado");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                return;
            }
            LimparCampos();
        }
    }
}
