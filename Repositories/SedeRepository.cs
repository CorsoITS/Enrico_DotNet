using Enrico_DotNet.Context;
using MySql.Data.MySqlClient;
using Enrico_DotNet.Models;

namespace Enrico_DotNet.Repositories;

public class SedeRepository
{

    private AppDb appDb = new AppDb();

    public IEnumerable<Sede> GetSede()
    {
        var result = new List<Sede>();

        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "select * from sede";
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var sede = new Sede()
            {
                Id = reader.GetInt16("id"),
                Nome = reader.GetString("nome"),
                Citta = reader.GetString("citta"),
                Indirizzo = reader.GetString("indirizzo")
            };
            result.Add(sede);
        }
        appDb.Connection.Close();

        return result;
    }

    public Sede GetSede(int? id)
    {
        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "select * from sede where id=@id";
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
            var sede = new Sede()
            {
                Id = reader.GetInt16("id"),
                Nome = reader.GetString("nome"),
                Citta = reader.GetString("citta"),
                Indirizzo = reader.GetString("indirizzo")
            };
            appDb.Connection.Close();
            return sede;
        }

        appDb.Connection.Close();
        return null;
    }

    public bool Create(Sede sede)
    {
        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "insert into sede (nome,citta,indirizzo) values (@nome,@citta,@indirizzo)";
        var parameterNome = new MySqlParameter()
        {
            ParameterName = "nome",
            DbType = System.Data.DbType.String,
            Value = sede.Nome
        };
        command.Parameters.Add(parameterNome);
        var parameterCitta = new MySqlParameter()
        {
            ParameterName = "citta",
            DbType = System.Data.DbType.String,
            Value = sede.Citta
        };
        command.Parameters.Add(parameterCitta);
        var parameterIndirizzo = new MySqlParameter()
        {
            ParameterName = "indirizzo",
            DbType = System.Data.DbType.String,
            Value = sede.Indirizzo
        };
        command.Parameters.Add(parameterIndirizzo);
        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDb.Connection.Close();
        return result;
    }

    public bool Update(Sede sede)
    {
        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "update sede set nome=@nome,citta=@citta,indirizzo=@indirizzo where id=@id";
        var parameterId = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.Int16,
            Value = sede.Id
        };
        command.Parameters.Add(parameterId);
        var parameterNome = new MySqlParameter()
        {
            ParameterName = "Nome",
            DbType = System.Data.DbType.String,
            Value = sede.Nome
        };
        command.Parameters.Add(parameterNome);
        var parameterCitta = new MySqlParameter()
        {
            ParameterName = "citta",
            DbType = System.Data.DbType.String,
            Value = sede.Citta
        };
        command.Parameters.Add(parameterCitta);
        var parameterIndirizzo = new MySqlParameter()
        {
            ParameterName = "indirizzo",
            DbType = System.Data.DbType.String,
            Value = sede.Indirizzo
        };
        command.Parameters.Add(parameterIndirizzo);

        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDb.Connection.Close();
        return result;
    }

    public bool Delete(int id)
    {
        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "delete from sede where id=@id";
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