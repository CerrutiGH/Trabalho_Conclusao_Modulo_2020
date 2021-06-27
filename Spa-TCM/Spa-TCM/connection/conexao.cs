using MySql.Data.MySqlClient;
using System;

namespace Spa_TCM.connection
{
    public class conexao
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost; Database=spa;user=root;pwd=carol2004");
        public static string msg;

        public MySqlConnection ConectarBD()
        {
            try
            {
                connection.Open();
            }
            catch (Exception erro)
            {
                msg = "Erro ao conectar o Banco de Dados" + erro.Message;
            }
            return connection;
        }

        public MySqlConnection DesconectarBD()
        {
            try
            {
                connection.Close();
            }

            catch (Exception erro)
            {
                msg = "Não foi possível desconectar" + erro.Message;
            }
            return connection;
        }

    }
}