namespace TrackIt.Application.Services
{
    public class GreetingService : IGreetingService
    {
        public string GetGreeting()
        {
            return "Hello from TrackIt Service!";
        }
    }
}
