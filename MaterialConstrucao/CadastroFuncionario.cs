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
    public partial class CadastroFuncionario : Form
    {
        csFuncionario func = new csFuncionario();

        private void habilitaControles(bool status)
        {
            txtNomeF.Enabled = status;
            cboSiglaF.Enabled = status;
            txtCidadeF.Enabled = status;
            txtCPF_F.Enabled = status;
            txtCEP_F.Enabled = status;
            txtTelefoneF.Enabled = status;
            txtNumeroF.Enabled = status;
        }

        private void limparControles()
        {
            txtNomeF.Text = "";
            cboSiglaF.SelectedIndex = -1;
            txtCidadeF.Text = "";
            txtCPF_F.Text = "";
            txtCEP_F.Text = "";
            txtTelefoneF.Text = "";
            txtNumeroF.Text = "";
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
            grdDadosFuncionario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            grdDadosFuncionario.Columns[0].HeaderText = "CPF";
            grdDadosFuncionario.Columns[1].HeaderText = "Nome";
            grdDadosFuncionario.Columns[2].HeaderText = "CEP";

            grdDadosFuncionario.Columns[0].Width = 30;
            grdDadosFuncionario.Columns[1].Width = 70;
            grdDadosFuncionario.Columns[2].Width = 260;
        }

        private void preencheGrid()
        {
            // grdDadosFuncionario.DataSource = 
            formataGrid();
        }

        private void excluiFuncionario()
        {

        }

        private void salvarFuncionario()
        {

        }

        private void preencheDadosControles()
        {

        }

        public CadastroFuncionario()
        {
            InitializeComponent();
        }

        private void CadastroFuncionario_Load(object sender, EventArgs e)
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
            if (MessageBox.Show("Deseja cancelar o cadastro do Cliente?", "Aviso!!!",
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
                salvarFuncionario();
                habilitaControles(false);
                limparControles();
                gerenciaBotoesBarra(true);
                preencheGrid();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            /*if (func.GetCPF_Funcionario() != "") 
            {
                DialogResult retorno = MessageBox.Show("Deseja excluir os dados do funcionario selecionado?", "Exclusão",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (retorno == DialogResult.Yes)
                {
                    excluiFuncionario();
                    limparControles();
                    preencheGrid();
                }
            }
            else
            {
                MessageBox.Show("Selecione o Funcionario para excluir", "Aviso!!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }*/
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool validaDados()
        {
            if (txtNomeF.Text.Trim().Length <= 3)
            {
                MessageBox.Show("Nome do Funcionário é obrigatório, informe!", "Aviso!!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNomeF.Focus();
                return false;
            }
            if (txtCPF_F.Text.Trim().Length != 14)
            {
                MessageBox.Show("CPF é obrigatório, informe!", "Aviso!!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCPF_F.Focus();
                return false;
            }
            if (txtCEP_F.Text.Trim().Length != 9)
            {
                MessageBox.Show("CEP é obrigatório, informe!", "Aviso!!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCEP_F.Focus();
                return false;
            }
            if (txtCidadeF.Text.Trim().Length <= 2)
            {
                MessageBox.Show("Nome da Cidade é obrigatório, informe!", "Aviso!!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCidadeF.Focus();
                return false;
            }
            return true;
        }

        private void grdDadosFuncionario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            preencheDadosControles();
        }
    }
}

           
