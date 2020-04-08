using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha_de_Pagamento.Core
{
    public class Listagens
    {
        /// <summary>
        /// Lista no modelo de listagem geral
        /// </summary>
        /// <returns>Retorna a string pronta</returns>
        public static string ListagemGeral()
        {
            StringBuilder retorno = new StringBuilder();
            List<Funcionario> funcionarios = ControleDados.GetAllFuncionarios();
            List<Departamento> departamentos = ControleDados.GetAllDepartamentos();
            retorno.Append("Nome");
            retorno.Append("\t");
            retorno.Append("Código");
            retorno.Append("\t");
            retorno.Append("Departamento");
            retorno.Append("\t");
            retorno.Append("Data Nasc.");
            retorno.Append("\t");
            retorno.Append("\t");
            retorno.Append("CPF");
            retorno.Append("\t");
            retorno.Append("\t");
            retorno.Append("Salário");
            retorno.Append("\t");
            retorno.Append("Função");
            retorno.Append("\n");
            retorno.Append("\n");

            foreach (Funcionario funcionario in funcionarios)
            {
                retorno.Append(funcionario.Nome);
                retorno.Append("\t");
                retorno.Append(funcionario.Codigo);
                retorno.Append("\t");

                Departamento d = departamentos.Where(o => o.Codigo == funcionario.Departamento).FirstOrDefault();
                if (d != null)
                    retorno.Append(d.Descricao);
                else
                    retorno.Append("Sem Departamento");

                retorno.Append("\t");
                retorno.Append(funcionario.DataNascimento.ToShortDateString());
                retorno.Append("\t");
                retorno.Append(funcionario.CPF);
                retorno.Append("\t");
                retorno.Append(funcionario.Salario.ToString("F2") + "R$");
                retorno.Append("\t");
                if (funcionario.Tipo == 'F')
                    retorno.Append("Funcionario");
                if (funcionario.Tipo == 'G')
                    retorno.Append("Gerente");
                retorno.Append("\n");

            }

            return retorno.ToString();
        }

        /// <summary>
        /// Lista no modelo de listagem por Gerente
        /// </summary>
        /// <param name="codigoGerente">Código do Gerente</param>
        /// <returns>Retorna a string pronta</returns>
        public static string ListagemGerente(int codigoGerente)
        {
            StringBuilder retorno = new StringBuilder();
            List<Funcionario> funcionarios = ControleDados.GetFuncionariosPorGerente(codigoGerente);
            List<Departamento> departamentos = ControleDados.GetAllDepartamentos();
            retorno.Append("Nome");
            retorno.Append("\t");
            retorno.Append("Código");
            retorno.Append("\t");
            retorno.Append("Departamento");
            retorno.Append("\t");
            retorno.Append("Data Nasc.");
            retorno.Append("\t");
            retorno.Append("\t");
            retorno.Append("CPF");
            retorno.Append("\t");
            retorno.Append("\t");
            retorno.Append("Salário");
            retorno.Append("\t");
            retorno.Append("Função");
            retorno.Append("\n");
            retorno.Append("\n");

            foreach (Funcionario funcionario in funcionarios)
            {
                retorno.Append(funcionario.Nome);
                retorno.Append("\t");
                retorno.Append(funcionario.Codigo);
                retorno.Append("\t");

                Departamento d = departamentos.Where(o => o.Codigo == funcionario.Departamento).FirstOrDefault();
                if (d != null)
                    retorno.Append(d.Descricao);
                else
                    retorno.Append("Sem Departamento");

                retorno.Append("\t");
                retorno.Append(funcionario.DataNascimento.ToShortDateString());
                retorno.Append("\t");
                retorno.Append(funcionario.CPF);
                retorno.Append("\t");
                retorno.Append(funcionario.Salario.ToString("F2") + "R$");
                retorno.Append("\t");
                if (funcionario.Tipo == 'F')
                    retorno.Append("Funcionario");
                if (funcionario.Tipo == 'G')
                    retorno.Append("Gerente");
                retorno.Append("\n");

            }

            return retorno.ToString();
        }

        /// <summary>
        /// Lista no modelo de listagem por Departamento
        /// </summary>
        /// <param name="codigoDepartamento">Código do Departamento</param>
        /// <returns>Retorna a string pronta</returns>
        public static string ListagemDepartamento(int codigoDepartamento)
        {
            StringBuilder retorno = new StringBuilder();
            List<Funcionario> funcionarios = ControleDados.GetAllFuncionarios();
            funcionarios = funcionarios.Where(o => o.Departamento == codigoDepartamento).ToList();
            List<Departamento> departamentos = ControleDados.GetAllDepartamentos();
            retorno.Append("Nome");
            retorno.Append("\t");
            retorno.Append("Código");
            retorno.Append("\t");
            retorno.Append("Departamento");
            retorno.Append("\t");
            retorno.Append("Data Nasc.");
            retorno.Append("\t");
            retorno.Append("CPF");
            retorno.Append("\t");
            retorno.Append("\t");
            retorno.Append("Salário");
            retorno.Append("\t");
            retorno.Append("Função");
            retorno.Append("\n");
            retorno.Append("\n");

            foreach (Funcionario funcionario in funcionarios)
            {
                retorno.Append(funcionario.Nome);
                retorno.Append("\t");
                retorno.Append(funcionario.Codigo);
                retorno.Append("\t");

                Departamento d = departamentos.Where(o => o.Codigo == funcionario.Departamento).FirstOrDefault();
                if (d != null)
                    retorno.Append(d.Descricao);
                else
                    retorno.Append("Sem Departamento");

                retorno.Append("\t");
                retorno.Append(funcionario.DataNascimento.ToShortDateString());
                retorno.Append("\t");
                retorno.Append(funcionario.CPF);
                retorno.Append("\t");
                retorno.Append(funcionario.Salario.ToString("F2") + "R$");
                retorno.Append("\t");
                if (funcionario.Tipo == 'F')
                    retorno.Append("Funcionario");
                if (funcionario.Tipo == 'G')
                    retorno.Append("Gerente");
                retorno.Append("\n");

            }

            return retorno.ToString();
        }

        /// <summary>
        /// Lista no modelo de listagem por Mês de Aniversário
        /// </summary>
        /// <param name="mesAniversario">Mês de aniversário</param>
        /// <returns>Retorna a string pronta</returns>
        public static string ListagemMesAniversario(int mesAniversario)
        {
            StringBuilder retorno = new StringBuilder();
            List<Funcionario> funcionarios = ControleDados.GetAllFuncionarios();
            funcionarios = funcionarios.Where(o => o.DataNascimento.Month == mesAniversario).ToList();

            List<Departamento> departamentos = ControleDados.GetAllDepartamentos();
            retorno.Append("Nome");
            retorno.Append("\t");
            retorno.Append("Código");
            retorno.Append("\t");
            retorno.Append("Departamento");
            retorno.Append("\t");
            retorno.Append("Data Nasc.");
            retorno.Append("\t");
            retorno.Append("\t");
            retorno.Append("CPF");
            retorno.Append("\t");
            retorno.Append("\t");
            retorno.Append("Salário");
            retorno.Append("\t");
            retorno.Append("Função");
            retorno.Append("\n");
            retorno.Append("\n");

            foreach (Funcionario funcionario in funcionarios)
            {
                retorno.Append(funcionario.Nome);
                retorno.Append("\t");
                retorno.Append(funcionario.Codigo);
                retorno.Append("\t");

                Departamento d = departamentos.Where(o => o.Codigo == funcionario.Departamento).FirstOrDefault();
                if (d != null)
                    retorno.Append(d.Descricao);
                else
                    retorno.Append("Sem Departamento");

                retorno.Append("\t");
                retorno.Append(funcionario.DataNascimento.ToShortDateString());
                retorno.Append("\t");
                retorno.Append(funcionario.CPF);
                retorno.Append("\t");
                retorno.Append(funcionario.Salario.ToString("F2") + "R$");
                retorno.Append("\t");
                if (funcionario.Tipo == 'F')
                    retorno.Append("Funcionario");
                if (funcionario.Tipo == 'G')
                    retorno.Append("Gerente");
                retorno.Append("\n");

            }

            return retorno.ToString();
        }

        /// <summary>
        /// Lista no modelo de listagem de Todos os Gerentes
        /// </summary>
        /// <returns>Retorna uma lista de KeyValuePair onde a chave é a string e o valor é uma booleana que indica se o texto deve ser em amarelo ou preto(True: Amarelo, False: Preto)</returns>
        public static List<KeyValuePair<string, bool>> ListagemTodosGerentes()
        {

            List<Funcionario> gerentes = ControleDados.GetFuncionariosTipados(ControleDados.EnumTipoFuncionario.Gerente);
            List<KeyValuePair<string, bool>> retorno = new List<KeyValuePair<string, bool>>();

            foreach (Funcionario gerente in gerentes)
            {
                StringBuilder gerenteString = new StringBuilder();

                gerenteString.Append("GERENTE: Código: ");
                gerenteString.Append(gerente.Codigo);
                gerenteString.Append(" - Nome: ");
                gerenteString.Append(gerente.Nome);
                gerenteString.Append("\n");

                retorno.Add(new KeyValuePair<string, bool>(gerenteString.ToString(), true));

                List<Funcionario> funcionarios = ControleDados.GetFuncionariosPorGerente(gerente.Codigo);

                StringBuilder funcionarioString = new StringBuilder();
                funcionarioString.Append("\tFuncionários Gerenciados:\n\n");

                if (funcionarios.Count > 0)
                {
                    foreach (Funcionario funcionario in funcionarios)
                    {
                        funcionarioString.Append("\t\t");
                        funcionarioString.Append("Código: ");
                        funcionarioString.Append(funcionario.Codigo);
                        funcionarioString.Append(" - Nome: ");
                        funcionarioString.Append(funcionario.Nome);
                        funcionarioString.Append(" - CPF: ");
                        funcionarioString.Append(funcionario.CPF.Replace(',', '.'));
                        funcionarioString.Append("\n");
                    }
                }
                funcionarioString.Append("\n");
                retorno.Add(new KeyValuePair<string, bool>(funcionarioString.ToString(), false));
            }

            return retorno;
        }
    }
}
