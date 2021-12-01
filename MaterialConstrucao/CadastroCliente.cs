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
    public partial class CadastroCliente : Form
    {
        csCliente client = new csCliente();
        
        private void habilitaControles(bool status)
        {
            txtNomeC.Enabled = status;
            cboSiglaC.Enabled = status;
            txtCidadeC.Enabled = status;
            txtCPF_C.Enabled = status;
            txtCEP_C.Enabled = status;
            txtTelefoneC.Enabled = status;
            txtNumeroC.Enabled = status;
        }

        private void limparControles()
        {
            txtNomeC.Text = "";
            cboSiglaC.SelectedIndex = -1;
            txtCidadeC.Text = "";
            txtCPF_C.Text = "";
            txtCEP_C.Text = "";
            txtTelefoneC.Text = "";
            txtNumeroC.Text = "";
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
            grdDadosCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            grdDadosCliente.Columns[0].HeaderText = "CPF";
            grdDadosCliente.Columns[1].HeaderText = "Nome";
            grdDadosCliente.Columns[2].HeaderText = "CEP";
            //grdDados.Columns[3].HeaderText = "Cidade";
            //grdDados.Columns[4].HeaderText = "Estado";
            //grdDados.Columns[5].HeaderText = "Número";
            //grdDados.Columns[6].HeaderText = "Telefone";

            grdDadosCliente.Columns[0].Width = 30;
            grdDadosCliente.Columns[1].Width = 70;
            grdDadosCliente.Columns[2].Width = 260;
            //grdDados.Columns[3].Width = 260;
            //grdDados.Columns[4].Width = 5;
            //grdDados.Columns[5].Width = 10;
            //grdDados.Columns[6].Width = 20;
        }
        
        private void preencheGrid()
        {
            grdDadosCliente.DataSource = client.select();
            formataGrid();
        }
        private void excluiCliente()
        {
            client.delete();
        }

        private void salvarCliente()
        {
            client.SetCPFCliente(txtCPF_C.Text);
            client.SetCEPCliente(txtCEP_C.Text);
            client.SetNomeCliente(txtNomeC.Text);
            client.SetTelefoneCliente(txtTelefoneC.Text);
            client.SetCidadeCliente(txtCidadeC.Text);
            client.SetEstadoCliente(Convert.ToInt16(cboSiglaC.SelectedIndex));
            client.SetNumeroCliente(txtNumeroC.Text);

            if (client.GetCPFCliente() == "")
            { 
                client.inserir();
            }
            else
            {
                client.update();
            }
        }
        private void preencheDadosControles()
        {
            client.selectCliente();

            txtNomeC.Text = client.GetNomeCliente();
            txtCidadeC.Text = client.GetCidadeCliente();
            txtNumeroC.Text = client.GetNumeroCliente();
            txtCEP_C.Text = client.GetCEPCliente();
            txtTelefoneC.Text = client.GetTelefoneCliente();
            txtCPF_C.Text = client.GetCPFCliente();

            cboSiglaC.SelectedIndex = client.GetEstadoCliente();
        }
        private void grdDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            client.SetCPFCliente((grdDadosCliente.Rows[grdDadosCliente.CurrentRow.Index].Cells[0].Value.ToString()));
            preencheDadosControles();
        }
        public CadastroCliente()
        {
            InitializeComponent();
        }

        private void CadastroCliente_Load(object sender, EventArgs e)
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
                salvarCliente();
                habilitaControles(false);
                limparControles();
                gerenciaBotoesBarra(true);
                preencheGrid();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (client.GetCPFCliente() != "")
            {
                DialogResult retorno = MessageBox.Show("Deseja excluir os dados do cliente selecionado?", "Exclusão",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (retorno == DialogResult.Yes)
                {
                    excluiCliente();
                    limparControles();
                    preencheGrid();
                }
            }
            else
            {
                MessageBox.Show("Selecione o Cliente para excluir", "Aviso!!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool validaDados()
        {
            if (txtNomeC.Text.Trim().Length <= 3)
            {
                MessageBox.Show("Nome do Cliente é obrigatório, informe!", "Aviso!!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNomeC.Focus(); 
                return false;
            }
            if (txtCPF_C.Text.Trim().Length != 14) 
            {
                MessageBox.Show("CPF é obrigatório, informe!", "Aviso!!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCPF_C.Focus(); 
                return false;
            }
             if (txtCEP_C.Text.Trim().Length != 9) 
            {
                MessageBox.Show("CEP é obrigatório, informe!", "Aviso!!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCEP_C.Focus(); 
                return false;
            }
            if (txtCidadeC.Text.Trim().Length <= 2)
            {
                MessageBox.Show("Nome da Cidade é obrigatório, informe!", "Aviso!!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCidadeC.Focus();
                return false;
            }
            return true;
        }

        
    }
}

