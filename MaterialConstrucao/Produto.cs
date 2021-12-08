using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace MaterialConstrucao
{
    public class csProduto
    {
        private string Cod;
        private string nomeProduto;
        private string descricao;
        private double qtd;
        private double preco;

        private ConexaoMySQL conexaoProd = new ConexaoMySQL();

        public void setCodProduto(string valor)
        {
            Cod = valor;
        }

        public string getCodProduto()
        {
            return Cod;
        }

        public void setNomeProduto(string valor)
        {
            nomeProduto = valor;
        }

        public string getNomeProduto()
        {
            return nomeProduto;
        }

        public void setDescricaoProduto(string valor)
        {
            descricao = valor;
        }

        public string getDescricaoProduto()
        {
            return descricao;
        }

        public void setQtdProduto(double valor)
        {
            qtd = valor;
        }

        public double getQtdProduto()
        {
            return qtd;
        }

        public void setValorProduto(double valor)
        {
            preco = valor;
        }

        public double getValorProduto()
        {
            return preco;
        }

        public void inserir()
        {
            string sql = "INSERT INTO produto VALUES (";
            sql += "'" + Cod + "', ";
            sql += "'" + nomeProduto + "', ";
            sql += "'" + descricao + "', ";
            sql += qtd.ToString() + ", ";
            sql += preco.ToString() + ")";
            conexaoProd.executarSql(sql);
        }

        public void delete()
        {
            string sql = "Delete from produto WHERE numero = " + Cod + ";";
            conexaoProd.executarSql(sql);
        }

        public void update()
        {
            string sql = "UPDATE produto SET ";
            sql += "nome = '" + nomeProduto + "', ";
            sql += "descricao = '" + descricao + "', ";
            sql += "qtd = " + qtd.ToString() + ", ";
            sql += "valor = " + preco.ToString() + ", ";
            sql += " WHERE numero = '" + Cod + "';";
            conexaoProd.executarSql(sql);
        }

        public DataTable Select()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable tabela = new DataTable();
            string sql = "Select numero, nome, descricao, qtd, preco from produto;";
            adapter = conexaoProd.executaRetornaDados(sql);
            adapter.Fill(tabela);
            return tabela;
        }

        public void selectProduto()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet dataSet = new DataSet();
            string sql = "SELECT nome, descricao, qtd, preco FROM produto WHERE numero = " + Cod + ";";
            adapter = conexaoProd.executaRetornaDados(sql);
            adapter.Fill(dataSet);

            nomeProduto = dataSet.Tables[0].Rows[0][0].ToString(); 
            descricao = dataSet.Tables[0].Rows[0][1].ToString();
            qtd = Convert.ToDouble(dataSet.Tables[0].Rows[0][2].ToString());
            preco = Convert.ToDouble(dataSet.Tables[0].Rows[0][3].ToString());
        }
    }
}
