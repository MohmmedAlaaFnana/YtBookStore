﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YtBookStore.Models.Domain;

namespace YtBookStore.Repositories.Abstract
{
    public interface IAuthorService
    {

        bool Add(Author model);

        bool Update(Author model);

        bool Delete(int id);
        Author FindById(int id);

        IEnumerable<Author> GetAll();
    }
    
}
