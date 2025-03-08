using LibraryApi.IDbConnectionService;

namespace LibraryApi.ConnectionService
{
    public class DbConnectionService : IDbConnectionService.IDbConnectionService
    {
        public string ConnectionString;
        public DbConnectionService(string _connection)
        {
            ConnectionString = _connection;
        }
        public string GetConnetionString()
        {
            return ConnectionString;
        }
    }
}
