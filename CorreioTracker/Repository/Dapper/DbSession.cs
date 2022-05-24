using CorreioTracker.ConfigHandler;
using Npgsql;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CorreioTracker.Repository.Dapper
{
    public class DbSession : IDisposable
    {
        public IDbConnection Connection { get; }
        public DbSession(SystemConfigJson configuration)
        {
            Connection = new NpgsqlConnection(configuration.ConnectionsStrings.BancoTeste);

            Connection.Open();
        }
        public void Dispose() => Connection?.Dispose();
    }
}
