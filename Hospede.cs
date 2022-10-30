using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeHotel
{
    public class Hospede
    {
        SqlCommand comandoSql = new SqlCommand();
        StringBuilder sql = new StringBuilder();
        DataTable dadosTabela = new DataTable();
        public void Salvar(string nome, string cpf, string endereco, string numero, string bairro, string cep, DateTime datanascimento, string email,
            string telefone, string cidade)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(Conexao.stringConexao))
                {
                    conexao.Open();

                    

                    sql.Append("INSERT INTO HOSPEDE (NOME_HOSPEDE, CPF, ENDERECO, NUMERO, BAIRRO, CEP, DATA_NASCIMENTO, EMAIL, TELEFONE, CIDADE)");
                    sql.Append(" VALUES (@nome, @cpf, @endereco, @numero, @bairro, @cep, @datanascimento, @email, @telefone, @cidade)");

                    comandoSql.Parameters.Add(new SqlParameter("@nome", nome));
                    comandoSql.Parameters.Add(new SqlParameter("@cpf", cpf));
                    comandoSql.Parameters.Add(new SqlParameter("@endereco", endereco));
                    comandoSql.Parameters.Add(new SqlParameter("@numero", numero));
                    comandoSql.Parameters.Add(new SqlParameter("@bairro", bairro));
                    comandoSql.Parameters.Add(new SqlParameter("@cep", cep));
                    comandoSql.Parameters.Add(new SqlParameter("@datanascimento", datanascimento));
                    comandoSql.Parameters.Add(new SqlParameter("@email", email));
                    comandoSql.Parameters.Add(new SqlParameter("@telefone", telefone));
                    comandoSql.Parameters.Add(new SqlParameter("@cidade", cidade));

                    comandoSql.CommandText = sql.ToString();
                    comandoSql.Connection = conexao;
                    comandoSql.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw new Exception("Ocorreu um erro no metodo salvar. Caso o problema persista entre em contato com o administrador do sistema.");
            }
        }

        public DataTable Listar()
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(Conexao.stringConexao))
                {
                    conexao.Open();

                    

                    sql.Append("SELECT * FROM HOSPEDE");
                    sql.Append(" ORDER BY ID_HOSPEDE DESC");

                    comandoSql.CommandText = sql.ToString();
                    comandoSql.Connection = conexao;
                    dadosTabela.Load(comandoSql.ExecuteReader());
                    return dadosTabela;

                }
            }
            catch (Exception)
            {

                throw new Exception("Ocorreu um erro no método Listar.Caso o problema persista entre em contato com o administrador do sistema.");
            }
        }

        public void Alterar(int idHospede, string nome, string cpf, string endereco, string numero, string bairro, string cep, DateTime datanascimento, string email,
            string telefone, string cidade)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(Conexao.stringConexao))
                {
                    conexao.Open();

                    sql.Append("UPDATE HOSPEDE");
                    sql.Append(" SET NOME_HOSPEDE = @nome, CPF = @cpf, ENDERECO = @endereco, NUMERO = @numero, BAIRRO = @bairro, CEP = @cep,");
                    sql.Append(" DATA_NASCIMENTO = @datanascimento, TELEFONE = @telefone, CIDADE = @cidade");
                    sql.Append(" Where (ID_HOSPEDE = @idHospede)");

                    comandoSql.Parameters.Add(new SqlParameter("@nome", nome));
                    comandoSql.Parameters.Add(new SqlParameter("@cpf", cpf));
                    comandoSql.Parameters.Add(new SqlParameter("@endereco", endereco));
                    comandoSql.Parameters.Add(new SqlParameter("@numero", numero));
                    comandoSql.Parameters.Add(new SqlParameter("@bairro",bairro));
                    comandoSql.Parameters.Add(new SqlParameter("@cep", cep));
                    comandoSql.Parameters.Add(new SqlParameter("@datanascimento", datanascimento));
                    comandoSql.Parameters.Add(new SqlParameter("@telefone", telefone));
                    comandoSql.Parameters.Add(new SqlParameter("@cidade", cidade));
                    comandoSql.Parameters.Add(new SqlParameter("@idHospede", idHospede));

                    comandoSql.CommandText = sql.ToString();
                    comandoSql.Connection = conexao;
                    comandoSql.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw new Exception("Ocorreu um erro no método Alterar. Caso o problema persista entre em contato com o administrador do sistema.");
            }
        }

        public void Excluir(int idHospede)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(Conexao.stringConexao))
                {
                    conexao.Open();

                    sql.Append("DELETE FROM HOSPEDE");
                    sql.Append(" WHERE (ID_HOSPEDE = @idHospede)");

                    comandoSql.Parameters.Add(new SqlParameter("@idHospede", idHospede));

                    comandoSql.CommandText = sql.ToString();
                    comandoSql.Connection = conexao;
                    comandoSql.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw new Exception("Ocorreu um erro no método Excluir. Caso o problema persista entre em contato com o administrador do sistema.");
            }
        }

        public DataTable PesquisarNome(string nome)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(Conexao.stringConexao))
                {
                    conexao.Open();



                    sql.Append("SELECT * FROM HOSPEDE");
                    sql.Append(" WHERE NOME_HOSPEDE LIKE '%'+@nome+'%'");
                    sql.Append(" ORDER BY ID_HOSPEDE DESC");

                    comandoSql.Parameters.Add(new SqlParameter("@nome", nome));
                    

                    comandoSql.CommandText = sql.ToString();
                    comandoSql.Connection = conexao;
                    dadosTabela.Load(comandoSql.ExecuteReader());
                    return dadosTabela;

                }
            }
            catch (Exception)
            {

                throw new Exception("Ocorreu um erro no método PesquisarNome. Caso o erro persista entre em contato o Administrador do sistema.");
            }
        }

        public DataTable PesquisarCPF(string cpf)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(Conexao.stringConexao))
                {
                    conexao.Open();

                    sql.Append("SELECT * FROM HOSPEDE");
                    sql.Append(" WHERE CPF LIKE '%'+@cpf+'%'");
                    sql.Append(" ORDER BY ID_HOSPEDE DESC");

                    comandoSql.Parameters.Add(new SqlParameter("@cpf", cpf));

                    comandoSql.CommandText = sql.ToString();
                    comandoSql.Connection = conexao;
                    dadosTabela.Load(comandoSql.ExecuteReader());
                    return dadosTabela;
                }
            }
            catch (Exception)
            {

                throw new Exception("Ocorreu um erro no método PesquisarCPF. Caso o erro persista entre em contato com o Administrador do sistema.");
            }
        }
    }
}
