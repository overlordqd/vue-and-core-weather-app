namespace weatherappapi.ApiClients
{
    public abstract class WeatherApiClientBase
    {
        public struct Types
        {
            public const string Current = "Current";
            public const string Forecast = "Forecast";
        }

        protected ValidateRequest(string weatherCallType)
        {
          if (!new[] { Types.Current, Types.Forecast }.Contains(weatherCallType))
          {
              throw new Exception($"Not known weather call: {weatherCallType}");
          }
        }
    }
}
