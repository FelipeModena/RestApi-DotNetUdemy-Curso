using ApiRestComASPNet.Model;
using ApiRestComASPNet.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiRestComASPNet.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private MySqlContext _mySqlContext;

        public PersonRepositoryImplementation(MySqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;
        }

        public List<Person> FindAll()
        {

            return _mySqlContext.Person.ToList();
        }



        public Person FindById(long Id)
        {
            return _mySqlContext.Person.SingleOrDefault(personDb => personDb.Id == Id);
        }
        public Person Create(Person person)
        {
            try
            {
                _mySqlContext.Add(person);
                _mySqlContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return person;
        }


        public Person Update(Person person)
        {
            if (Exists(person.Id) == true)
            {
                return new Person();
            }
            else
            {
                var result = _mySqlContext.Person.SingleOrDefault(personDb => personDb.Id == person.Id);

                if (result != null)
                {
                    try
                    {
                        _mySqlContext.Entry(result).CurrentValues.SetValues(person);
                        _mySqlContext.SaveChanges();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }

            return person;
        }
        public void Delete(long id)
        {
            var result = _mySqlContext.Person.SingleOrDefault(personDb => personDb.Id == id);
            if (result != null)
            {
                try
                {
                    _mySqlContext.Person.Remove(result);
                    _mySqlContext.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            if (_mySqlContext.Person.FirstOrDefault(person => person.Id == id) != null)
            {
                return true;
            }
            else return false;
        }
    }
}
