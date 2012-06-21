using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Stripe.Infrastructure;

namespace Stripe
{
	public class StripePlanService
	{
		public virtual StripePlan Create(StripePlanCreateOptions createOptions)
		{
			var url = ParameterBuilder.ApplyAllParameters(createOptions, Urls.Plans);

			var response = Requestor.PostString(url);

			return Mapper<StripePlan>.MapFromJson(response);
		}

		public virtual StripePlan Get(string planId)
		{
			var url = string.Format("{0}/{1}", Urls.Plans, planId);

			var response = Requestor.GetString(url);

			return Mapper<StripePlan>.MapFromJson(response);
		}

		public virtual void Delete(string planId)
		{
			var url = string.Format("{0}/{1}", Urls.Plans, planId);

			Requestor.Delete(url);
		}

        #region List(int count = 10, int offset = 0)
        public virtual IEnumerable<StripePlan> List()
        {
            int count = 10;
            int offset = 0;

            return List(count, offset);
        }

        public virtual IEnumerable<StripePlan> ListWithOffset(int offset)
        {
            int count = 10;

            return List(count, offset);
        }

        public virtual IEnumerable<StripePlan> ListWithCount(int count)
		{
            int offset = 0;

			return List(count, offset);
		}

		public virtual IEnumerable<StripePlan> List(int count, int offset)
		{
			var url = Urls.Plans;
			url = ParameterBuilder.ApplyParameterToUrl(url, "count", count.ToString());
			url = ParameterBuilder.ApplyParameterToUrl(url, "offset", offset.ToString());

			var response = Requestor.GetString(url);

			return Mapper<StripePlan>.MapCollectionFromJson(response);
		}
        #endregion
	}
}