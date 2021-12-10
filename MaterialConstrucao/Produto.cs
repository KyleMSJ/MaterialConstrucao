using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Globalization;

namespace MaterialConstrucao
{
    public class csProduto
    {
        private string Cod;
        private string nomeProduto;
        private string descricao;
        private double preco;
        //string texto = preco.ToString("N", CultureInfo.CreateSpecificCulture("en-US"));
        //Console.WriteLine(value.ToString(specifier, CultureInfo.InvariantCulture)); - formato US com '.'
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
            string sql = "INSERT INTO produto (numero, nome, descricao, preco) VALUES (";
            sql += "'" + Cod + "', ";
            sql += "'" + nomeProduto + "', ";
            sql += "'" + descricao + "', ";
            sql += preco.ToString() + ")";
            conexaoProd.executarSql(sql);
        }
        //INSERT INTO produto (numero, nome, descricao, preco) VALUES ('302046', 'Chave de Fenda Tramontina',
        //'Chave de fenda 1.5mm', 25,7.80);
        public void delete()
        {
            string sql = "Delete from produto WHERE numero = " + Cod + ";";
            conexaoProd.executarSql(sql);
        }

        public void update()
        {
            string sql = "UPDATE produto SET "; 
            sql += "nome = '" + nomeProduto + "',";
            sql += "descricao = '" + descricao + "',";
            sql += "preco = " + preco.ToString() + " WHERE numero = " + Cod + ";";
            conexaoProd.executarSql(sql);
        }
        //string valor = dr["valordobanco"].toString().Replace(',', '.');
        // UPDATE produto SET nome = 'Pia Azul', descricao = 'Pia de banheiro', preco = '119.90' WHERE numero = 6523
        public DataTable Select()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable tabela = new DataTable();
            string sql = "Select numero, nome, descricao, preco from produto;";
            adapter = conexaoProd.executaRetornaDados(sql);
            adapter.Fill(tabela);
            return tabela;
        }

        public void selectProduto()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet dataSet = new DataSet();
            string sql = "SELECT nome, descricao, preco FROM produto WHERE numero = '" + Cod + "';";
            adapter = conexaoProd.executaRetornaDados(sql);
            adapter.Fill(dataSet);

            nomeProduto = dataSet.Tables[0].Rows[0][0].ToString(); 
            descricao = dataSet.Tables[0].Rows[0][1].ToString();
            preco = Convert.ToDouble(dataSet.Tables[0].Rows[0][2].ToString());
        }
    }
}
