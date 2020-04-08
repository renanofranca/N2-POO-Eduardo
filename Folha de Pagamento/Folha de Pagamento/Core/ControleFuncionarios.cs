using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha_de_Pagamento.Core
{
    public class ControleFuncionarios
    {
        public enum EnumTipoAumento { Percentual, ValorFixo}

        /// <summary>
        /// Metodo que aplica aumento com valor Fixo
        /// </summary>
        /// <param name="aumento">Valor do aumento</param>
        public static void AplicarAumento(double aumento)
        {
            AplicarAumento(aumento, EnumTipoAumento.ValorFixo);
        }

        /// <summary>
        /// Método que aplica o aumento por tipo de aumento
        /// </summary>
        /// <param name="aumento">valor do aumento</param>
        /// <param name="tipo">enumerador contendo o tipo do aumento</param>
        public static void AplicarAumento(double aumento, EnumTipoAumento tipo)
        {
            List<Funcionario> funcionarios = ControleDados.GetAllFuncionarios();
            

            if (tipo == EnumTipoAumento.ValorFixo)
            {
                foreach (Funcionario f in funcionarios)
                {
                    f.Salario = f.Salario + aumento;
                }
                ControleDados.GravarListaFuncionarios(funcionarios);
            }
            else if(tipo == EnumTipoAumento.Percentual)
            {
                foreach (Funcionario f in funcionarios)
                {
                    f.Salario = f.Salario + f.Salario * aumento;
                    ControleDados.GravarListaFuncionarios(funcionarios);
                }
            }
        }
    }
}
