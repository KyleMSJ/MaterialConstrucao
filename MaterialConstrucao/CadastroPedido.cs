using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaterialConstrucao
{
    public partial class CadastroPedido : Form
    {
        csCliente cliente = new csCliente();
        csFuncionario funcionario = new csFuncionario();
        csProduto produto = new csProduto();
        csPedido pedido = new csPedido();
        csItemPedido itemPedido = new csItemPedido();

        public CadastroPedido()
        {
            InitializeComponent();
        }

        private void preencheCliente()
        {
            cboCliente.DataSource = cliente.select();
            cboCliente.DisplayMember = "nome";
            cboCliente.DisplayMember = "CPF";

            cboCliente.SelectedIndex = -1;
        }

        private void preencheFuncionario()
        {
            cboFuncionario.DataSource = funcionario.select();
            cboFuncionario.DisplayMember = "nome";
            cboFuncionario.DisplayMember = "telefone";

            cboFuncionario.SelectedIndex = -1;
        }

        private void preencheProduto()
        {
            cboProduto.DataSource = produto.Select();
            cboProduto.DisplayMember = "nome";
            cboProduto.DisplayMember = "descricao";

            cboProduto.SelectedIndex = -1;
        }
        private void habilitaControlesPedido(bool status)
        {
            cboCliente.Enabled = status;
            txtData.Enabled = status;
            cboFuncionario.Enabled = status;
            txtValorTotal.Enabled = status;

            mnuItemPedido.Enabled = status;
        }

        private void habilitaControlesItemPedido(bool status)
        {
            cboProduto.Enabled = status;
            txtQuantidade.Enabled = status;
        }
        private void limparControlesPedido()
        {
            pedido.setCPF_Cliente("");
            cboCliente.SelectedIndex = -1;
            txtData.Text = "";
            cboFuncionario.SelectedIndex = -1;
            txtValorTotal.Text = "";
        }

        public void limparControlesItemPedido()
        {
            cboProduto.SelectedIndex = -1;
            txtQuantidade.Text = "";
        }


        private void gerenciaBotoesBarraPedido(bool status)
        {
            btnNovo.Enabled = status;
            btnEditar.Enabled = status;
            btnExcluir.Enabled = status;
            btnSair.Enabled = status;
            btnSalvar.Enabled = !status;
            btnCancelar.Enabled = !status;
        }
        private void gerenciaBotoesBarraItemPedido(bool status)
        {
            btnNovoProduto.Enabled = status;
            btnEditarProduto.Enabled = status;
            btnExcluirProduto.Enabled = status;
            btnSalvarProduto.Enabled = !status;
            btnCancelarProduto.Enabled = !status;
        }

        private void formataGridPedido()
        {
            grdDadosPedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            grdDadosPedido.Columns[0].HeaderText = "Código";
            grdDadosPedido.Columns[1].HeaderText = "Data";
            grdDadosPedido.Columns[2].HeaderText = "Cliente";

            grdDadosPedido.Columns[0].Width = 0;
            grdDadosPedido.Columns[1].Width = 60;
            grdDadosPedido.Columns[2].Width = 180;
        }

        private void formataGridItemPedido()
        {
            grdProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            grdProdutos.Columns.Add("Codigo", "Codigo");
            grdProdutos.Columns.Add("Produto", "Nome Produto");
            grdProdutos.Columns.Add("Quantidade", "Quantidade");
            grdProdutos.Columns.Add("Valor", "Valor");
            grdProdutos.Columns.Add("Total", "Total");

            grdProdutos.Columns[0].Width = 0;
            grdProdutos.Columns[1].Width = 100;
            grdProdutos.Columns[2].Width = 30;
            grdProdutos.Columns[3].Width = 30;
            grdProdutos.Columns[4].Width = 30;

        }

        private void preencheGridPedido()
        {
            grdDadosPedido.DataSource = pedido.select();
            formataGridPedido();
        }
        private void CadastroPedido_Load(object sender, EventArgs e)
        {
            habilitaControlesPedido(false);
            gerenciaBotoesBarraPedido(true);
            preencheGridPedido();

            preencheCliente();
            preencheFuncionario();
            preencheProduto();

            formataGridItemPedido();
            habilitaControlesItemPedido(false);
            gerenciaBotoesBarraItemPedido(true);
        }
    }
}
