using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Interceptors
{
    public class MySqlUseIndexHint : QueryHint
    {
        public MySqlUseIndexHint(string tableName, string indexName) : base(QueryHintType.UseIndex, tableName)
        {
            this.IndexName = indexName;
        }

        public string IndexName { get; private set; }

        public override string Replace(string commandText)
        {
            return commandText.Replace(this.TableName, $"{this.TableName} USE INDEX({this.IndexName})");
        }
    }
}
