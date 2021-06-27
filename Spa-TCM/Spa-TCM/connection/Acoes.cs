using MySql.Data.MySqlClient;
using Spa_TCM.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Spa_TCM.connection
{
    public class Acoes
    {
        conexao connection = new conexao();
        MySqlCommand cmd = new MySqlCommand();

        public void CadastroCliente(Cliente idk)
        {
            MySqlCommand cmd = new MySqlCommand("Insert into tb_CLIENTE(NOME_CLI, EMAIL_CLI, SENHA_CLI, TELEFONE_CLI) values(@NOME_CLI, @EMAIL_CLI, @SENHA_CLI, @TELEFONE_CLI)", connection.ConectarBD());
            cmd.Parameters.Add("@NOME_CLI", MySqlDbType.Text).Value = idk.Nome;
            cmd.Parameters.Add("@EMAIL_CLI", MySqlDbType.VarChar).Value = idk.Email;
            cmd.Parameters.Add("@SENHA_CLI", MySqlDbType.VarChar).Value = idk.Senha;
            cmd.Parameters.Add("@TELEFONE_CLI", MySqlDbType.VarChar).Value = idk.Telefone;
            cmd.ExecuteNonQuery();
            connection.DesconectarBD();
        }

        internal object ListarFuncionarios()
        {
            throw new NotImplementedException();
        }

        public void CadastroFuncionario(FuncionarioData fdt)
        {
            MySqlCommand cmd = new MySqlCommand("Insert into tb_FUNCIONARIOS(NOME_FUN, EMAIL_FUN, SENHA_FUN, TELEFONE_FUN, RG_FUN, CPF_FUN, CEP_FUN, CIDADE_FUN, IDADE_FUN, CARGO_FUN) values(@NOME_FUN, @EMAIL_FUN, @SENHA_FUN, @TELEFONE_FUN, @RG_FUN, @CPF_FUN, @CEP_FUN, @CIDADE_FUN, @IDADE_FUN, @CARGO_FUN)", connection.ConectarBD());
            cmd.Parameters.Add("@NOME_FUN", MySqlDbType.Text).Value = fdt.NOME_FUN;
            cmd.Parameters.Add("@EMAIL_FUN", MySqlDbType.VarChar).Value = fdt.EMAIL_FUN;
            cmd.Parameters.Add("@SENHA_FUN", MySqlDbType.VarChar).Value = fdt.SENHA_FUN;
            cmd.Parameters.Add("@TELEFONE_FUN", MySqlDbType.VarChar).Value = fdt.TELEFONE_FUN;
            cmd.Parameters.Add("@RG_FUN", MySqlDbType.VarChar).Value = fdt.RG_FUN;
            cmd.Parameters.Add("@CPF_FUN", MySqlDbType.VarChar).Value = fdt.CPF_FUN;
            cmd.Parameters.Add("@CEP_FUN", MySqlDbType.VarChar).Value = fdt.CEP_FUN;
            cmd.Parameters.Add("@CIDADE_FUN", MySqlDbType.Text).Value = fdt.CIDADE_FUN;
            cmd.Parameters.Add("@CARGO_FUN", MySqlDbType.Text).Value = fdt.CARGO_FUN;
            cmd.Parameters.Add("@IDADE_FUN", MySqlDbType.VarChar).Value = fdt.IDADE_FUN;
            cmd.ExecuteNonQuery();
            connection.DesconectarBD();
        }





        public FuncionarioData ListarFuncionario(int cd)
        {
            MySqlCommand cmd = new MySqlCommand("Select * from tb_FUNCIONARIOS where ID_FUNC = {0}", connection.ConectarBD());

            var DadosFuncionarios = cmd.ExecuteReader();
            return ListarFuncionario(DadosFuncionarios).FirstOrDefault();
        }

        public List<FuncionarioData> ListarFuncionario(MySqlDataReader dt)
        {
            var AltAL = new List<FuncionarioData>();
            while (dt.Read())
            {
                var AlTemp = new FuncionarioData()
                {
                    COD_FUN = Convert.ToInt32(dt["COD_FUN"]),
                    NOME_FUN = dt["NOME_FUN"].ToString(),
                    EMAIL_FUN = dt["EMAIL_FUN"].ToString(),
                    SENHA_FUN = dt["SENHA_FUN"].ToString(),
                    IDADE_FUN = dt["IDADE_FUN"].ToString(),
                    TELEFONE_FUN = dt["TELEFONE_FUN"].ToString(),
                    CPF_FUN = dt["CPF_FUN"].ToString(),
                    RG_FUN = dt["RG_FUN"].ToString(),
                    CIDADE_FUN = dt["CIDADE_FUN"].ToString(),
                    CARGO_FUN = dt["CARGO_FUN"].ToString(),
                    CEP_FUN = dt["CEP_FUN"].ToString(),

                };
                AltAL.Add(AlTemp);
            }
            dt.Close();
            return AltAL;
        }


        public List<FuncionarioData> ListarFuncionario()
        {
            MySqlCommand cmd = new MySqlCommand("select * from tb_FUNCIONARIOS", connection.ConectarBD());
            var DadosFuncionarios = cmd.ExecuteReader();
            return ListarFuncionario(DadosFuncionarios);
        }


        public List<FuncionarioData> ListarFuncionarios(MySqlDataReader dt)
        {
            var AllFun = new List<FuncionarioData>();
            while (dt.Read())
            {
                var FunTemp = new FuncionarioData()
                {
                    COD_FUN = Convert.ToInt32(dt["COD_FUN"]),
                    NOME_FUN = dt["NOME_FUN"].ToString(),
                    EMAIL_FUN = dt["EMAIL_FUN"].ToString(),
                    SENHA_FUN = dt["SENHA_FUN"].ToString(),
                    IDADE_FUN = dt["IDADE_FUN"].ToString(),
                    TELEFONE_FUN = dt["TELEFONE_FUN"].ToString(),
                    CPF_FUN = dt["CPF_FUN"].ToString(),
                    RG_FUN = dt["RG_FUN"].ToString(),
                    CIDADE_FUN = dt["CIDADE_FUN"].ToString(),
                    CARGO_FUN = dt["CARGO_FUN"].ToString(),
                    CEP_FUN = dt["CEP_FUN"].ToString(),
                };
                AllFun.Add(FunTemp);
            }
            dt.Close();
            return AllFun;
        }



        public void UpdateFuncionario(FuncionarioData upd, int id)
        {

            MySqlCommand cmd = new MySqlCommand("Update tb_FUNCIONARIOS set NOME_FUN = @NOME_FUN, EMAIL_FUN = @EMAIL_FUN, SENHA_FUN = @SENHA_FUN, TELEFONE_FUN = @TELEFONE_FUN, RG_FUN = @RG_FUN, CPF_FUN = @CPF_FUN, CEP_FUN = @CEP_FUN, CIDADE_FUN = @CIDADE_FUN, IDADE_FUN = @IDADE_FUN, CARGO_FUN = @CARGO_FUN where COD_FUN = " + id + " ", connection.ConectarBD());


            cmd.Parameters.AddWithValue("@NOME_FUN", upd.NOME_FUN);
            cmd.Parameters.AddWithValue("@EMAIL_FUN", upd.EMAIL_FUN);
            cmd.Parameters.AddWithValue("@SENHA_FUN", upd.SENHA_FUN);
            cmd.Parameters.AddWithValue("@TELEFONE_FUN", upd.TELEFONE_FUN);
            cmd.Parameters.AddWithValue("@RG_FUN", upd.RG_FUN);
            cmd.Parameters.AddWithValue("@CPF_FUN", upd.CPF_FUN);
            cmd.Parameters.AddWithValue("@CEP_FUN", upd.CEP_FUN);
            cmd.Parameters.AddWithValue("@CIDADE_FUN", upd.CIDADE_FUN);
            cmd.Parameters.AddWithValue("@IDADE_FUN", upd.IDADE_FUN);
            cmd.Parameters.AddWithValue("@CARGO_FUN", upd.CARGO_FUN);

            cmd.ExecuteNonQuery();
            connection.DesconectarBD();

        }




        public void DeleteFuncionario(FuncionarioData upd, int id)
        {

            MySqlCommand cmd = new MySqlCommand("Delete from tb_FUNCIONARIOS where COD_FUN = @COD_FUN", connection.ConectarBD());

            cmd.Parameters.AddWithValue("@COD_FUN", id);
            cmd.ExecuteNonQuery();
            connection.DesconectarBD();

        }



        public FuncionarioData TestarUsuario(FuncionarioData user)
        {


            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tb_FUNCIONARIOS where EMAIL_FUN = @EMAIL_FUN AND SENHA_FUN = @SENHA_FUN AND CARGO_FUN = @CARGO_FUN", connection.ConectarBD());

            cmd.Parameters.Add("@CARGO_FUN", MySqlDbType.Text).Value = user.CARGO_FUN;
            cmd.Parameters.Add("@EMAIL_FUN", MySqlDbType.VarChar).Value = user.EMAIL_FUN;
            cmd.Parameters.Add("@SENHA_FUN", MySqlDbType.VarChar).Value = user.SENHA_FUN;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    FuncionarioData dt = new FuncionarioData();
                    {
                        dt.CARGO_FUN = Convert.ToString(leitor["CARGO_FUN"]);
                        dt.EMAIL_FUN = Convert.ToString(leitor["EMAIL_FUN"]);
                        dt.SENHA_FUN = Convert.ToString(leitor["SENHA_FUN"]);
                    }

                }
            }


            else
            {
                user.CARGO_FUN = null;
                user.EMAIL_FUN = null;
                user.SENHA_FUN = null;
            }
            return user;
        }





        public void MarcarReserva(Reserva fdt)
        {
            MySqlCommand cmd = new MySqlCommand("Insert into tb_RESERVA (EMAIL_CLI, RESERVA_DATA, RESERVA_HORA, RESERVA_QTD) values(@EMAil_CLI, @RESERVA_DATA, @RESERVA_HORA, @RESERVA_QTD)", connection.ConectarBD());
            cmd.Parameters.Add("@EMAIL_CLI", MySqlDbType.VarChar).Value = fdt.EMAIL_CLI;
            cmd.Parameters.Add("@RESERVA_DATA", MySqlDbType.Date).Value = fdt.RESERVA_DATA;
            cmd.Parameters.Add("@RESERVA_HORA", MySqlDbType.Time).Value = TimeSpan.Parse(fdt.RESERVA_HORA);
            cmd.Parameters.Add("@RESERVA_QTD", MySqlDbType.Int32).Value = fdt.RESERVA_QTD;
            cmd.ExecuteNonQuery();
            connection.DesconectarBD();
        }








        public Reserva ListarReservas(int cd)
        {
            MySqlCommand cmd = new MySqlCommand("Select * from tb_RESERVA where COD_RES = {0}", connection.ConectarBD());

            var DadosReserva = cmd.ExecuteReader();
            return ListarReservas(DadosReserva).FirstOrDefault();
        }

        public List<Reserva> ListarResrevas(MySqlDataReader dt)
        {
            var AltAL = new List<Reserva>();
            while (dt.Read())
            {
                var AllRes = new Reserva()
                {
                    COD_RES = Convert.ToInt32(dt["COD_RES"]),
                    EMAIL_CLI = dt["EMAIL_CLI"].ToString(),
                    RESERVA_DATA = dt["RESERVA_DATA"].ToString(),
                    RESERVA_HORA = dt["RESERVA_HORA"].ToString(),
                    RESERVA_QTD = dt["RESERVA_QTD"].ToString(),

                };
                AltAL.Add(AllRes);
            }
            dt.Close();
            return AltAL;
        }


        public List<Reserva> ListarReservas()
        {
            MySqlCommand cmd = new MySqlCommand("select * from tb_RESERVA", connection.ConectarBD());
            var DadosReserva = cmd.ExecuteReader();
            return ListarReservas(DadosReserva);
        }

        public List<Reserva> ListarReservas(MySqlDataReader dt)
        {
            var AllRes = new List<Reserva>();
            while (dt.Read())
            {
                var ResTemp = new Reserva()
                {
                    COD_RES = Convert.ToInt32(dt["COD_RES"]),
                    EMAIL_CLI = dt["EMAIL_CLI"].ToString(),
                    RESERVA_DATA = dt["RESERVA_DATA"].ToString(),
                    RESERVA_HORA = dt["RESERVA_HORA"].ToString(),
                    RESERVA_QTD = dt["RESERVA_QTD"].ToString(),
                };
                AllRes.Add(ResTemp);
            }
            dt.Close();
            return AllRes;
        }






        public void DeleteReserva(Reserva upd, int id)
        {

            MySqlCommand cmd = new MySqlCommand("Delete from tb_RESERVA where COD_RES = @COD_RES", connection.ConectarBD());

            cmd.Parameters.AddWithValue("@COD_RES", id);
            cmd.ExecuteNonQuery();
            connection.DesconectarBD();

        }



        public void UpdateReservas(Reserva upd, int id)
        {

            MySqlCommand cmd = new MySqlCommand("Update tb_RESERVA set EMAIL_CLI = @EMAIL_CLI, RESERVA_DATA = @RESERVA_DATA, RESERVA_HORA = @RESERVA_HORA, RESERVA_QTD = @RESERVA_QTD WHERE COD_RES = " + id + "", connection.ConectarBD());


            cmd.Parameters.AddWithValue("@EMAIL_CLI", upd.EMAIL_CLI);
            cmd.Parameters.AddWithValue("@RESERVA_DATA", upd.RESERVA_DATA);
            cmd.Parameters.AddWithValue("@RESERVA_HORA", upd.RESERVA_HORA);
            cmd.Parameters.AddWithValue("@RESERVA_QTD", upd.RESERVA_QTD);
            cmd.ExecuteNonQuery();
            connection.DesconectarBD();

        }

    }

}
