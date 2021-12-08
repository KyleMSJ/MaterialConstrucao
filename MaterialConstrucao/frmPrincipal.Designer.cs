
namespace MaterialConstrucao
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProdutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fecharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NotaFiscalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrincipal = new System.Windows.Forms.MenuStrip();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // CadastroToolStripMenuItem
            // 
            this.CadastroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClienteToolStripMenuItem,
            this.funcionárioToolStripMenuItem,
            this.ProdutoToolStripMenuItem,
            this.PedidoToolStripMenuItem,
            this.toolStripSeparator1,
            this.fecharToolStripMenuItem});
            this.CadastroToolStripMenuItem.Name = "CadastroToolStripMenuItem";
            this.CadastroToolStripMenuItem.Size = new System.Drawing.Size(99, 29);
            this.CadastroToolStripMenuItem.Text = "Cadastro";
            // 
            // ClienteToolStripMenuItem
            // 
            this.ClienteToolStripMenuItem.Name = "ClienteToolStripMenuItem";
            this.ClienteToolStripMenuItem.Size = new System.Drawing.Size(184, 30);
            this.ClienteToolStripMenuItem.Text = "Cliente";
            this.ClienteToolStripMenuItem.Click += new System.EventHandler(this.ClienteToolStripMenuItem_Click);
            // 
            // funcionárioToolStripMenuItem
            // 
            this.funcionárioToolStripMenuItem.Name = "funcionárioToolStripMenuItem";
            this.funcionárioToolStripMenuItem.Size = new System.Drawing.Size(184, 30);
            this.funcionárioToolStripMenuItem.Text = "Funcionário";
            this.funcionárioToolStripMenuItem.Click += new System.EventHandler(this.funcionárioToolStripMenuItem_Click);
            // 
            // ProdutoToolStripMenuItem
            // 
            this.ProdutoToolStripMenuItem.Name = "ProdutoToolStripMenuItem";
            this.ProdutoToolStripMenuItem.Size = new System.Drawing.Size(184, 30);
            this.ProdutoToolStripMenuItem.Text = "Produto";
            this.ProdutoToolStripMenuItem.Click += new System.EventHandler(this.ProdutoToolStripMenuItem_Click);
            // 
            // PedidoToolStripMenuItem
            // 
            this.PedidoToolStripMenuItem.Name = "PedidoToolStripMenuItem";
            this.PedidoToolStripMenuItem.Size = new System.Drawing.Size(184, 30);
            this.PedidoToolStripMenuItem.Text = "Pedido";
            this.PedidoToolStripMenuItem.Click += new System.EventHandler(this.PedidoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // fecharToolStripMenuItem
            // 
            this.fecharToolStripMenuItem.Name = "fecharToolStripMenuItem";
            this.fecharToolStripMenuItem.Size = new System.Drawing.Size(184, 30);
            this.fecharToolStripMenuItem.Text = "Fechar";
            // 
            // NotaFiscalToolStripMenuItem
            // 
            this.NotaFiscalToolStripMenuItem.Name = "NotaFiscalToolStripMenuItem";
            this.NotaFiscalToolStripMenuItem.Size = new System.Drawing.Size(116, 29);
            this.NotaFiscalToolStripMenuItem.Text = "Nota Fiscal";
            // 
            // mnuPrincipal
            // 
            this.mnuPrincipal.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.mnuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CadastroToolStripMenuItem,
            this.NotaFiscalToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.mnuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnuPrincipal.Name = "mnuPrincipal";
            this.mnuPrincipal.Size = new System.Drawing.Size(800, 33);
            this.mnuPrincipal.TabIndex = 1;
            this.mnuPrincipal.Text = "menuStrip1";
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobreToolStripMenuItem});
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(73, 29);
            this.ajudaToolStripMenuItem.Text = "Ajuda";
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(133, 30);
            this.sobreToolStripMenuItem.Text = "Sobre";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mnuPrincipal);
            this.IsMdiContainer = true;
            this.Name = "frmPrincipal";
            this.Text = "Material de Construção";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mnuPrincipal.ResumeLayout(false);
            this.mnuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem CadastroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProdutoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PedidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem fecharToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NotaFiscalToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mnuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funcionárioToolStripMenuItem;
    }
}