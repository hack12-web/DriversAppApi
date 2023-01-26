namespace DriversAppApi
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CollectionNameDriver { get; set; } = null!;
        public string CollectionNameMessenger { get; set; } = null!;
    }
}