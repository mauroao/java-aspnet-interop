using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebApi.Repositories
{
	public class LanguagesRepository
	{
		private static List<String> languages = new List<string> { ".NET", "JAVA", "Scala", "Ruby", "Javascript" };

		public static List<String> GetLanguages()
		{
			return languages;
		}

		public static void AddLanguage(string languageName)
		{
			languages.Add(languageName);
		}

		public static void DeleteLanguage(string languageName)
		{
			languages.Remove(languageName);
		}
	}
}