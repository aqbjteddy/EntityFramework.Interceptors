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
    public interface IHintDbContext
    {
        HintAccessor HintAssessor { get; }
    }

    public class HintAccessor
    {
        static HintAccessor()
        {
            DbInterception.Add(new HintDbCommandInterceptor());
        }

        private List<QueryHint> _hints = new List<QueryHint>();

        public HintAccessor()
        {

        }

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
