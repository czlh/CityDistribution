using BLL;
using IDAL;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Service
{
    public class AbsBusinessBaseService<B, D, E> : AbsFindBaseService<B, D, E>
        where B : AbsBusinessBaseBLL<E, D>, new()
        where D : IDAL<E>
        where E : BusinessEntity, new()
    {
        protected B BLL = new B();

        public int Delete(String id)
        {
            using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                Timeout = new TimeSpan(0, 0, 60)
            }, EnterpriseServicesInteropOption.Automatic))
            {
                int result = BLL.Delete(id);
                transaction.Complete();

                return result;
            }
        }

        public int Deletes(List<String> ids)
        {
            using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                Timeout = new TimeSpan(0, 0, 60)
            }, EnterpriseServicesInteropOption.Automatic))
            {
                int count  = 0;
                ids.ForEach(id =>
                {
                    count = BLL.Delete(id) + count;
                });

                transaction.Complete();

                return count;
            }
        }

        public int Delete(E entity)
        {
            using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
               {
                   IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                   Timeout = new TimeSpan(0, 0, 60)
               }, EnterpriseServicesInteropOption.Automatic))
            {
                int result = BLL.Delete(entity);
                transaction.Complete();

                return result;
            }
        }

        public E Save(E entity)
        {
            using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
               {
                   IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                   Timeout = new TimeSpan(0, 0, 60)
               }, EnterpriseServicesInteropOption.Automatic))
            {
                E result = BLL.Save(entity);

                transaction.Complete();

                return result;
            }
        }

        public E Create(E entity)
        {
            using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
               {
                   IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                   Timeout = new TimeSpan(0, 0, 60)
               }, EnterpriseServicesInteropOption.Automatic))
            {
                E result = BLL.Create(entity);
                transaction.Complete();
                return result;
            }
        }

        public E Update(E entity)
        {
            using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
               {
                   IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                   Timeout = new TimeSpan(0, 0, 60)
               }, EnterpriseServicesInteropOption.Automatic))
            {
                E result = BLL.Update(entity);
                transaction.Complete();
                return result;
            }
        }
    }
}
