using Enrico_DotNet.Repositories;
using Enrico_DotNet.Models;
using System.Security.Cryptography;
using System.Text;

namespace Enrico_DotNet.Service;

public class PersonService
{

    private PersonRepository personRepository = new PersonRepository();

    public IEnumerable<Person> GetPeople()
    {
        return personRepository.GetPeople();
    }

    public Person GetPerson(int id)
    {
        return personRepository.GetPerson(id);
    }

    public bool Create(Person person)
    {
        if (personRepository.GetPerson(person.Id) == null)
        {
            // if ((person.Nome.Length > 0) && (person.Cognome.Length > 0))
            // {
            //     return false;
            // }
            // else
            // {
                return personRepository.Create(person);
            // }
        }
        else
        {
            return false;
        }

    }

    public bool Update(Person person)
    {
        return personRepository.Update(person);
    }

    public bool Delete(int id)
    {
        return personRepository.Delete(id);
    }

    public string HashPassword(string plainText)
    {
        var byteArray = ASCIIEncoding.ASCII.GetBytes(plainText);
        byte[] mySHA256 = SHA256.Create().ComputeHash(byteArray);
        return Convert.ToBase64String(mySHA256);
    }

}