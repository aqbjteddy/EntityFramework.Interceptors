using EntityFramework.Interceptors;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class HintDbContext : DbContext
    {
        static HintDbContext()
        {
            DbInterception.Add(new HintDbCommandInterceptor());
        }

        public HintDbContext() { }
        public HintDbContext(string nameOrConnectionString) : base(nameOrConnectionString) { }

        private List<QueryHint> _hints = new List<QueryHint>();
        public void AddHint(QueryHint hint)
        {
            _hints.Add(hint);
        }

        public List<QueryHint> GetHints()
        {
            return _hints;
        }

        public void ClearHints()
        {
            _hints.Clear();
        }
    }
}
