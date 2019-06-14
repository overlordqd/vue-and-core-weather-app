using System;

namespace weatherappapi.ApiCalls
{
    public interface IWeatherApiCallFactory
    {
         IWeatherApiCall GetRequestedApiCall(string weatherCallType);
    }
}
