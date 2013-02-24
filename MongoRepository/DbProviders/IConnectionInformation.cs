namespace RepositoryLibrary.DbProviders
{
    public interface IConnectionInformation
    {
        string ConnectionString { get; }
        string ServerName { get; set; }
        string DatabaseName { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string Port { get; set; }
    }
}