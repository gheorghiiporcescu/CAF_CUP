using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using CAF_CUP.Configuration.Dto;

namespace CAF_CUP.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : CAF_CUPAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
