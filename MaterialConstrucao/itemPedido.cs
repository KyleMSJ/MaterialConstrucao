﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;

namespace MaterialConstrucao
{
    class csItemPedido
    {
        private Int32 id;
        private Int32 idProduto;
        private Int32 idPedido;
        private Int32 quantidade;

        private ConexaoMySQL conexao = new ConexaoMySQL();

        public void setItemPedidoId(Int32 valor)
        {
            id = valor;
        }

        public Int32 getItemPedidoId()
        {
            return id;
        }

        public void setIdProduto(Int32 valor)
        {
            idProduto = valor;
        }

        public Int32 getIdProduto()
        {
            return idProduto;
        }

        public void setIdPedido(Int32 valor)
        {
            idPedido = valor;
        }

        public Int32 getIdPedido()
        {
            return idPedido;
        }

        public void setQuantidade(Int32 valor)
        {
            quantidade = valor;
        }

        public Int32 getQuantidade()
        {
            return quantidade;
        }

        public void inserir()
        {
            string sql = "INSERT INTO itempedido (itempedidoid, pedidoid, produtoid, itempedidoquantidade) ";
            sql += "VALUES (";
            sql += id.ToString() + ", " + idPedido.ToString() + ", " + idProduto.ToString() + ", ";
            sql += quantidade.ToString() + ")";
            conexao.executarSql(sql);
        }
        public void update()
        {
            string sql = "UPDATE itempedido SET pedidoid = " + idPedido.ToString() + ", ";
            sql += "produtoid" + idProduto.ToString() + ", itempedidoquantidade = " + quantidade.ToString();
            sql += " WHERE itempedidoid = " + id.ToString();
            conexao.executarSql(sql);
        }
        public void delete()
        {
            string sql = "DELETE FROM itempedido WHERE itemPedidoId = " + id.ToString();
            conexao.executarSql(sql);
        }
        
        public void deleteAll()
        {
            string sql = "DELETE FROM itempedido WHERE PedidoId = " + id.ToString();
            conexao.executarSql(sql);
        }

        public DataTable select()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable tabela = new DataTable();
            string sql = "SELECT itempedidoid, pedidoid, produtoid, itempedidoquantidade FROM itempedido";
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(tabela);
            return tabela;
        }

        public void selectItemPedido()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet dataset = new DataSet();
            string sql = "SELECT itempedidoid, pedidoid, produtoid, itempedidoquantidade FROM itempedido";
            sql += " WHERE itemPedidoId = " + id.ToString();
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(dataset);

            id = Convert.ToInt32(dataset.Tables[0].Rows[0][0].ToString());
            idPedido = Convert.ToInt32(dataset.Tables[0].Rows[0][1].ToString());
            idProduto = Convert.ToInt32(dataset.Tables[0].Rows[0][2].ToString());
            quantidade = Convert.ToInt32(dataset.Tables[0].Rows[0][3].ToString());
        }

        public DataSet selectItemPedido_do_Pedido()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet dataset = new DataSet();
            string sql = "SELECT itempedidoid, codigoid, produtonome, itempedidoquantidade ";
            sql += " FROM itempedido "; 
            sql += " inner join produto on itempedido.produtoid = produto.codigoid "; // Assistir aula
            sql += "where pedidoid = " + id.ToString();
            adapter = conexao.executaRetornaDados(sql);
            adapter.Fill(dataset);
            return dataset;
        }
    }
}
