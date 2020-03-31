using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Folha_de_Pagamento.UserControls
{
    public partial class uclCadastroFuncionario : UserControl
    {
        public uclCadastroFuncionario()
        {
            InitializeComponent();
        }
        //precisa pegar da lista que ja existe dos funcionarios
        List<Funcionario> funcionarios = new List<Funcionario>();
        private void btnAplicarAumento_Click(object sender, EventArgs e)
        {
            if (rdbPercentual.Checked)
                AplicarAumento(Convert.ToDouble(txtPercentualAumento), true);
            else if (rdbValorFixo.Checked)
                AplicarAumento(Convert.ToDouble(txtValorAumento));
            else
                MessageBox.Show("Selecione uma forma de aumento");

            //Precisa salvar a lista de funcionarios alterada no txt, porem agora estou com preguica
            //abraco
        }

        public void AplicarAumento(double aumento)
        {
            foreach(Funcionario f in funcionarios)
            {
                f.Salario = f.Salario + aumento;
            }
        }
        public void AplicarAumento(double aumento,bool porcentagem)
        {
            foreach (Funcionario f in funcionarios)
            {
                f.Salario = f.Salario + f.Salario*aumento;
            }
        }
    }
}
