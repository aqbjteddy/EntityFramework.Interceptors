using System;
using System.Data.Entity;
using System.Linq;

namespace EntityFramework.Interceptors
{
    public static class QueryExtensions
    {
        public static IQueryable<T> UseIndex<T>(this DbContext context, string indexName) where T : class
        {
            var tableName = context.GetTableName<T>();
            if (!(context is IHintDbContext))
                throw new Exception("DbContext should implement IHintDbContext");
            var hintContext = context as IHintDbContext;
            hintContext.HintAssessor.AddHint(new MySqlUseIndexHint(tableName, indexName));
            return context.Set<T>();
        }
    }
}
