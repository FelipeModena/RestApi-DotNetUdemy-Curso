using ApiRestComASPNet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestComASPNet.Business
{
    public interface IBooksBusiness
    {
        Book Create(Book books);
        Book FindById(long id);
        List<Book> FindAll();
        Book Update(Book books);
        void Delete(long id);
    }
}