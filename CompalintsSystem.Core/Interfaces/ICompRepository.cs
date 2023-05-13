using System.Collections.Generic;

namespace CompalintsSystem.Core.Interfaces
{
    public interface ICompRepository<TEntity>
    {
        IList<TEntity> List();
        TEntity Find(int Id, string Keyword);
        void Delete(int Id);
        void Add(TEntity entity);
        void Update(int Id, TEntity entity);
        public List<TEntity> Search(int Id, string KeyTerm);
    }
}
