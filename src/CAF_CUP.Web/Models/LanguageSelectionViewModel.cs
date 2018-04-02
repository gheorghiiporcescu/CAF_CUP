using System.Collections.Generic;
using Abp.Localization;

namespace CAF_CUP.Web.Models
{
    public class LanguageSelectionViewModel
    {
        public LanguageInfo CurrentLanguage { get; set; }

        public IReadOnlyList<LanguageInfo> Languages { get; set; }

        public string CurrentUrl { get; set; }
    }
}