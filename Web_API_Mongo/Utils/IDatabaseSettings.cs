namespace Web_API_Mongo.Utils
{
    public interface IDatabaseSettings
    {

        string ClientCollectionName { get; set; }
        string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

}
