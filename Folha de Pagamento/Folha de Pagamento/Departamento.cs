using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha_de_Pagamento
{
    class Departamento
    {
        private int codigo;
        private string descricao;
        private int codigoGerente;

        public int Codigo { get; set; }
        public string Descricao
        {
            get => descricao;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    MessageBox.Show("Descricao esta vazia");
                    return;
                }
                descricao = value;

            }
        }
        public int CodigoGerente
        {
            get => codigoGerente;
            set
            {
                codigoGerente = value;
            }
        }

        public Departamento(int _codigo,string _descricao, int _codigoGerente)
        {
            Codigo = _codigo;
            Descricao = _descricao;
            CodigoGerente = _codigoGerente;
        }
    }
}
