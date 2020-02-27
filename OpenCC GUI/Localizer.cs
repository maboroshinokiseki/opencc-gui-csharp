using System.Linq;
using System.Reflection;
using System.Resources;

namespace OpenCC_GUI
{
    static class Localizer
    {
        private static ResourceManager MainResourse = null;
        private const string ResourseBase = "OpenCC_GUI.Languages.Language_";
        public static void InitLocalizedResource(string lang)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var ResList = assembly.GetManifestResourceNames().ToList();

            string FullResourseName;
            if (ResList.Contains(ResourseBase + lang + ".resources"))
            {
                FullResourseName = ResourseBase + lang;
            }
            else
            {
                FullResourseName = ResourseBase + "en";
            }

            MainResourse = new ResourceManager(FullResourseName, assembly);
        }

        public static string Localize(this string str)
        {
            return GetString(str);
        }

        public static string GetString(string name)
        {
            try
            {
                if (MainResourse == null)
                    return name;

                string result = MainResourse.GetString(name);
                return (result == null) ? name : result;
            }
            catch
            {
                return name;
            }
        }

    }
}
