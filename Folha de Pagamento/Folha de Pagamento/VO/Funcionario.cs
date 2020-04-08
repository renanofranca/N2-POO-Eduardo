using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Folha_de_Pagamento.Core;

namespace Folha_de_Pagamento
{
    public class Funcionario
    {

        private int codigo;
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


        public int Codigo 
        { 
            get => codigo; 
            set
            {
                if (value < 0)
                {
                    throw new Exception("Código do Departamento não pode ser menor do que 0.");
                }

                List<Funcionario> funcionarios = ControleDados.GetAllFuncionarios();

                foreach(Funcionario f in funcionarios)
                {
                    if(f.codigo == value)
                        throw new Exception("Código já existente");
                }

                codigo = value;
            }
        }
        public int Departamento { get; set; }
        public string Nome
        {
            get => nome;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Nome inválido");
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
                    throw new Exception("CPF inválido");
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
                    throw new Exception("Data Nascimento inválida");        
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
                    throw new Exception("Salário inválido");
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
                    throw new Exception("Função Inválida");
                }
                if (value == 'F' && Departamento == -1)
                {
                    throw new Exception("Funcionário deve ter um departamento.");
                }

                tipo = value;
            }
        }

        
    }
}
