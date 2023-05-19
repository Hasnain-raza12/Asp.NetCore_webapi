namespace web_api.Database
{
    public class DatabaseSettings:IDatabaseSettings
    {
       public  string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
        public string CollectionName { get; set; }

    }
}
