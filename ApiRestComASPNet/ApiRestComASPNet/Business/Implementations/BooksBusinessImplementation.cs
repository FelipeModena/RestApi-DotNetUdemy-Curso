using ApiRestComASPNet.Model;
using ApiRestComASPNet.Repository;
using ApiRestComASPNet.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestComASPNet.Business.Implementations
{
    public class BooksBusinessImplementation : IBooksBusiness
    {
        private readonly IRepository<Book> _repository;
        public BooksBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public Book Create(Book books)
        {
            return _repository.Create(books);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Book Update(Book books)
        {
            return _repository.Update(books);
        }
    }
}
