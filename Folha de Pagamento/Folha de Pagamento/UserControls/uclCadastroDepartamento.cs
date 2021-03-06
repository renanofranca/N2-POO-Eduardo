﻿using System;
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

        /// <summary>
        /// Carrega os Controles da Tela
        /// </summary>
        private void CarregarItens()
        {
            CarregarComboGerente();
        }

        /// <summary>
        /// Carrega o ComboBox de Gerente
        /// </summary>
        private void CarregarComboGerente()
        {
            List<Funcionario> gerentes = Core.ControleDados.GetFuncionariosTipados(ControleDados.EnumTipoFuncionario.Gerente);

            foreach (Funcionario gerente in gerentes)
            {
                ComboBoxItem item = new ComboBoxItem((gerente.Codigo.ToString() + " - " + gerente.Nome), gerente.Codigo);

                cbxCodGerente.Items.Add(item);
            }
        }

        /// <summary>
        /// Limpa todos os campos do UserControl
        /// </summary>
        private void LimparCampos()
        {
            nudCodigo.Value = 0;
            cbxCodGerente.SelectedIndex = -1;
            txtDescricao.Text = "";
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            if(cbxCodGerente.SelectedItem == null)
                throw new Exception("Necessário selecionar um Gerente");

            int codigoDepartamento = Convert.ToInt16(nudCodigo.Value);
            string descricao = txtDescricao.Text;
            int codigoGerente = (int)(cbxCodGerente.SelectedItem as ComboBoxItem).Value;

            try
            {
                List<Departamento> departamentos = ControleDados.GetAllDepartamentos();

                foreach (Departamento dep in departamentos)
                {
                    if (dep.Codigo == codigoDepartamento)
                        throw new Exception("Código já existente");
                }

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
