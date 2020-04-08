using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha_de_Pagamento.Core
{
    public static class ControleDados
    {
        private const string CAMINHOARQUIVOFUNCIONARIO = "Funcionario.txt";
        private const string CAMINHOARQUIVODEPARTAMENTO = "Departamento.txt";

        #region TXT
        /// <summary>
        /// Valida se os documentos existem ou não
        /// </summary>
        public static void ValidarExistenciaTXTs()
        {
            if (!File.Exists(CAMINHOARQUIVOFUNCIONARIO))
                File.Create(CAMINHOARQUIVOFUNCIONARIO).Close();
            if (!File.Exists(CAMINHOARQUIVODEPARTAMENTO))
                File.Create(CAMINHOARQUIVODEPARTAMENTO).Close();
        }
        #endregion TXT

        #region Funcionarios
        public enum EnumTipoFuncionario { Funcionario, Gerente }

        /// <summary>
        /// Busca todos os funcionários da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista de funcionarios</returns>
        public static List<Funcionario> GetAllFuncionarios()
        {
            List<Funcionario> listaRetorno = new List<Funcionario>();

            string[] linhas = File.ReadAllLines(CAMINHOARQUIVOFUNCIONARIO);

            foreach (string linha in linhas)
            {
                listaRetorno.Add(MontaFuncionario(linha));
            }

            return listaRetorno;
        }

        /// <summary>
        /// Busca os funcionarios pelo tipo
        /// </summary>
        /// <param name="tipo">enumerador do tipo de funcionario</param>
        /// <returns>Retorna uma lista de funcionarios</returns>
        public static List<Funcionario> GetFuncionariosTipados(EnumTipoFuncionario tipo)
        {
            List<Funcionario> listaRetorno = new List<Funcionario>();
            if (tipo == EnumTipoFuncionario.Funcionario)
            {
                string[] linhas = File.ReadAllLines(CAMINHOARQUIVOFUNCIONARIO);

                foreach (string linha in linhas)
                {
                    Funcionario f = MontaFuncionario(linha);
                    if (f.Tipo == 'F')
                        listaRetorno.Add(MontaFuncionario(linha));
                }

            }
            else if (tipo == EnumTipoFuncionario.Gerente)
            {
                string[] linhas = File.ReadAllLines(CAMINHOARQUIVOFUNCIONARIO);

                foreach (string linha in linhas)
                {
                    Funcionario f = MontaFuncionario(linha);
                    if (f.Tipo == 'G')
                        listaRetorno.Add(MontaFuncionario(linha));
                }
            }
            return listaRetorno;
        }

        /// <summary>
        ///  Busca os funcionarios pelo gerente
        /// </summary>
        /// <param name="codGerente">Codigo do Gerente</param>
        /// <returns>Retorna uma lista de funcionarios</returns>
        public static List<Funcionario> GetFuncionariosPorGerente(int codGerente)
        {
            List<Funcionario> listaRetorno = new List<Funcionario>();

            List<Departamento> departamentos = GetDepartamentosPorGerente(codGerente);

            List<Funcionario> funcionarios = GetAllFuncionarios();

            foreach(Departamento d in departamentos)
            {
                listaRetorno.AddRange(funcionarios.Where(o => o.Departamento == d.Codigo && o.Codigo != codGerente));
            }

            return listaRetorno;
        }

        /// <summary>
        /// Monta o VO do Funcionario
        /// </summary>
        /// <param name="linha">Linha da base de dados</param>
        /// <returns>Retorna um Funcionario</returns>
        private static Funcionario MontaFuncionario(string linha)
        {
            try
            {
                string[] dados = linha.Split('|');

                int codigo = Convert.ToInt16(dados[0]);
                string nome = dados[1];
                string cpf = dados[2];
                DateTime dataNascimento = Convert.ToDateTime(dados[3]);
                double salario = Convert.ToDouble(dados[4]);
                int departamento = Convert.ToInt16(dados[5]);
                char tipo = Convert.ToChar(dados[6]);

                return new Funcionario(codigo, nome, cpf, dataNascimento, salario, departamento, tipo);
            }
            catch
            {
                throw new Exception("Impossivel Converter a linha:\n" + linha + "\n Favor Verificar Documento");
            }

        }

        /// <summary>
        /// Grava uma lista de funcionarios.
        /// </summary>
        /// <param name="funcionarios">Lista de funcionarios</param>
        public static void GravarListaFuncionarios(List<Funcionario> funcionarios)
        {
            File.WriteAllText(CAMINHOARQUIVOFUNCIONARIO, "");

            foreach (Funcionario f in funcionarios)
                GravarFuncionario(f);
        }

        /// <summary>
        /// Grava um unico funcionario da base de dados.
        /// </summary>
        /// <param name="f">Funcionario a ser gravado</param>
        public static void GravarFuncionario(Funcionario f)
        {
            File.AppendAllText(CAMINHOARQUIVOFUNCIONARIO, f.Codigo + "|" + f.Nome + "|" + f.CPF + "|" + f.DataNascimento + "|"
                                 + f.Salario + "|" + f.Departamento + "|" + f.Tipo + "|" + Environment.NewLine);
        }

        #endregion Funcionarios

        #region Departamento

        /// <summary>
        /// Busca todos os departamentos da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista de Departamentos</returns>
        public static List<Departamento> GetAllDepartamentos()
        {
            List<Departamento> listaRetorno = new List<Departamento>();

            string[] linhas = File.ReadAllLines(CAMINHOARQUIVODEPARTAMENTO);

            foreach (string linha in linhas)
            {
                listaRetorno.Add(MontarDepartamento(linha));
            }

            return listaRetorno;
        }

        /// <summary>
        /// Busca os departamentos de um determinado Gerente
        /// </summary>
        /// <param name="codGerente">Código do Gerente</param>
        /// <returns>Retorna uma lista de Departamentos</returns>
        public static List<Departamento> GetDepartamentosPorGerente(int codGerente)
        {
            List<Departamento> listaRetorno = new List<Departamento>();

            string[] linhas = File.ReadAllLines(CAMINHOARQUIVODEPARTAMENTO);

            foreach (string linha in linhas)
            {
                Departamento d = MontarDepartamento(linha);
                if (d.CodigoGerente == codGerente)
                    listaRetorno.Add(d);
            }

            listaRetorno = listaRetorno.Where(o => o.CodigoGerente == codGerente).ToList();

            return listaRetorno;
        }

        /// <summary>
        /// Monta o VO do Departamento
        /// </summary>
        /// <param name="linha"></param>
        /// <returns></returns>
        private static Departamento MontarDepartamento(string linha)
        {
            try
            {
                string[] dados = linha.Split('|');


                int codigoDepartamento = Convert.ToInt16(dados[0]);
                string descricao = dados[1];
                int codigoGerente = Convert.ToInt16(dados[2]);

                return new Departamento(codigoDepartamento, descricao, codigoGerente);

            }
            catch
            {
                throw new Exception("Impossivel Converter a linha:\n" + linha + "\n Favor Verificar Documento");
            }

        }

        /// <summary>
        /// Grava uma lista de Departamentos na base de dados
        /// </summary>
        /// <param name="departamentos">Lista de Departmentos a ser gravada</param>
        public static void GravarListaDepartamento(List<Departamento> departamentos)
        {
            File.WriteAllText(CAMINHOARQUIVODEPARTAMENTO, "");

            foreach (Departamento d in departamentos)
                GravarDepartamento(d);
        }

        /// <summary>
        /// Grava um unico Departamento na base de dados.
        /// </summary>
        /// <param name="d">Departamento a ser gravado</param>
        public static void GravarDepartamento(Departamento d)
        {
            File.AppendAllText(CAMINHOARQUIVODEPARTAMENTO, d.Codigo + "|" + d.Descricao + "|"
                                + d.CodigoGerente + "|" + Environment.NewLine);
        }
        #endregion Departamento
    }
}
