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
    public partial class uclListagens : UserControl
    {
        public uclListagens()
        {
            InitializeComponent();
            CarregarComboGerente();
            CarregarComboDepartamentos();
            cmbDepartamento.Enabled = false;
            cmbGerente.Enabled = false;
            cmbMes.Enabled = false;
        }

        private void BloquearParametrosDesnecessarios()
        {
            if (rbtnListGeral.Checked == true)
            {
                cmbDepartamento.Enabled = false;
                cmbGerente.Enabled = false;
                cmbMes.Enabled = false;
            }
            else if (rbtnListDep.Checked == true)
            {
                cmbDepartamento.Enabled = true;
                cmbGerente.Enabled = false;
                cmbMes.Enabled = false;
            }
            else if (rbtnListGer.Checked == true)
            {
                cmbDepartamento.Enabled = false;
                cmbGerente.Enabled = true;
                cmbMes.Enabled = false;
            }
            else if (rbtnListNasc.Checked == true)
            {
                cmbDepartamento.Enabled = false;
                cmbGerente.Enabled = false;
                cmbMes.Enabled = true;
            }
            else if (rbtnListTodosGer.Checked == true)
            {
                cmbDepartamento.Enabled = false;
                cmbGerente.Enabled = false;
                cmbMes.Enabled = false;
            }
        }

        private void rbtnListGeral_CheckedChanged(object sender, EventArgs e)
        {
            txtListagem.Text = "";
            BloquearParametrosDesnecessarios();
            txtListagem.Text = Listagens.ListagemGeral();
        }

        private void rbtnListDep_CheckedChanged(object sender, EventArgs e)
        {
            BloquearParametrosDesnecessarios();
        }

        private void rbtnListGer_CheckedChanged(object sender, EventArgs e)
        {
            BloquearParametrosDesnecessarios();
        }

        private void rbtnListNasc_CheckedChanged(object sender, EventArgs e)
        {
            BloquearParametrosDesnecessarios();
        }

        private void rbtnListTodosGer_CheckedChanged(object sender, EventArgs e)
        {
            BloquearParametrosDesnecessarios();
            Dictionary<string, bool> linhas = Listagens.ListagemTodosGerentes();

            foreach(KeyValuePair<string, bool> linha in linhas)
            {
                txtListagem.SelectionColor = linha.Value ? Color.Gold : Color.Black;
                txtListagem.AppendText(linha.Key);
            }
        }

        private void cmbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cmbMes.SelectedIndex + 1) > 0)
            {
                txtListagem.Text = "";
                txtListagem.Text = Listagens.ListagemMesAniversario(cmbMes.SelectedIndex + 1);
            }
        }

        private void cmbGerente_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtListagem.Text = "";
            txtListagem.Text = Listagens.ListagemGerente((int)(cmbGerente.SelectedItem as ComboBoxItem).Value);
        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtListagem.Text = "";
            txtListagem.Text = Listagens.ListagemDepartamento((int)(cmbDepartamento.SelectedItem as ComboBoxItem).Value);
        }

        private void CarregarComboDepartamentos()
        {
            List<Departamento> departamentos = Core.ControleDados.GetAllDepartamentos();

            foreach (Departamento departamento in departamentos)
            {
                ComboBoxItem item = new ComboBoxItem((departamento.Codigo.ToString() + " - " + departamento.Descricao), departamento.Codigo);

                cmbDepartamento.Items.Add(item);
            }
        }

        private void CarregarComboGerente()
        {
            List<Funcionario> gerentes = Core.ControleDados.GetFuncionariosTipados(ControleDados.EnumTipoFuncionario.Gerente);

            foreach (Funcionario gerente in gerentes)
            {
                ComboBoxItem item = new ComboBoxItem((gerente.Codigo.ToString() + " - " + gerente.Nome), gerente.Codigo);

                cmbGerente.Items.Add(item);
            }
        }
    }
}
