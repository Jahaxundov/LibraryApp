using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T:BaseEntity
    {
        void Greate(T entity);
        List<T> Delete(int id);
        void Edit(T entiry);
        T GetById(int id);
        List<T> GetAll();
        List<T> GetAllByExpression(Expression<Func<T, bool>> expression); 
    }
}
