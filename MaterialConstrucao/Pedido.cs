using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialConstrucao
{
    public class Pedido
    {
        public Int32 id; // Auto Incremento
        public DateTime data;
        public string CPF_Cliente;
        public string codProduto;
        public string CPF_Funcionario;
        public double valorTotal;

        private ConexaoMySQL conexao = new ConexaoMySQL();

        /*public void setPedidoId(Int32 valor)
        {
            valor = id;
        }

        public Int32 getPedidoId()
        {
            return id;
        }*/

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
            sql += "'" + CPF_Funcionario + "';";
            sql += valorTotal.ToString() + ")";
        }

        public void update()
        {

        }
        public void delete()
        {

        }
    }
}
