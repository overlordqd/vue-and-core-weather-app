using AutoMapper;
using weatherappapi.models;

namespace weatherappapi.Repositories
{
    public abstract class RepositoryBase
    {
        protected readonly IAppSettingsWrapper appSettingsWrapper;
        protected readonly IMapper mapper;

        public RepositoryBase(IMapper mapper, IAppSettingsWrapper appSettingsWrapper)
        {
            this.mapper = mapper;
            this.appSettingsWrapper = appSettingsWrapper;
        }

        protected AppSettings AppSettings => appSettingsWrapper.AppSettings;
    }
}
