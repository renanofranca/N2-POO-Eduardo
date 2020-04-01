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

namespace Folha_de_Pagamento.UserControls
{
    public partial class uclCadastroDepartamento : UserControl
    {
        public uclCadastroDepartamento()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Departamento d;
            try
            {
                int codigoDepartamento = Convert.ToInt16(nudCodigo.Value);
                string descricao = txtDescricao.Text;
                int codigoGerente = Convert.ToInt16(cbxCodGerente.SelectedItem);

                d = new Departamento(codigoDepartamento, descricao, codigoGerente);

                ControleDados.GravarDepartamento(d);
            }
            catch (FormatException)
            {
                MessageBox.Show("Informe valores de cadastro válidos", "Cadastro", MessageBoxButtons.OK);
                return;
            }
            MessageBox.Show("Novo Departamento cadastrado");
        }
    }
}
