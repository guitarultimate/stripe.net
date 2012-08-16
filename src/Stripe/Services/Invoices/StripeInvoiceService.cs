using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Stripe.Infrastructure;

namespace Stripe
{
	public class StripeInvoiceService
	{
        public string ApiKeyAppSettingName;

        public StripeInvoiceService() { }
        public StripeInvoiceService(string ApiKeyAppSettingName)
        {
            this.ApiKeyAppSettingName = ApiKeyAppSettingName;
        }

		public virtual StripeInvoice Get(string invoiceId)
		{
			var url = string.Format("{0}/{1}", Urls.Invoices, invoiceId);

			var response = Requestor.GetString(url,ApiKeyAppSettingName);

			return Mapper<StripeInvoice>.MapFromJson(response);
		}

		public virtual StripeInvoice Upcoming(string customerId)
		{
			var url = string.Format("{0}/{1}", Urls.Invoices, "upcoming");

			url = ParameterBuilder.ApplyParameterToUrl(url, "customer", customerId);

			var response = Requestor.GetString(url,ApiKeyAppSettingName);

			return Mapper<StripeInvoice>.MapFromJson(response);
		}

        #region List(int count = 10, int offset = 0, string customerId = null)
        public virtual IEnumerable<StripeInvoice> List()
		{
			int count = 10;
            int offset = 0;
            string customerId = null;

			return List(count, offset, customerId);
		}

        public virtual IEnumerable<StripeInvoice> ListWithCount(int count)
		{
			int offset = 0;
            string customerId = null;

			return List(count, offset, customerId);
		}

        public virtual IEnumerable<StripeInvoice> ListWithOffset(int offset)
		{
			int count = 10;
            string customerId = null;

			return List(count, offset, customerId);
		}

        public virtual IEnumerable<StripeInvoice> ListWithCustomerId(string customerId)
		{
			int count = 10;
            int offset = 0;

			return List(count, offset, customerId);
		}

        public virtual IEnumerable<StripeInvoice> ListWithOffsetAndCustomerId(int offset, string customerId)
		{
			int count = 10;

			return List(count, offset, customerId);
		}

        public virtual IEnumerable<StripeInvoice> ListWithCountAndCustomerId(int count, string customerId)
		{
			int offset = 0;

			return List(count, offset, customerId);
		}

        public virtual IEnumerable<StripeInvoice> ListWithCountAndOffset(int count, int offset)
		{
			string customerId = null;

			return List(count, offset, customerId);
		}

		public virtual IEnumerable<StripeInvoice> List(int count, int offset, string customerId)
		{
			var url = Urls.Invoices;
			url = ParameterBuilder.ApplyParameterToUrl(url, "count", count.ToString());
			url = ParameterBuilder.ApplyParameterToUrl(url, "offset", offset.ToString());

			if(!string.IsNullOrEmpty(customerId))
				url = ParameterBuilder.ApplyParameterToUrl(url, "customer", customerId);

			var response = Requestor.GetString(url,ApiKeyAppSettingName);

			return Mapper<StripeInvoice>.MapCollectionFromJson(response);
		}
        #endregion
	}
}