using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace BLL
{
    public abstract class AbstractBLL<T> : IGenericos<T> where T : IEntity
    {
        protected IGenericos<T> _Generics;
        void IGenericos<T>.Borrar(T entity)
        {
            _Generics.Borrar(entity);
        }

       public IList<T> GetAll()
        {
            return _Generics.GetAll();
        }

        T IGenericos<T>.GetById(Guid id)
        {
            return _Generics.GetById(id);
        }

        void IGenericos<T>.Guardar(T entity) 
        {
            _Generics.Guardar(entity);
        }
    }
}
