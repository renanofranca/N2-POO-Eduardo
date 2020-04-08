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

        public static void AplicarAumento(double aumento)
        {
            AplicarAumento(aumento, EnumTipoAumento.ValorFixo);
        }

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
