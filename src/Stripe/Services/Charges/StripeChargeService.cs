﻿using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Stripe.Infrastructure;

namespace Stripe
{
	public class StripeChargeService
	{
        public string ApiKeyAppSettingName;

        public StripeChargeService() { }
        public StripeChargeService(string ApiKeyAppSettingName)
        {
            this.ApiKeyAppSettingName = ApiKeyAppSettingName;
        }

		public virtual StripeCharge Create(StripeChargeCreateOptions createOptions)
		{
			var url = ParameterBuilder.ApplyAllParameters(createOptions, Urls.Charges);

			var response = Requestor.PostString(url,ApiKeyAppSettingName);

			return Mapper<StripeCharge>.MapFromJson(response);
		}

		public virtual StripeCharge Get(string chargeId)
		{
			var url = string.Format("{0}/{1}", Urls.Charges, chargeId);

			var response = Requestor.GetString(url,ApiKeyAppSettingName);

			return Mapper<StripeCharge>.MapFromJson(response);
		}

        #region Refund(string chargeId, int? refundAmountInCents = null)
        public virtual StripeCharge Refund(string chargeId)
		{
			int? refundAmountInCents = null;

			return Refund(chargeId, refundAmountInCents);
		}

		public virtual StripeCharge Refund(string chargeId, int? refundAmountInCents)
		{
			var url = string.Format("{0}/{1}/refund", Urls.Charges, chargeId);

			if (refundAmountInCents.HasValue)
				url = ParameterBuilder.ApplyParameterToUrl(url, "amount", refundAmountInCents.Value.ToString());

			var response = Requestor.PostString(url,ApiKeyAppSettingName);

			return Mapper<StripeCharge>.MapFromJson(response);
		}
        #endregion

        #region List(int count = 10, int offset = 0, string customerId = null)
        public virtual IEnumerable<StripeCharge> List()
		{
			int count = 10;
            int offset = 0;
            string customerId = null;

			return List(count, offset, customerId);
		}

        public virtual IEnumerable<StripeCharge> ListWithCount(int count)
		{
			int offset = 0;
            string customerId = null;

			return List(count, offset, customerId);
		}

        public virtual IEnumerable<StripeCharge> ListWithOffset(int offset)
		{
			int count = 10;
            string customerId = null;

			return List(count, offset, customerId);
		}

        public virtual IEnumerable<StripeCharge> ListWithCustomerId(string customerId)
		{
			int count = 10;
            int offset = 0;

			return List(count, offset, customerId);
		}

        public virtual IEnumerable<StripeCharge> ListWithOffsetAndCustomerId(int offset, string customerId)
		{
			int count = 10;

			return List(count, offset, customerId);
		}

        public virtual IEnumerable<StripeCharge> ListWithCountAndCustomerId(int count, string customerId)
		{
			int offset = 0;

			return List(count, offset, customerId);
		}

        public virtual IEnumerable<StripeCharge> ListWithCountAndOffset(int count, int offset)
		{
			string customerId = null;

			return List(count, offset, customerId);
		}

		public virtual IEnumerable<StripeCharge> List(int count, int offset, string customerId)
		{
			var url = Urls.Charges;
			url = ParameterBuilder.ApplyParameterToUrl(url, "count", count.ToString());
			url = ParameterBuilder.ApplyParameterToUrl(url, "offset", offset.ToString());

			if (!string.IsNullOrEmpty(customerId))
				url = ParameterBuilder.ApplyParameterToUrl(url, "customer", customerId);

			var response = Requestor.GetString(url,ApiKeyAppSettingName);

			return Mapper<StripeCharge>.MapCollectionFromJson(response);
		}
        #endregion
	}
}