namespace MassTransitTests.Core.GUI
{
    public static class UserConsoleInteractions
    {

        public static void SetConsoleHeader(string text)
        {
            Console.Title = text;
        }

        public static string GetExchangeType()
        {
            Console.WriteLine("Select Exchange type:");
            Console.WriteLine("1 - direct");
            Console.WriteLine("2 - fanout");
            Console.WriteLine("3 - topic");
            Console.WriteLine("4 - headers");

            bool selected = int.TryParse(Console.ReadLine().ToString(), out int selectedExchangeType);
            if (!selected)
            {
                Console.WriteLine("Selected something else then selected: direct");
                selectedExchangeType = 0;
            }


            string exchangeType = selectedExchangeType switch
            {
                0 => "direct",
                1 => "topic",
                2 => "fanout",
                3 => "topic",
                4 => "headers",
                _ => "direct",
            };

            return exchangeType;
        }

        public static int GetNumberOfMessages()
        {
            Console.WriteLine("How many message publisher should send:");
            bool selected = int.TryParse(Console.ReadLine().ToString(), out int countMessage);
            if (!selected)
            {
                Console.WriteLine("Selected something else then selected: 20");
                countMessage = 20;
            }

            return countMessage;
        }

        public static int GetDelayBetweenMessages()
        {
            Console.WriteLine("How many ms should be between messages:");
            bool selected = int.TryParse(Console.ReadLine().ToString(), out int delayMs);
            if (!selected)
            {
                Console.WriteLine("Selected something else then selected: 1000");
                delayMs = 1000;
            }

            return delayMs;
        }
    }
}
