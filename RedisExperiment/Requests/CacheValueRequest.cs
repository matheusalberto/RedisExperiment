namespace RedisExperiment.Requests
{
    public class CacheValueRequest
    {
        public CacheValueRequest(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public string Value { get; set; }
    }
}
