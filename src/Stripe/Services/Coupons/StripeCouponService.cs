using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Stripe.Infrastructure;

namespace Stripe
{
	public class StripeCouponService
	{
        public string ApiKeyAppSettingName;

        public StripeCouponService() { }
        public StripeCouponService(string ApiKeyAppSettingName)
        {
            this.ApiKeyAppSettingName = ApiKeyAppSettingName;
        }

		public virtual StripeCoupon Create(StripeCouponCreateOptions createOptions)
		{
			var url = ParameterBuilder.ApplyAllParameters(createOptions, Urls.Coupons);

			var response = Requestor.PostString(url,ApiKeyAppSettingName);

			return Mapper<StripeCoupon>.MapFromJson(response);
		}

		public virtual StripeCoupon Get(string couponId)
		{
			var url = string.Format("{0}/{1}", Urls.Coupons, couponId);

			var response = Requestor.GetString(url,ApiKeyAppSettingName);

			return Mapper<StripeCoupon>.MapFromJson(response);
		}

		public virtual void Delete(string couponId)
		{
			var url = string.Format("{0}/{1}", Urls.Coupons, couponId);

			Requestor.Delete(url,ApiKeyAppSettingName);
		}

        #region List(int count = 10, int offset = 0)
        public virtual IEnumerable<StripeCoupon> List()
        {
            int count = 10;
            int offset = 0;

            return List(count, offset);
        }

        public virtual IEnumerable<StripeCoupon> ListWithOffset(int offset)
        {
            int count = 10;

            return List(count, offset);
        }

        public virtual IEnumerable<StripeCoupon> ListWithCount(int count)
        {
            int offset = 0;

            return List(count, offset);
        }

		public virtual IEnumerable<StripeCoupon> List(int count, int offset)
		{
			var url = Urls.Coupons;
			url = ParameterBuilder.ApplyParameterToUrl(url, "count", count.ToString());
			url = ParameterBuilder.ApplyParameterToUrl(url, "offset", offset.ToString());

			var response = Requestor.GetString(url,ApiKeyAppSettingName);

			return Mapper<StripeCoupon>.MapCollectionFromJson(response);
		}
        #endregion
	}
}