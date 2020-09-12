namespace VinylCollection.Domain.Mongo
{
    public class MongoAccess
    {
        public string ConnectionString;
        public string Database;

        public MongoAccess(string connectionString, string database)
        {
            ConnectionString = connectionString;
            Database = database;
        }
    }
}
