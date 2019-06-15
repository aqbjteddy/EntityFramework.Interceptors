using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Interceptors
{
    public enum QueryHintType
    {
        UseIndex = 0
    }

    public abstract class QueryHint
    {
        protected QueryHint(QueryHintType type, string tableName)
        {
            this.Type = type;
            this.TableName = tableName;
        }
        public string TableName { get; set; }
        public QueryHintType Type { get; private set; }
        public abstract string Replace(string commandText);
    }
}
