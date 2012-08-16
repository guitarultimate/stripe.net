using System.Collections.Generic;
using System.Linq;

namespace Stripe
{
	public class StripeCustomerService
	{
        public string ApiKeyAppSettingName;

        public StripeCustomerService() { }
        public StripeCustomerService(string ApiKeyAppSettingName)
        {
            this.ApiKeyAppSettingName = ApiKeyAppSettingName;
        }

		public virtual StripeCustomer Create(StripeCustomerCreateOptions createOptions)
		{
			var url = ParameterBuilder.ApplyAllParameters(createOptions, Urls.Customers);

			var response = Requestor.PostString(url,ApiKeyAppSettingName);

			return Mapper<StripeCustomer>.MapFromJson(response);
		}

		public virtual StripeCustomer Get(string customerId)
		{
			var url = string.Format("{0}/{1}", Urls.Customers, customerId);

			var response = Requestor.GetString(url,ApiKeyAppSettingName);

			return Mapper<StripeCustomer>.MapFromJson(response);
		}

		public virtual StripeCustomer Update(string customerId, StripeCustomerUpdateOptions updateOptions)
		{
			var url = string.Format("{0}/{1}", Urls.Customers, customerId);
			url = ParameterBuilder.ApplyAllParameters(updateOptions, url);

			var response = Requestor.PostString(url,ApiKeyAppSettingName);

			return Mapper<StripeCustomer>.MapFromJson(response);
		}

		public virtual void Delete(string customerId)
		{
			var url = string.Format("{0}/{1}", Urls.Customers, customerId);

			Requestor.Delete(url,ApiKeyAppSettingName);
		}

        #region List(int count = 10, int offset = 0)
        public virtual IEnumerable<StripeCustomer> List()
        {
            int count = 10;
            int offset = 0;

            return List(count, offset);
        }

        public virtual IEnumerable<StripeCustomer> ListWithOffset(int offset)
        {
            int count = 10;

            return List(count, offset);
        }

        public virtual IEnumerable<StripeCustomer> ListWithCount(int count)
        {
            int offset = 0;

            return List(count, offset);
        }

		public virtual IEnumerable<StripeCustomer> List(int count, int offset)
		{
			var url = Urls.Customers;
			url = ParameterBuilder.ApplyParameterToUrl(url, "count", count.ToString());
			url = ParameterBuilder.ApplyParameterToUrl(url, "offset", offset.ToString());

			var response = Requestor.GetString(url,ApiKeyAppSettingName);

			return Mapper<StripeCustomer>.MapCollectionFromJson(response);
		}
        #endregion

		public virtual StripeSubscription UpdateSubscription(string customerId, StripeCustomerUpdateSubscriptionOptions updateOptions)
		{
			var url = string.Format("{0}/{1}/subscription", Urls.Customers, customerId);
			url = ParameterBuilder.ApplyAllParameters(updateOptions, url);

			var response = Requestor.PostString(url,ApiKeyAppSettingName);

			return Mapper<StripeSubscription>.MapFromJson(response);
		}

        #region CancelSubscription(string customerId, bool cancelAtPeriodEnd = false)
        public virtual StripeSubscription CancelSubscription(string customerId)
		{
			bool cancelAtPeriodEnd = false;

			return CancelSubscription(customerId, cancelAtPeriodEnd);
		}

		public virtual StripeSubscription CancelSubscription(string customerId, bool cancelAtPeriodEnd)
		{
			var url = string.Format("{0}/{1}/subscription", Urls.Customers, customerId);
			url = ParameterBuilder.ApplyParameterToUrl(url, "at_period_end", cancelAtPeriodEnd.ToString());

			var response = Requestor.Delete(url,ApiKeyAppSettingName);

			return Mapper<StripeSubscription>.MapFromJson(response);
		}
        #endregion
	}
}