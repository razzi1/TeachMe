using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

namespace RepositoryTests
{
    public class FakeDbSet<T> : IDbSet<T>
        where T : class
    {
        readonly ObservableCollection<T> data;
        readonly IQueryable query;

        public FakeDbSet()
        {
            data = new ObservableCollection<T>();
            query = data.AsQueryable();
        }

        public virtual T Find(params object[] keyValues)
        {
            throw new NotImplementedException("Derive from FakeDbSet<T> and override Find");
        }

        public T Add(T item)
        {
            data.Add(item);
            return item;
        }

        public T Remove(T item)
        {
            data.Remove(item);
            return item;
        }

        public T Attach(T item)
        {
            data.Add(item);
            return item;
        }

        public T Detach(T item)
        {
            data.Remove(item);
            return item;
        }

        public T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        public ObservableCollection<T> Local => data;

        Type IQueryable.ElementType => query.ElementType;

        System.Linq.Expressions.Expression IQueryable.Expression => query.Expression;

        IQueryProvider IQueryable.Provider => query.Provider;

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return data.GetEnumerator();
        }
    }
}