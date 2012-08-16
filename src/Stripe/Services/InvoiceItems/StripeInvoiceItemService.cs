using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Stripe.Infrastructure;

namespace Stripe
{
	public class StripeInvoiceItemService
	{
        public string ApiKeyAppSettingName;

        public StripeInvoiceItemService() { }
        public StripeInvoiceItemService(string ApiKeyAppSettingName)
        {
            this.ApiKeyAppSettingName = ApiKeyAppSettingName;
        }

		public virtual StripeInvoiceItem Create(StripeInvoiceItemCreateOptions createOptions)
		{
			var url = ParameterBuilder.ApplyAllParameters(createOptions, Urls.InvoiceItems);

			var response = Requestor.PostString(url,ApiKeyAppSettingName);

			return Mapper<StripeInvoiceItem>.MapFromJson(response);
		}

		public virtual StripeInvoiceItem Get(string invoiceItemId)
		{
			var url = string.Format("{0}/{1}", Urls.InvoiceItems, invoiceItemId);

			var response = Requestor.GetString(url,ApiKeyAppSettingName);

			return Mapper<StripeInvoiceItem>.MapFromJson(response);
		}

		public virtual StripeInvoiceItem Update(string invoiceItemId, StripeInvoiceItemUpdateOptions updateOptions)
		{
			var url = string.Format("{0}/{1}", Urls.InvoiceItems, invoiceItemId);
			url = ParameterBuilder.ApplyAllParameters(updateOptions, url);

			var response = Requestor.PostString(url,ApiKeyAppSettingName);

			return Mapper<StripeInvoiceItem>.MapFromJson(response);
		}

		public virtual void Delete(string invoiceItemId)
		{
			var url = string.Format("{0}/{1}", Urls.InvoiceItems, invoiceItemId);

			Requestor.Delete(url,ApiKeyAppSettingName);
		}


        #region List(int count = 10, int offset = 0, string customerId = null)
        public virtual IEnumerable<StripeInvoiceItem> List()
		{
			int count = 10;
            int offset = 0;
            string customerId = null;

			return List(count, offset, customerId);
		}

        public virtual IEnumerable<StripeInvoiceItem> ListWithCount(int count)
		{
			int offset = 0;
            string customerId = null;

			return List(count, offset, customerId);
		}

        public virtual IEnumerable<StripeInvoiceItem> ListWithOffset(int offset)
		{
			int count = 10;
            string customerId = null;

			return List(count, offset, customerId);
		}

        public virtual IEnumerable<StripeInvoiceItem> ListWithCustomerId(string customerId)
		{
			int count = 10;
            int offset = 0;

			return List(count, offset, customerId);
		}

        public virtual IEnumerable<StripeInvoiceItem> ListWithOffsetAndCustomerId(int offset, string customerId)
		{
			int count = 10;

			return List(count, offset, customerId);
		}

        public virtual IEnumerable<StripeInvoiceItem> ListWithCountAndCustomerId(int count, string customerId)
		{
			int offset = 0;

			return List(count, offset, customerId);
		}

        public virtual IEnumerable<StripeInvoiceItem> ListWithCountAndOffset(int count, int offset)
		{
			string customerId = null;

			return List(count, offset, customerId);
		}

		public virtual IEnumerable<StripeInvoiceItem> List(int count, int offset, string customerId)
		{
			var url = Urls.InvoiceItems;
			url = ParameterBuilder.ApplyParameterToUrl(url, "count", count.ToString());
			url = ParameterBuilder.ApplyParameterToUrl(url, "offset", offset.ToString());

			if(!string.IsNullOrEmpty(customerId))
				url = ParameterBuilder.ApplyParameterToUrl(url, "customer", customerId);

			var response = Requestor.GetString(url,ApiKeyAppSettingName);

			return Mapper<StripeInvoiceItem>.MapCollectionFromJson(response);
		}
        #endregion
	}
}