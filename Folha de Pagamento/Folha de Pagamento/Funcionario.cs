using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Folha_de_Pagamento
{
    class Funcionario
    {
        private int codigo;
        private string nome;
        private string cpf;
        private DateTime dataNascimento;
        private double salario;
        private int departamento;
        private char tipo;

        public string Nome
        {
            get => nome;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    
                }

            }
        }
    }
}
