using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeHotel
{
    public class Conexao
    {
        private static string conexao = @"Data Source=brauliodev\sqlexpress;Initial Catalog=SisHotel;Persist Security Info=True;User ID=sa;Password=Pal@1010";

        public static string stringConexao
        {
            get { return conexao; }
        }
    }
}
