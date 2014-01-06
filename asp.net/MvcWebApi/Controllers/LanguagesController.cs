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
		public HttpResponseMessage Get(int index)
		{
			var languages = LanguagesRepository.GetLanguages();

			if (index < 0 || index >= languages.Count || languages.Count == 0)
			{
				return Request.CreateErrorResponse(HttpStatusCode.NotFound, "language not found");
			}

			return Request.CreateResponse<string>(HttpStatusCode.OK, languages[index]);
		}

		/// <summary>
		/// Inserts a new language. Verb = POST. Path = api/languages
		/// </summary>
		/// <param name="language">language object</param>
		public HttpResponseMessage Post([FromBody]string languageName)
		{
			if (string.IsNullOrEmpty(languageName))
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "languageName can not be null/empty");
			}

			LanguagesRepository.GetLanguages().Add(languageName);

			var resp = Request.CreateResponse(HttpStatusCode.Created);
			resp.Headers.Location = new Uri(string.Concat(Request.RequestUri, "/", LanguagesRepository.GetLanguages().Count - 1));

			return resp;
		}

		/// <summary>
		/// Get language by its index and changes its name. Verb = PUT. Path = api/language/5
		/// </summary>
		/// <param name="index">index of language</param>
		/// <param name="languageName"></param>
		public HttpResponseMessage Put(int index, [FromBody]string languageName)
		{
			var languages = LanguagesRepository.GetLanguages();

			if (index < 0 || index >= languages.Count || languages.Count == 0)
			{
				return Request.CreateErrorResponse(HttpStatusCode.NotFound, "language not found");
			}

			if (string.IsNullOrEmpty(languageName))
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "languageName can not be null/empty");
			}

			languages[index] = languageName;

			return Request.CreateResponse(HttpStatusCode.OK);
		}

		/// <summary>
		///  Removes language by its index. Verb = DELETE. Path = api/languages/5
		/// </summary>
		/// <param name="index">index of language</param>
		public HttpResponseMessage Delete(int index)
		{
			var languages = LanguagesRepository.GetLanguages();

			if (index < 0 || index >= languages.Count || languages.Count == 0)
			{
				return Request.CreateErrorResponse(HttpStatusCode.NotFound, "language not found");
			}

			languages.RemoveAt(index);

			return Request.CreateResponse(HttpStatusCode.OK);
		}
	}
}