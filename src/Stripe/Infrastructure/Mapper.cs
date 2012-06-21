using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Stripe.Infrastructure;

namespace Stripe
{
	public static class Mapper<T>
	{   
        #region MapCollectionFromJson
        public static List<T> MapCollectionFromJson(string json)
		{
			string token = "data";

			return MapCollectionFromJson(json, token);
		}

		public static List<T> MapCollectionFromJson(string json, string token)
		{
			var list = new List<T>();

			var jObject = JObject.Parse(json);

			var allTokens = jObject.SelectToken(token);
			foreach (var tkn in allTokens)
				list.Add(Mapper<T>.MapFromJson(tkn.ToString()));

			return list;
		}
        #endregion


        #region MapFromJson
        public static T MapFromJson(string json)
		{
			string parentToken = null;

			return MapFromJson(json, parentToken);
		}
		public static T MapFromJson(string json, string parentToken)
		{
			var jsonToParse = string.IsNullOrEmpty(parentToken) ? json : JObject.Parse(json).SelectToken(parentToken).ToString();

			return JsonConvert.DeserializeObject<T>(jsonToParse);
		}
        #endregion
	}
}