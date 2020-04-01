using Folha_de_Pagamento.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Folha_de_Pagamento.Core;

namespace Folha_de_Pagamento
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ControleDados.ValidarExistenciaTXTs();
            Application.Run(new frmMenu());
        }
    }
}
