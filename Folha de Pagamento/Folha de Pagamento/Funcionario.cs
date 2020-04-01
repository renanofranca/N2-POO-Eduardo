using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Folha_de_Pagamento
{
    public class Funcionario
    {
        
        private string nome;
        private string cpf;
        private DateTime dataNascimento;
        private double salario;
        private char tipo;

        public Funcionario(int _codigo,string _nome, string _cpf, DateTime _dataNascimento, double _salario, int _departamento, char _tipo)
        {
            Codigo = _codigo;
            Nome = _nome;
            CPF = _cpf;
            DataNascimento = _dataNascimento;
            Salario = _salario;
            Departamento = _departamento;
            Tipo = _tipo;
        }


        public int Codigo { get; set; }
        public int Departamento { get; set; }
        public string Nome
        {
            get => nome;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    MessageBox.Show("Nome obrigatório");
                    return;
                }

                nome = value;
            }
        }
        public string CPF
        {
            get => cpf;
            set
            {
                if(value.Length != 14)
                {
                    MessageBox.Show("CPF inválido");
                    return;
                }
                cpf = value;
            }
        }

        public DateTime DataNascimento
        {
            get => dataNascimento;
            set
            {
                if (value > DateTime.Now)
                {
                    MessageBox.Show("Data Nascimento inválida");
                    return;               
                }
                    dataNascimento = value;
            }
        }
        public double Salario
        {
            get => salario;
            set
            {
                if (value <= 0)
                {
                    MessageBox.Show("Salário inválido");
                    return;
                }            
                salario = value;
            }
        }
        public char Tipo
        {
            get => tipo;
            set
            {
                if(value != 'G' && value != 'F')
                {
                    MessageBox.Show("Função Inválida");
                    return;
                }
                   
                tipo = value;
            }
        }

        
    }
}
