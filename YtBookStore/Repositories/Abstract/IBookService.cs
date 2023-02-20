using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YtBookStore.Models.Domain;

namespace YtBookStore.Repositories.Abstract
{
   public interface IBookService
    {
        bool Add(Book model);

        bool Update(Book model);

        bool Delete(int id);
        Book FindById(int id);

        IEnumerable<Book> GetAll();
    }
}
