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

        public static List<Funcionario> GetFuncionariosPorGerente(int codDepartamento)
        {
            List<Funcionario> listaRetorno = new List<Funcionario>();

            string[] linhas = File.ReadAllLines(CAMINHOARQUIVOFUNCIONARIO);

            foreach (string linha in linhas)
            {
                Funcionario f = MontaFuncionario(linha);
                if (f.Tipo == 'F' && f.Departamento == codDepartamento)
                    listaRetorno.Add(MontaFuncionario(linha));
            }

            return listaRetorno;
        }

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

        public static void GravarListaFuncionarios(List<Funcionario> funcionarios)
        {
            File.WriteAllText(CAMINHOARQUIVOFUNCIONARIO, "");

            foreach (Funcionario f in funcionarios)
                GravarFuncionario(f);
        }

        public static void GravarFuncionario(Funcionario f)
        {
            File.AppendAllText(CAMINHOARQUIVOFUNCIONARIO, f.Codigo + "|" + f.Nome + "|" + f.CPF + "|" + f.DataNascimento + "|"
                                 + f.Salario + "|" + f.Departamento + "|" + f.Tipo + "|" + Environment.NewLine);
        }

        #endregion Funcionarios

        #region Departamento

        public static List<Funcionario> GetAllDepartamentos()
        {
            List<Funcionario> listaRetorno = new List<Funcionario>();

            string[] linhas = File.ReadAllLines(CAMINHOARQUIVODEPARTAMENTO);

            foreach (string linha in linhas)
            {
                listaRetorno.Add(MontaFuncionario(linha));
            }

            return listaRetorno;
        }

        public static List<Departamento> GetDepartamentosPorGerente(int codGerente)
        {
            List<Departamento> listaRetorno = new List<Departamento>();

            string[] linhas = File.ReadAllLines(CAMINHOARQUIVOFUNCIONARIO);

            foreach (string linha in linhas)
            {
                Departamento d = MontarDepartamento(linha);
                if (d.CodigoGerente == codGerente)
                    listaRetorno.Add(d);
            }

            return listaRetorno;
        }

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

        public static void GravarListaDepartamento(List<Departamento>departamentos)
        {
            File.WriteAllText(CAMINHOARQUIVODEPARTAMENTO,"");

            foreach(Departamento d in departamentos)
                GravarDepartamento(d);
        }

        public static void GravarDepartamento(Departamento d)
        {
            File.AppendAllText(CAMINHOARQUIVODEPARTAMENTO, d.Codigo + "|" + d.Descricao + "|"
                                + d.CodigoGerente + "|" + Environment.NewLine);
        }
        #endregion Departamento
    }
}
