using Microsoft.Extensions.Options;
using weatherappapi.models;

namespace weatherappapi
{
    public class AppSettingsWrapper : IAppSettingsWrapper
    {
        private readonly IOptions<AppSettings> appSettings;

        public AppSettingsWrapper(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings;
        }

        public AppSettings AppSettings => this.appSettings?.Value;
    }
}
