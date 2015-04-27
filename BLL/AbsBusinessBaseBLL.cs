using IDAL;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public abstract class AbsBusinessBaseBLL<E, D> : AbsFinderBaseBLL<E, D>
        where E : BusinessEntity, new()
        where D : IDAL<E>
    {
        public int Delete(String id)
        {
            return Dal.Delete(id);
        }

        public int Delete(E entity)
        {
            return Dal.Delete(entity);
        }

        public E Save(E entity)
        {
            Dal.Save(entity);
            return entity;
        }

        public E Create(E entity)
        {
            entity.Id = Guid.NewGuid().ToString();

            Dal.Create(entity);

            return entity;
        }

        public E Update(E entity)
        {
            Dal.Update(entity);
            return entity;
        }
    }
}
