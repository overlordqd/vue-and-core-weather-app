using weatherappapi.models;

namespace weatherappapi
{
    public interface IAppSettingsWrapper
    {
        AppSettings AppSettings { get; }
    }
}