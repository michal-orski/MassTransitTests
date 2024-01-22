namespace MassTransitTests.Core.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime Date { get; set; }

        public override string ToString() => $"[{Date}]    [{Id}]     {Text}";
    }
}
