using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MvcWebApi.Repositories;

namespace MvcWebApi.Controllers
{
	public class LanguagesController : ApiController
	{
		/// <summary>
		/// Get all indexed languages. Verb = GET. Path = api/languages.
		/// </summary>
		/// <returns>List of languages</returns>
		public IEnumerable<string> Get()
		{
			return LanguagesRepository.GetLanguages();
		}

		/// <summary>
		/// Get language by its index. Verb = GET. Path = api/languages/5
		/// </summary>
		/// <param name="index">Index of language</param>
		/// <returns>returns language name</returns>
		public string Get(int index)
		{
			var languages = LanguagesRepository.GetLanguages();

			if (index < 0 || index >= languages.Count || languages.Count == 0)
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}

			return languages[index];
		}

		/// <summary>
		/// Inserts a new language. Verb = POST. Path = api/languages
		/// </summary>
		/// <param name="language">language object</param>
		public void Post([FromBody]string languageName)
		{
			if (string.IsNullOrEmpty(languageName))
			{
				throw new HttpResponseException(HttpStatusCode.BadRequest);
			}
			LanguagesRepository.GetLanguages().Add(languageName);
		}

		/// <summary>
		///  Removes language by its index. Verb = DELETE. Path = api/languages/5
		/// </summary>
		/// <param name="index">index of language</param>
		public void Delete(int index)
		{
			var languages = LanguagesRepository.GetLanguages();

			if (index < 0 || index >= languages.Count || languages.Count == 0)
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}

			languages.RemoveAt(index);
		}
	}
}