using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Interceptors
{
    public class UseIndexOnHint : QueryHint
    {
        public UseIndexOnHint(string tableName, string indexName) : base(QueryHintType.UseIndexOn)
        {
            this.IndexName = indexName;
        }
        
        public string IndexName { get; private set; }

        public override string Replace(string commandText)
        {
            return commandText;
        }
    }
}
