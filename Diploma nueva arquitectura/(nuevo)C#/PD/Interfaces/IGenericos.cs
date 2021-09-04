using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
   public interface IGenericos<T> where T : IEntity
    {
        T GetById(Guid id);
        IList<T> GetAll();
        void Guardar(T entity);
        void Borrar(T entity);


    }
}
