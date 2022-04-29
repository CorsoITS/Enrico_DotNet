using Enrico_DotNet.Repositories;
using Enrico_DotNet.Models;
using System.Security.Cryptography;
using System.Text;

namespace Enrico_DotNet.Service;

public class OperatoreService
{

    private OperatoreRepository operatoreRepository = new OperatoreRepository();

    public IEnumerable<Operatore> GetOperatore()
    {
        return operatoreRepository.GetOperatore();
    }

    public Operatore GetOperatore(int id)
    {
        return operatoreRepository.GetOperatore(id);
    }

    public bool Create(Operatore operatore)
    {
        if (operatoreRepository.GetOperatore(operatore.Id) == null)
        {
            // if ((person.Nome.Length > 0) && (person.Cognome.Length > 0))
            // {
            //     return false;
            // }
            // else
            // {
                return operatoreRepository.Create(operatore);
            // }
        }
        else
        {
            return false;
        }

    }

    public bool Update(Operatore operatore)
    {
        return operatoreRepository.Update(operatore);
    }

    public bool Delete(int id)
    {
        return operatoreRepository.Delete(id);
    }

    public string HashPassword(string plainText)
    {
        var byteArray = ASCIIEncoding.ASCII.GetBytes(plainText);
        byte[] mySHA256 = SHA256.Create().ComputeHash(byteArray);
        return Convert.ToBase64String(mySHA256);
    }

}