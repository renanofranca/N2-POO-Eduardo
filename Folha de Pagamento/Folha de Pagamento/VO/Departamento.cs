using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha_de_Pagamento.Core;

namespace Folha_de_Pagamento
{
    public class Departamento
    {
        private int codigo;
        private string descricao;
        private int codigoGerente;


        public Departamento(int _codigo, string _descricao, int _codigoGerente)
        {
            Codigo = _codigo;
            Descricao = _descricao;
            CodigoGerente = _codigoGerente;
        }

        public int Codigo
        {
            get => codigo;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Código do Departamento não pode ser menor do que 0.");
                }
                codigo = value;
            }
        }

        public string Descricao
        {
            get => descricao;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Descricao esta vazia");
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

    }
}
