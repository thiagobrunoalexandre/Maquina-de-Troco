using MaquinaTroco.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MaquinaTroco.DAO.Query
{
    public class TablesQuery
    {
        public CallDB db;

        public TablesQuery(CallDB db)
        {
            this.db = db;
        }

        public List<Moeda> GetMoeda()
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = ("SELECT * FROM moeda ORDER BY valor_moeda DESC ");

            try
            {
                db.conexao.Open();
                MySqlDataReader reader = comm.ExecuteReader();
                List<Moeda> response = new List<Moeda>();

                while (reader.Read())
                {
                    Moeda moeda = new Moeda();
                    moeda.id_moeda = Convert.ToInt32(reader["id_moeda"]);
                    moeda.valor = Convert.ToDecimal(reader["valor_moeda"]);
                    moeda.quantidade = Convert.ToInt32(reader["quantidade_moeda"]);
                   
                    response.Add(moeda);

                }
                db.conexao.Close();
                return response;
            }
            catch (Exception e)
            {

                db.conexao.Close();
                return new List<Moeda>();
            }

        }
        public bool InsertMoeda(Moeda moeda)
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = "INSERT INTO moeda(valor_moeda,quantidade_moeda) VALUES(@valor, @quantidade)";
            comm.Parameters.AddWithValue("@valor", moeda.valor);
            comm.Parameters.AddWithValue("@quantidade", moeda.quantidade);

            try
            {
                db.conexao.Open();
                comm.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                db.conexao.Close(); //Fechando a conexão
            }

        }
        public bool MoedaExist(string valor_moeda)
        {
            var comm = db.conexao.CreateCommand();
            comm.CommandText = String.Format("SELECT * FROM moeda WHERE valor_moeda = '{0}' ", valor_moeda.Replace(',','.'));
            try
            {
                db.conexao.Open();

                MySqlDataReader reader = comm.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                db.conexao.Close();

            }
        }

        public bool UpdateMoeda(int id, int quantidade)
        {
            var cmd = db.conexao.CreateCommand();
            cmd.CommandText = String.Format("UPDATE moeda SET quantidade_moeda = {0}  WHERE id_moeda = '{1}' ",quantidade, id);
           
            try
            {
                db.conexao.Open();

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;  
            }
            finally
            {
                db.conexao.Close();
            }
        }

        public Moeda QuantidadeMoeda(string valor_moeda)
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = String.Format("SELECT * FROM moeda WHERE valor_moeda = '{0}' ", valor_moeda.Replace(',','.'));

            try
            {
                db.conexao.Open();
                MySqlDataReader reader = comm.ExecuteReader();
                Moeda moeda = new Moeda();

                while (reader.Read())
                {
                   
                    moeda.id_moeda = Convert.ToInt32(reader["id_moeda"]);
                    moeda.valor = Convert.ToDecimal(reader["valor_moeda"]);
                    moeda.quantidade = Convert.ToInt32(reader["quantidade_moeda"]);

                }
                db.conexao.Close();
                return moeda;
            }
            catch (Exception e)
            {

                db.conexao.Close();
                return new Moeda();
            }

        }
        public bool  DeleteMoeda(int id_moeda)
        {
            string Query = String.Format("DELETE FROM moeda WHERE id_moeda = {0}", id_moeda);

            using (MySqlCommand comm = new MySqlCommand(Query, db.conexao))
            {
                db.conexao.Open();
                try
                {
                    comm.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
                finally
                {
                    db.conexao.Close();

                }
            }
        }
    }
       
}
