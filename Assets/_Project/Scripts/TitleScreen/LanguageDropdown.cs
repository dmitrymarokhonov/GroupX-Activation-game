using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

namespace Relanima
{
    public class LanguageDropdown : MonoBehaviour
    {
        public TMP_Dropdown dropdown;

        private void Start()
        {
            var locales = LocalizationSettings.AvailableLocales.Locales;
            var index = locales.IndexOf(LocalizationSettings.SelectedLocale);
            
            dropdown.value = index;
            dropdown.onValueChanged.AddListener(delegate
            {
                ChangeLanguage(dropdown);
            });
        }

        private static void ChangeLanguage(TMP_Dropdown dd)
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[dd.value];
        }
    }
}
