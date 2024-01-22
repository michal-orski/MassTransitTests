namespace MassTransitTests.Core.Lexicon
{ 
    public class Cache
    {
        public enum Key
        {
            ExchangeType,
            CountMessage,
            DelayMs
        }

        public static readonly Dictionary<Key, object> Dictionary = new()
        {
            {   Key.DelayMs, 1000 },
            {   Key.CountMessage, 20 },
            {   Key.ExchangeType, "direct" }
        };
    }
}
