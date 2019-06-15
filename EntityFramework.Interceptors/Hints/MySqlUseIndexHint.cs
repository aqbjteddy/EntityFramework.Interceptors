using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            var regex = new Regex($"{this.TableName} AS \\`Extent\\d+\\`");
            var matches = regex.Matches(commandText);
            if (matches.Count > 0)
            {
                for (var index = 0; index < matches.Count; index++)
                {
                    var match = matches[index];
                    commandText = commandText.Replace(match.Value, $"{match.Value} USE INDEX({this.IndexName})");
                }
            }
            return commandText;
        }
    }
}
