namespace oyster_blog
{
    public class AppConfig: IAppConfig
    {
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
        public string? BlogsCollectionName { get; set; }

        public AppConfig(IConfiguration config)
        {
          this.ConnectionString =  config.GetValue<string>(nameof(ConnectionString));
          this.DatabaseName = config.GetValue<string>(nameof(DatabaseName));
          this.BlogsCollectionName = config.GetValue<string>(nameof(BlogsCollectionName));
        }
    }
}
