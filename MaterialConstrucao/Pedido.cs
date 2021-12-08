using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;

namespace MaterialConstrucao
{
    public class csPedido
    {
        public Int32 id; // Auto Incremento
        public DateTime data;
        public string CPF_Cliente;
        public string codProduto;
        public string CPF_Funcionario;
        public double valorTotal;

        private ConexaoMySQL conexao = new ConexaoMySQL();

        public void setDataPedido(DateTime valor)
        {
            valor = data;
        }

        public DateTime getDataPedido()
        {
            return data;
        }

        public void setCPF_Cliente(string valor)
        {
            valor = CPF_Cliente;
        }

        public string getCPF_Cliente()
        {
            return CPF_Cliente;
        }

        public void setCPF_Funcionario(string valor)
        {
            valor = CPF_Funcionario;
        }

        public string getCPF_Funcionario()
        {
            return CPF_Funcionario;
        }

        private void setValorPedido(double valor)
        {
            valor = valorTotal;
        }

        public void inserir()
        {
            string sql = "INSERT INTO pedido(idCliente, idProduto, data, idFuncionario, valorTotal)";
            sql += "VALUES (";
            sql += "'" + CPF_Cliente + "', ";
            sql += "'" + codProduto + "', ";
            sql += "'" + data.ToString("yyyy-MM-DD") + "', ";
            sql += "'" + CPF_Funcionario + "'";
            sql += valorTotal.ToString() + ")";
            conexao.executarSql(sql);
        }

        public void update()
        {
            string sql = "UPDATE pedido SET ";
            sql += "idCliente = '" + CPF_Cliente + "', ";
            sql += "idProduto = '" + codProduto + "', ";
            sql += "data = '" + data.ToString("yyyy-MM-DD") + "', ";
            sql += "idFuncionario '" + CPF_Funcionario + "', ";
            sql += "valorTotal = " + valorTotal.ToString();
            sql += "WHERE id = " + id.ToString();
            conexao.executarSql(sql);
        }
        public void delete()
        {
            string sql = "DELETE FROM pedido WHERE id = " + id.ToString();
            conexao.executarSql(sql);
        }

        public void selectPedido()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet dataset = new DataSet();
            string sql = "SELECT id, idCliente, idProduto, data, idFuncionario, valorTotal FROM pedido WHERE id = " + id.ToString();
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(dataset);

            id = Convert.ToInt32(dataset.Tables[0].Rows[0][0].ToString());
            CPF_Cliente = dataset.Tables[0].Rows[0][1].ToString();
            codProduto = dataset.Tables[0].Rows[0][2].ToString();
            data = Convert.ToDateTime(dataset.Tables[0].Rows[0][3].ToString());
            CPF_Funcionario = dataset.Tables[0].Rows[0][4].ToString();
            valorTotal = Convert.ToDouble(dataset.Tables[0].Rows[0][5].ToString());
        }

        public void selectPedidoUltimo()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet dataset = new DataSet();
            string sql = "SELECT max(id) FROM pedido"; // Assistir a aula 
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(dataset);

            id = Convert.ToInt32(dataset.Tables[0].Rows[0][0].ToString());
        }
    }
}
