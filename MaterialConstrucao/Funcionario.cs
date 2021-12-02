using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialConstrucao
{
    public class csFuncionario
    {
		private string nomeFuncionario;
		private string CPF; // chave
		private string telefone;

		private ConexaoMySQL conexaoFunc = new ConexaoMySQL();

		public void setNomeFuncionario(string valor)
        {
            nomeFuncionario = valor;
        }

		public string getNomeFuncionario()
        {
			return nomeFuncionario;
        }

        public void setCPF_Funcionario(string valor)
        {
            CPF = valor;
        }
        public string getCPF_Funcionario()
        {
            return CPF;
        }

        public void setTelefoneFuncionario(string valor)
        {
            telefone = valor;
        }

        public string getTelefoneFuncionario()
        {
            return telefone;
        }

        public void inserir()
        {
            string sql = "INSERT INTO funcionario(CPF, nome, telefone) Values (";
            sql += "'" + CPF + "', ";
            sql += "'" + nomeFuncionario + "', ";
            sql += "'" + telefone + "', ";
            conexaoFunc.executarSql(sql);
        }

        public void delete()
        {

        }

        public void update()
        {

        }
    }
}

