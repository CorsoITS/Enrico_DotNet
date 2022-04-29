using Enrico_DotNet.Repositories;
using Enrico_DotNet.Models;
using System.Security.Cryptography;
using System.Text;

namespace Enrico_DotNet.Service;

public class SedeService
{

    private SedeRepository sedeRepository = new SedeRepository();

    public IEnumerable<Sede> GetSede()
    {
        return sedeRepository.GetSede();
    }

    public Sede GetSede(int id)
    {
        return sedeRepository.GetSede(id);
    }

    public bool Create(Sede sede)
    {
        if (sedeRepository.GetSede(sede.Id) == null)
        {
            // if ((person.Nome.Length > 0) && (person.Cognome.Length > 0))
            // {
            //     return false;
            // }
            // else
            // {
                return sedeRepository.Create(sede);
            // }
        }
        else
        {
            return false;
        }

    }

    public bool Update(Sede sede)
    {
        return sedeRepository.Update(sede);
    }

    public bool Delete(int id)
    {
        return sedeRepository.Delete(id);
    }

    public string HashPassword(string plainText)
    {
        var byteArray = ASCIIEncoding.ASCII.GetBytes(plainText);
        byte[] mySHA256 = SHA256.Create().ComputeHash(byteArray);
        return Convert.ToBase64String(mySHA256);
    }

}