using ApiRestComASPNet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestComASPNet.Repository
{
    public interface IBooksRepository
    {
        Book Create(Book books);
        Book FindById(long Id);
        List<Book> FindAll();
        Book Update(Book books);
        void Delete(long id);
        bool Exists(long id);
    }
}
