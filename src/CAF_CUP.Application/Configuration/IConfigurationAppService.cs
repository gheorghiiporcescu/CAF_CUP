using System.Threading.Tasks;
using Abp.Application.Services;
using CAF_CUP.Configuration.Dto;

namespace CAF_CUP.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}