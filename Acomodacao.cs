using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeHotel
{
    public class Acomodacao
    {
        SqlCommand comandosql = new SqlCommand();
        StringBuilder sql = new StringBuilder();

        //Método que irá Salvar as informação conforme os parametros que possui entre parênteses
        public void Salva(int TipoAcomodacao, int Andar)
        {

            try // Estrutura try, qual tentar realizar o que esta entre chaves
            {
                //Estabelece a conexão com o banco atraves da string de conexão
                using (SqlConnection conexao = new SqlConnection(Conexao.stringConexao))
                {
                    conexao.Open();//Abre a conexão com o banco de dados

                    //Comando sql para inserção de valores nos respectivos campos na tabela Acomodação
                    sql.Append("INSERT INTO Acomodacao (ID_TpAcomodacao, Andar)");
                    sql.Append("VALUES (@TipoAcomodacao, @Andar)");

                    //Relaciona cada valor com seu respectivo parametros
                    comandosql.Parameters.Add (new SqlParameter("@TipoAcomodacao", TipoAcomodacao));
                    comandosql.Parameters.Add(new SqlParameter("@Andar", Andar));

                    comandosql.CommandText = sql.ToString(); //Indica SQL é que devera ser executado
                    comandosql.Connection = conexao; //Indica que a conexão dos comandos sql é que estamos utilizando como string de conexão
                    comandosql.ExecuteNonQuery(); //Indica a inserção de dados no banco.
                }

            }
            catch (Exception)
            {

                throw new Exception("Ocorreu um erro no método Salvar. Caso o problema persista, entre em contato com o Administrador do sistema.");
            }
        }
    }
}
