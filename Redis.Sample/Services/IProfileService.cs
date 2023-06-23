namespace Redis.Sample.Services
{
    public interface IProfileService
    {
        Task Set(string key, string value);
        Task<string?> Get(string key);
    }
}
