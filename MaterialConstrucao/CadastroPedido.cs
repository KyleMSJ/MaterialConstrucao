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
        }

        private void preencheProduto()
        {
            cboProduto.DataSource = produto.Select();
            cboProduto.DisplayMember = "nome";
            cboProduto.DisplayMember = "descricao";
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
    }
}
