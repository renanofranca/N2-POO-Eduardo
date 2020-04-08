namespace Folha_de_Pagamento.UserControls
{
    partial class uclListagens
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.cmbGerente = new System.Windows.Forms.ComboBox();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.rbtnListTodosGer = new System.Windows.Forms.RadioButton();
            this.rbtnListNasc = new System.Windows.Forms.RadioButton();
            this.rbtnListGer = new System.Windows.Forms.RadioButton();
            this.rbtnListDep = new System.Windows.Forms.RadioButton();
            this.rbtnListGeral = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtListagem = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.rbtnListTodosGer);
            this.groupBox1.Controls.Add(this.rbtnListNasc);
            this.groupBox1.Controls.Add(this.rbtnListGer);
            this.groupBox1.Controls.Add(this.rbtnListDep);
            this.groupBox1.Controls.Add(this.rbtnListGeral);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(674, 129);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modelos de Listagem";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cmbMes);
            this.groupBox3.Controls.Add(this.cmbGerente);
            this.groupBox3.Controls.Add(this.cmbDepartamento);
            this.groupBox3.Location = new System.Drawing.Point(6, 52);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(389, 71);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Parâmetros";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mês de Nascimento:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Gerente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Departamento:";
            // 
            // cmbMes
            // 
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Items.AddRange(new object[] {
            "Janeiro",
            "Fevereiro",
            "Março",
            "Abril",
            "Maio",
            "Junho",
            "Julho",
            "Agosto",
            "Setembro",
            "Outubro",
            "Novembro",
            "Dezembro"});
            this.cmbMes.Location = new System.Drawing.Point(260, 44);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(121, 21);
            this.cmbMes.TabIndex = 2;
            this.cmbMes.SelectedIndexChanged += new System.EventHandler(this.cmbMes_SelectedIndexChanged);
            // 
            // cmbGerente
            // 
            this.cmbGerente.FormattingEnabled = true;
            this.cmbGerente.Location = new System.Drawing.Point(133, 44);
            this.cmbGerente.Name = "cmbGerente";
            this.cmbGerente.Size = new System.Drawing.Size(121, 21);
            this.cmbGerente.TabIndex = 1;
            this.cmbGerente.SelectedIndexChanged += new System.EventHandler(this.cmbGerente_SelectedIndexChanged);
            // 
            // cmbDepartamento
            // 
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Location = new System.Drawing.Point(6, 44);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(121, 21);
            this.cmbDepartamento.TabIndex = 0;
            this.cmbDepartamento.SelectedIndexChanged += new System.EventHandler(this.cmbDepartamento_SelectedIndexChanged);
            // 
            // rbtnListTodosGer
            // 
            this.rbtnListTodosGer.AutoSize = true;
            this.rbtnListTodosGer.Location = new System.Drawing.Point(530, 29);
            this.rbtnListTodosGer.Name = "rbtnListTodosGer";
            this.rbtnListTodosGer.Size = new System.Drawing.Size(138, 17);
            this.rbtnListTodosGer.TabIndex = 4;
            this.rbtnListTodosGer.TabStop = true;
            this.rbtnListTodosGer.Text = "Listagem de Todos Ger.";
            this.rbtnListTodosGer.UseVisualStyleBackColor = true;
            this.rbtnListTodosGer.CheckedChanged += new System.EventHandler(this.rbtnListTodosGer_CheckedChanged);
            // 
            // rbtnListNasc
            // 
            this.rbtnListNasc.AutoSize = true;
            this.rbtnListNasc.Location = new System.Drawing.Point(399, 29);
            this.rbtnListNasc.Name = "rbtnListNasc";
            this.rbtnListNasc.Size = new System.Drawing.Size(116, 17);
            this.rbtnListNasc.TabIndex = 3;
            this.rbtnListNasc.TabStop = true;
            this.rbtnListNasc.Text = "Listagem por Nasc.";
            this.rbtnListNasc.UseVisualStyleBackColor = true;
            this.rbtnListNasc.CheckedChanged += new System.EventHandler(this.rbtnListNasc_CheckedChanged);
            // 
            // rbtnListGer
            // 
            this.rbtnListGer.AutoSize = true;
            this.rbtnListGer.Location = new System.Drawing.Point(268, 29);
            this.rbtnListGer.Name = "rbtnListGer";
            this.rbtnListGer.Size = new System.Drawing.Size(108, 17);
            this.rbtnListGer.TabIndex = 2;
            this.rbtnListGer.TabStop = true;
            this.rbtnListGer.Text = "Listagem por Ger.";
            this.rbtnListGer.UseVisualStyleBackColor = true;
            this.rbtnListGer.CheckedChanged += new System.EventHandler(this.rbtnListGer_CheckedChanged);
            // 
            // rbtnListDep
            // 
            this.rbtnListDep.AutoSize = true;
            this.rbtnListDep.Location = new System.Drawing.Point(137, 29);
            this.rbtnListDep.Name = "rbtnListDep";
            this.rbtnListDep.Size = new System.Drawing.Size(111, 17);
            this.rbtnListDep.TabIndex = 1;
            this.rbtnListDep.TabStop = true;
            this.rbtnListDep.Text = "Listagem por Dep.";
            this.rbtnListDep.UseVisualStyleBackColor = true;
            this.rbtnListDep.CheckedChanged += new System.EventHandler(this.rbtnListDep_CheckedChanged);
            // 
            // rbtnListGeral
            // 
            this.rbtnListGeral.AutoSize = true;
            this.rbtnListGeral.Location = new System.Drawing.Point(6, 29);
            this.rbtnListGeral.Name = "rbtnListGeral";
            this.rbtnListGeral.Size = new System.Drawing.Size(95, 17);
            this.rbtnListGeral.TabIndex = 0;
            this.rbtnListGeral.TabStop = true;
            this.rbtnListGeral.Text = "Listagem Geral";
            this.rbtnListGeral.UseVisualStyleBackColor = true;
            this.rbtnListGeral.CheckedChanged += new System.EventHandler(this.rbtnListGeral_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtListagem);
            this.groupBox2.Location = new System.Drawing.Point(3, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(893, 351);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listagem";
            // 
            // txtListagem
            // 
            this.txtListagem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtListagem.Location = new System.Drawing.Point(6, 19);
            this.txtListagem.Name = "txtListagem";
            this.txtListagem.Size = new System.Drawing.Size(881, 326);
            this.txtListagem.TabIndex = 0;
            this.txtListagem.Text = "";
            // 
            // uclListagens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "uclListagens";
            this.Size = new System.Drawing.Size(899, 492);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnListTodosGer;
        private System.Windows.Forms.RadioButton rbtnListNasc;
        private System.Windows.Forms.RadioButton rbtnListGer;
        private System.Windows.Forms.RadioButton rbtnListDep;
        private System.Windows.Forms.RadioButton rbtnListGeral;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox txtListagem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.ComboBox cmbGerente;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private System.Windows.Forms.Label label3;
    }
}
