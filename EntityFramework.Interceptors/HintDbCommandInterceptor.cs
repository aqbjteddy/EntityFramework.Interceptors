using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Interceptors
{
    public class HintDbCommandInterceptor : DbCommandInterceptor
    {
        public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            var context = interceptionContext.DbContexts.FirstOrDefault(x => x is IHintDbContext);
            if (context != null)
            {
                var hintContext = context as IHintDbContext;
                var hints = hintContext.HintAssessor.GetHints();
                foreach (var hint in hints)
                {
                    command.CommandText = hint.Replace(command.CommandText);
                }
            }
        }
    }
}
