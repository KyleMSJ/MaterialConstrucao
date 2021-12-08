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
    public partial class CadastroProduto : Form
    {
        csProduto prod = new csProduto();
        bool novoProduto = false;
        public CadastroProduto()
        {
            InitializeComponent();
        }

        private void habilitaControles(bool status)
        {
            txtNome.Enabled = status;
            txtNumero.Enabled = status;
            txtQuantidade.Enabled = status;
            txtDescricao.Enabled = status;
            txtValor.Enabled = status;
        }

        private void limparControles()
        {
            txtNome.Text = "";
            txtNumero.Text = "";
            txtQuantidade.Text = "";
            txtDescricao.Text = "";
            txtValor.Text = "";
        }

        private void gerenciaBotoesBarra(bool status)
        {
            btnNovo.Enabled = status;
            btnEditar.Enabled = status;
            btnExcluir.Enabled = status;
            btnSair.Enabled = status;
            btnSalvar.Enabled = !status;
            btnCancelar.Enabled = !status;
        }

        private void formataGrid()
        {
            grdDadosProduto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            grdDadosProduto.Columns[0].HeaderText = "Código";
            grdDadosProduto.Columns[1].HeaderText = "Nome do Produto";

            grdDadosProduto.Columns[0].Width = 30;
            grdDadosProduto.Columns[1].Width = 100;
        }
       private void preencheGrid() 
        {
            grdDadosProduto.DataSource = prod.Select();
            formataGrid();
        }

        private void excluiProduto()
        {
            prod.delete();
        }

        private void salvarProduto()
        {
            prod.setCodProduto(txtNumero.Text);
            prod.setDescricaoProduto(txtDescricao.Text);
            prod.setNomeProduto(txtNome.Text);
            prod.setQtdProduto(Convert.ToDouble((txtQuantidade.Text)));
            prod.setValorProduto(Convert.ToDouble(txtValor.Text));

            if (novoProduto == true)
            {
                prod.inserir();
            }
            else
            {
                prod.update();
            }
            novoProduto = false;
        }

        private void preencheDadosControles()
        {
            prod.selectProduto();

            txtNumero.Text = prod.getNomeProduto();
            txtDescricao.Text = prod.getDescricaoProduto();
            txtNome.Text = prod.getNomeProduto();

            txtQuantidade.Text = prod.getQtdProduto().ToString();
            txtValor.Text = prod.getValorProduto().ToString();
        }

        private void grdDadosProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            prod.setCodProduto(grdDadosProduto.Rows[grdDadosProduto.CurrentRow.Index].Cells[0].Value.ToString());
            preencheDadosControles();
        }

        private void CadastroProduto_Load(object sender, EventArgs e)
        {
            habilitaControles(false);
            gerenciaBotoesBarra(true);
            preencheGrid();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitaControles(true);
            limparControles();
            gerenciaBotoesBarra(false);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitaControles(true);
            gerenciaBotoesBarra(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja cancelar o cadastro do Produto?", "Aviso!!!",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                habilitaControles(false);
                limparControles();
                gerenciaBotoesBarra(true);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (validaDados() == true)
            {
                salvarProduto();
                habilitaControles(false);
                limparControles();
                gerenciaBotoesBarra(true);
                preencheGrid();
            }
        }

            private void btnExcluir_Click(object sender, EventArgs e)
            {
                if (prod.getCodProduto() != "")
                {
                    DialogResult retorno = MessageBox.Show("Deseja excluir os dados do produto selecionado?", "Exclusão",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (retorno == DialogResult.Yes)
                    {
                        excluiProduto();
                        limparControles();
                        preencheGrid();
                    }
                }
                else
                {
                    MessageBox.Show("Selecione o Produto para excluir", "Aviso!!!", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool validaDados()
        {
            if (txtNumero.Text.Trim().Length < 3)
            {
                MessageBox.Show("Código do Produto é obrigatório, informe!", "Aviso!!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus(); 
                return false;
            }
            if (txtNome.Text.Trim().Length <= 5) 
            {
                MessageBox.Show("Nome do produto é obrigatório, informe!", "Aviso!!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus(); 
                return false;
            }
            if (txtQuantidade.Text.Trim().Length < 1)  
            {
                MessageBox.Show("A quantidade é obrigatória, informe!", "Aviso!!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantidade.Focus(); 
                return false;
            }
            if (txtValor.Text.Trim().Length <= 3) 
            {
                MessageBox.Show("Preço do produto é obrigatório, informe!", "Aviso!!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValor.Focus(); 
                return false;
            }
            return true;
        }
    }
}
