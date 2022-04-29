using Enrico_DotNet.Context;
using MySql.Data.MySqlClient;
using Enrico_DotNet.Models;

namespace Enrico_DotNet.Repositories;

public class OperatoreRepository
{

    private AppDb appDb = new AppDb();

    public IEnumerable<Operatore> GetOperatore()
    {
        var result = new List<Operatore>();

        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "select * from operatore";
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var operatore = new Operatore()
            {
                Id = reader.GetInt16("id"),
                Ruolo = reader.GetString("ruolo"),
                Nome = reader.GetString("nome"),
                Cognome = reader.GetString("cognome"),
                UserName = reader.GetString("username"),
                Password = reader.GetString("password"),
                SedeId = reader.GetInt16("sede_id")
            };
            result.Add(operatore);
        }
        appDb.Connection.Close();

        return result;
    }

    public Operatore GetOperatore(int? id)
    {
        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "select * from operatore where id=@id";
        var parameter = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.Int16,
            Value = id
        };
        command.Parameters.Add(parameter);
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var operatore = new Operatore()
            {
                Id = reader.GetInt16("id"),
                Ruolo = reader.GetString("ruolo"),
                Nome = reader.GetString("nome"),
                Cognome = reader.GetString("cognome"),
                UserName = reader.GetString("username"),
                Password = reader.GetString("password"),
                SedeId = reader.GetInt16("sede_id")
            };
            appDb.Connection.Close();
            return operatore;
        }

        appDb.Connection.Close();
        return null;
    }

    public bool Create(Operatore operatore)
    {
        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "insert into operatore (ruolo,nome,cognome,username,password,sede_id) values (@ruolo,@nome,@cognome,@username,@password,@sede_id)";
        var parameterRuolo = new MySqlParameter()
        {
            ParameterName = "ruolo",
            DbType = System.Data.DbType.String,
            Value = operatore.Ruolo
        };
        command.Parameters.Add(parameterRuolo);
        var parameterNome = new MySqlParameter()
        {
            ParameterName = "nome",
            DbType = System.Data.DbType.String,
            Value = operatore.Nome
        };
        command.Parameters.Add(parameterNome);
        var parameterCognome = new MySqlParameter()
        {
            ParameterName = "cognome",
            DbType = System.Data.DbType.String,
            Value = operatore.Cognome
        };
        command.Parameters.Add(parameterCognome);
        var parameterUsername = new MySqlParameter()
        {
            ParameterName = "username",
            DbType = System.Data.DbType.String,
            Value = operatore.UserName
        };
        command.Parameters.Add(parameterUsername);
        var parameterPassword = new MySqlParameter()
        {
            ParameterName = "password",
            DbType = System.Data.DbType.String,
            Value = operatore.Password
        };
        command.Parameters.Add(parameterPassword);
        var parameterSedeid = new MySqlParameter()
        {
            ParameterName = "sede_id",
            DbType = System.Data.DbType.Int16,
            Value = operatore.SedeId
        };
        command.Parameters.Add(parameterSedeid);

        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDb.Connection.Close();
        return result;
    }

    public bool Update(Operatore operatore)
    {
        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "update operatore set ruolo=@ruolo,nome=@nome,cognome=@cognome,username=@username,password=@password,sede_id=@sede_id where id=@id";
        var parameterId = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.Int16,
            Value = operatore.Id
        };
        command.Parameters.Add(parameterId);
        var parameterRuolo = new MySqlParameter()
        {
            ParameterName = "ruolo",
            DbType = System.Data.DbType.String,
            Value = operatore.Ruolo
        };
        command.Parameters.Add(parameterRuolo);
        var parameterNome = new MySqlParameter()
        {
            ParameterName = "nome",
            DbType = System.Data.DbType.String,
            Value = operatore.Nome
        };
        command.Parameters.Add(parameterNome);
        var parameterCognome = new MySqlParameter()
        {
            ParameterName = "cognome",
            DbType = System.Data.DbType.String,
            Value = operatore.Cognome
        };
        command.Parameters.Add(parameterCognome);
        var parameterUsername = new MySqlParameter()
        {
            ParameterName = "username",
            DbType = System.Data.DbType.String,
            Value = operatore.UserName
        };
        command.Parameters.Add(parameterUsername);
        var parameterPassword = new MySqlParameter()
        {
            ParameterName = "password",
            DbType = System.Data.DbType.String,
            Value = operatore.Password
        };
        command.Parameters.Add(parameterPassword);
        var parameterSedeid = new MySqlParameter()
        {
            ParameterName = "sede_id",
            DbType = System.Data.DbType.Int16,
            Value = operatore.SedeId
        };
        command.Parameters.Add(parameterSedeid);

        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDb.Connection.Close();
        return result;
    }

    public bool Delete(int id)
    {
        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "delete from operatore where id=@id";
        var parameterId = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.Int16,
            Value = id
        };
        command.Parameters.Add(parameterId);
        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDb.Connection.Close();
        return result;
    }

}