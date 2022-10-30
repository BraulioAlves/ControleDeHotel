using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace ControleDeHotel
{
    public class Funcionario 
    {
        SqlCommand comandoSql = new SqlCommand();
        StringBuilder sql = new StringBuilder();
        DataTable dadosTabela = new DataTable();

        
        public void Salvar(string nome, string cpf, string endereco, string numero, string bairro, string cep, DateTime dtNascimento, string email, string cidade, string telefone)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(Conexao.stringConexao))
                {
                    conexao.Open();

                    sql.Append(" INSERT INTO FUNCIONARIO(NOME_FUNCIONARIO, CPF, ENDERECO, NUMERO, BAIRRO, CEP, DATA_NASCIMENTO, EMAIL, CIDADE, TELEFONE)");
                    sql.Append(" VALUES (@nome, @cpf, @endereco, @numero, @bairro, @cep, @dtnascimento, @email, @cidade, @telefone)");

                    comandoSql.Parameters.AddWithValue("@nome", nome);
                    comandoSql.Parameters.AddWithValue("@cpf", cpf);
                    comandoSql.Parameters.AddWithValue("@endereco", endereco);
                    comandoSql.Parameters.AddWithValue("@numero", numero);
                    comandoSql.Parameters.AddWithValue("@bairro", bairro);
                    comandoSql.Parameters.AddWithValue("@cep", cep);
                    comandoSql.Parameters.AddWithValue("@dtnascimento", dtNascimento);
                    comandoSql.Parameters.AddWithValue("@email", email);
                    comandoSql.Parameters.AddWithValue("@cidade", cidade);
                    comandoSql.Parameters.AddWithValue("@telefone", telefone);

                    comandoSql.CommandText = sql.ToString();
                    comandoSql.Connection = conexao;
                    comandoSql.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw new Exception("Ocorreu erro no método Salvar. Caso o erro persista entre em contato com o Administrador do sistema.");
            }
        }

        public void Alterar(int idFuncionario, string nome, string cpf, string endereco, string numero, string bairro, string cep, DateTime dtNascimento, string email, string cidade,
            string telefone)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(Conexao.stringConexao))
                {
                    conexao.Open();

                    sql.Append("UPDATE FUNCIONARIO");
                    sql.Append(" SET NOME_FUNCIONARIO = @nome, CPF = @cpf, ENDERECO = @endereco, NUMERO = @numero,");
                    sql.Append(" BAIRRO = @bairro, CEP = @cep, DATA_NASCIMENTO = @dtNascimento, EMAIL = @email,");
                    sql.Append(" CIDADE = @cidade, TELEFONE = @telefone");
                    sql.Append(" WHERE (ID_FUNCIONARIO = @idFuncionario)");

                    comandoSql.Parameters.Add(new SqlParameter("@nome", nome));
                    comandoSql.Parameters.Add(new SqlParameter("@cpf", cpf));
                    comandoSql.Parameters.Add(new SqlParameter("@endereco", endereco));
                    comandoSql.Parameters.Add(new SqlParameter("@numero", numero));
                    comandoSql.Parameters.Add(new SqlParameter("@bairro", bairro));
                    comandoSql.Parameters.Add(new SqlParameter("@cep", cep));
                    comandoSql.Parameters.Add(new SqlParameter("@dtNascimento", dtNascimento));
                    comandoSql.Parameters.Add(new SqlParameter("@email", email));
                    comandoSql.Parameters.Add(new SqlParameter("@cidade", cidade));
                    comandoSql.Parameters.Add(new SqlParameter("@telefone", telefone));
                    comandoSql.Parameters.Add(new SqlParameter("@idFuncionario", idFuncionario));

                    comandoSql.CommandText = sql.ToString();
                    comandoSql.Connection = conexao;
                    comandoSql.ExecuteNonQuery();

                }
            }
            catch (Exception)
            {

                throw new Exception("Ocorreu erro no método Alterar. Caso o erro persista entre com contato com o Administrador do sistema.");
            }
        }

        public void Excluir(int cdFuncionario)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(Conexao.stringConexao))
                {
                    conexao.Open();

                    sql.Append(" DELETE FROM FUNCIONARIO");
                    sql.Append(" WHERE (ID_FUNCIONARIO = @cdFuncionario)");

                    
                    comandoSql.Parameters.Add(new SqlParameter("@cdFuncionario", cdFuncionario));

                    comandoSql.CommandText = sql.ToString();
                    comandoSql.Connection = conexao;
                    comandoSql.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro no método Excluir. Caso o erro persista entre em contato com o Administrador do sistema.");
            }
        }

        public DataTable Listar()
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(Conexao.stringConexao))
                {
                    conexao.Open();

                    sql.Append("SELECT * FROM FUNCIONARIO");
                    sql.Append(" ORDER BY ID_FUNCIONARIO DESC");

                    comandoSql.CommandText = sql.ToString();
                    comandoSql.Connection = conexao;
                    dadosTabela.Load(comandoSql.ExecuteReader());
                    return dadosTabela;
                }
            }
            catch (Exception)
            {

                throw new Exception("Ocorreu erro no método Listar. Caso o erro persista entre contato com o Administrador do sistema.");
            }
        }

        public DataTable PesquisarNome(string nome)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(Conexao.stringConexao))
                {
                    conexao.Open();

                    sql.Append("SELECT * FROM FUNCIONARIO");
                    sql.Append(" WHERE (NOME_FUNCIONARIO  LIKE '%'+@nome+'%')");
                    sql.Append(" ORDER BY ID_FUNCIONARIO DESC");

                    comandoSql.Parameters.Add(new SqlParameter("@nome", nome));

                    comandoSql.CommandText = sql.ToString();
                    comandoSql.Connection = conexao;
                    dadosTabela.Load(comandoSql.ExecuteReader());
                    return dadosTabela;
                }
            }
            catch (Exception)
            {

                throw new Exception("Ocorreu um erro no método PesquisarNome. Caso o erro persista entre em contato com o Administrador do sistema.");
            }
        }

        public DataTable PesquisarCPF(string cpf)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(Conexao.stringConexao))
                {
                        conexao.Open();

                        sql.Append("SELECT * FROM FUNCIONARIO");
                        sql.Append(" WHERE (CPF LIKE '%'+@cpf+'%')");
                        sql.Append(" ORDER BY ID_FUNCIONARIO DESC");

                        comandoSql.Parameters.Add(new SqlParameter("@cpf", cpf));

                        comandoSql.CommandText = sql.ToString();
                        comandoSql.Connection = conexao;
                        dadosTabela.Load(comandoSql.ExecuteReader());
                        return dadosTabela;
                }
                
            }
            catch (Exception)
            {

                throw new Exception("Ocorreu um erro no método PesquisarCPF. Caso o erro persista entre contato com o Administrador do sistema. ");
            }
        }
    }
}
