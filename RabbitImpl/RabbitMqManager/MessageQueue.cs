using System.Data.SqlTypes;
using MessageQueuer;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlString MessageQueue(SqlString rastreo, SqlString status)
    {
        var manager = new Manager();
        manager.Sender("localhost", "hello", (rastreo + status).ToString());
        return new SqlString (string.Empty);
    }
}
