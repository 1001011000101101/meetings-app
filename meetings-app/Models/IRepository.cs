using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace meetings_app.Models
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();
        T ById(int id);
        bool Add(T meeting);
        bool Update(T meeting);
        bool Delete(T meeting);
    }
}
