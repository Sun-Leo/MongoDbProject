namespace MongoDbProject.Api.Settings
{
    public class DataBaseSettings : IDataBaseSettings
    {
        public string CategoryCollectionName { get ; set ; }
        public string ProductCollectionName { get ; set ; }
        public string FarmerCollectionName { get ; set ; }
        public string ConnectionString { get ; set ; }
        public string DatabaseName { get; set; }
    }
}
