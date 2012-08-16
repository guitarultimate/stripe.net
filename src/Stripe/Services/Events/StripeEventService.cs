using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Stripe
{
	public class StripeEventService
	{
        public string ApiKeyAppSettingName;

        public StripeEventService() { }
        public StripeEventService(string ApiKeyAppSettingName)
        {
            this.ApiKeyAppSettingName = ApiKeyAppSettingName;
        }

		public virtual StripeEvent Get(string eventId)
		{
			var url = string.Format("{0}/{1}", Urls.Events, eventId);

			var response = Requestor.GetString(url, ApiKeyAppSettingName);

			return Mapper<StripeEvent>.MapFromJson(response);
		}

        #region List(int count = 10, int offset = 0, StripeEventSearchOptions searchOptions = null)
        public virtual IEnumerable<StripeEvent> List()
		{
			int count = 10;
            int offset = 0;
            StripeEventSearchOptions searchOptions = null;

			return List(count, offset, searchOptions);
		}

        public virtual IEnumerable<StripeEvent> ListWithCount(int count)
		{
			int offset = 0;
            StripeEventSearchOptions searchOptions = null;

			return List(count, offset, searchOptions);
		}

        public virtual IEnumerable<StripeEvent> ListWithOffset(int offset)
		{
			int count = 10;
            StripeEventSearchOptions searchOptions = null;

			return List(count, offset, searchOptions);
		}

        public virtual IEnumerable<StripeEvent> ListWithOptions(StripeEventSearchOptions searchOptions)
		{
			int count = 10;
            int offset = 0;

			return List(count, offset, searchOptions);
		}

        public virtual IEnumerable<StripeEvent> ListWithOffsetAndOptions(int offset, StripeEventSearchOptions searchOptions)
		{
			int count = 10;

			return List(count, offset, searchOptions);
		}

        public virtual IEnumerable<StripeEvent> ListWithCountAndOptions(int count, StripeEventSearchOptions searchOptions)
		{
			int offset = 0;

			return List(count, offset, searchOptions);
		}

        public virtual IEnumerable<StripeEvent> ListWithCountAndOffset(int count, int offset)
		{
			StripeEventSearchOptions searchOptions = null;

			return List(count, offset, searchOptions);
		}
		public virtual IEnumerable<StripeEvent> List(int count, int offset, StripeEventSearchOptions searchOptions)
		{
			var url = Urls.Events;
			url = ParameterBuilder.ApplyParameterToUrl(url, "count", count.ToString());
			url = ParameterBuilder.ApplyParameterToUrl(url, "offset", offset.ToString());
			url = ParameterBuilder.ApplyAllParameters(searchOptions, url);

			var response = Requestor.GetString(url, ApiKeyAppSettingName);

			return Mapper<StripeEvent>.MapCollectionFromJson(response);
		}
        #endregion

	}
}