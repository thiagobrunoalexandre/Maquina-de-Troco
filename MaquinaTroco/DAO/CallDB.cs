using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.IO;

public class CallDB : IDisposable
{
 
    public MySqlConnection conexao;

    public CallDB(DBSource dbSource)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        string connString = "";
        if (dbSource == DBSource.maquinaTroco)
        {
            connString = "maquina_troco_db";
        }
       

        IConfigurationRoot configuration = config.Build();
        conexao = new MySqlConnection(configuration.GetConnectionString(connString));
    }

    public void Dispose()
    {
        conexao.Close();
    }
}

public enum DBSource
{
    maquinaTroco,
   
}