using System;
using System.Linq;

namespace EntityFramework.Interceptors
{
    public static class QueryExtensions
    {
        public static IQueryable<T> UseIndexOn<T>(this HintDbContext context, string indexName) where T : class
        {
            var tableName = context.GetTableName<T>();
            context.AddHint(new MySqlUseIndexHint(tableName, indexName));
            return context.Set<T>();
        }

        public static IQueryable<T> UseIndexOn<T>(this HintDbContext context, Func<object, T> expression) where T : class
        {
            return context.Set<T>();
        }
    }
}
