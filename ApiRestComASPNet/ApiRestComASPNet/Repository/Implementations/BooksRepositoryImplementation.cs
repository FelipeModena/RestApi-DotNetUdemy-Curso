using ApiRestComASPNet.Model;
using ApiRestComASPNet.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestComASPNet.Repository.Implementations
{
    public class BooksRepositoryImplementation : IBooksRepository
    {
        private MySqlContext _mySqlContext;

        public BooksRepositoryImplementation(MySqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;
        }

        public Book Create(Book books)
        {
            try
            {
                _mySqlContext.Add(books);
                _mySqlContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return books;
        }

        public void Delete(long id)
        {
            var result = _mySqlContext.Books.SingleOrDefault(booksDb => booksDb.Id == id);
            if (result != null)
            {
                try
                {
                    _mySqlContext.Books.Remove(result);
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
            if (_mySqlContext.Books.FirstOrDefault(books => books.Id == id) != null)
            {
                return true;
            }
            else return false;
        }

        public List<Book> FindAll()
        {
            return _mySqlContext.Books.ToList();
        }

        public Book FindById(long Id)
        {
            return _mySqlContext.Books.SingleOrDefault(booksDb => booksDb.Id == Id);
        }

        public Book Update(Book books)
        {
            if (Exists(books.Id) == true)
            {
                return new Book();
            }
            else
            {
                var result = _mySqlContext.Books.SingleOrDefault(booksDb => booksDb.Id == books.Id);

                if (result != null)
                {
                    try
                    {
                        _mySqlContext.Entry(result).CurrentValues.SetValues(books);
                        _mySqlContext.SaveChanges();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }

            return books;
        }
    }
}
