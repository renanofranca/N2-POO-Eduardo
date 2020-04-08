using Folha_de_Pagamento.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Folha_de_Pagamento.Forms
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
            tlpTelas.Controls.Clear();
            tlpTelas.Controls.Add(new uclInformacoesSistema());
            CorrigirTamanhoTela();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void tlpTelas_Resize(object sender, EventArgs e)
        {
            CorrigirTamanhoTela();
        }

        /// <summary>
        /// Corrige o tamanho do UserControl
        /// </summary>
        private void CorrigirTamanhoTela()
        {
            tlpTelas.Controls[0].Size = new Size(tlpTelas.Size.Width, tlpTelas.Size.Height);
        }

        private void btnCadastroFuncionario_Click(object sender, EventArgs e)
        {
            LimparTlpTelas();
            AdicionarTelaCadastroFuncionario();
            CorrigirTamanhoTela();
        }

        private void btnCadastroDepartamento_Click(object sender, EventArgs e)
        {
            LimparTlpTelas();
            AdicionarTelaCadastroDepartamento();
            CorrigirTamanhoTela();
        }

        private void btnListagem_Click(object sender, EventArgs e)
        {
            LimparTlpTelas();
            AdicionarTelaListagens();
            CorrigirTamanhoTela();
        }

        private void btnInfoSistema_Click(object sender, EventArgs e)
        {
            LimparTlpTelas();
            AdicionarTelaInfoSistema();
            CorrigirTamanhoTela();
        }

        /// <summary>
        /// Limpa o TableLayoutPanel para excluir os UserControls Existentes
        /// </summary>
        private void LimparTlpTelas()
        {
            tlpTelas.Controls.Clear();
        }

        /// <summary>
        /// Adiciona a UserControl de informações do sistema
        /// </summary>
        private void AdicionarTelaInfoSistema()
        {
            tlpTelas.Controls.Add(new uclInformacoesSistema());
        }

        /// <summary>
        /// Adiciona o UserControl de Controle de Funcionarios
        /// </summary>
        private void AdicionarTelaCadastroFuncionario()
        {
            tlpTelas.Controls.Add(new uclCadastroFuncionario());
        }

        /// <summary>
        /// Adiciona o UserControl de Controle de Departamento
        /// </summary>
        private void AdicionarTelaCadastroDepartamento()
        {
            tlpTelas.Controls.Add(new uclCadastroDepartamento());
        }

        /// <summary>
        /// Adiciona o UserControl de Tela de Listagens
        /// </summary>
        private void AdicionarTelaListagens()
        {
            tlpTelas.Controls.Add(new uclListagens());
        }

    }
}
