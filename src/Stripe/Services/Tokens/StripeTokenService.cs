using Newtonsoft.Json;
using Stripe.Infrastructure;

namespace Stripe
{
	public class StripeTokenService
	{
        public string ApiKeyAppSettingName;

        public StripeTokenService() { }
        public StripeTokenService(string ApiKeyAppSettingName)
        {
            this.ApiKeyAppSettingName = ApiKeyAppSettingName;
        }

		public virtual StripeToken Create(StripeTokenCreateOptions createOptions)
		{
			var url = ParameterBuilder.ApplyAllParameters(createOptions, Urls.Tokens);

			var response = Requestor.PostString(url,ApiKeyAppSettingName);

			return Mapper<StripeToken>.MapFromJson(response);
		}

		public virtual StripeToken Get(string tokenId)
		{
			var url = string.Format("{0}/{1}", Urls.Tokens, tokenId);

			var response = Requestor.GetString(url,ApiKeyAppSettingName);

			return Mapper<StripeToken>.MapFromJson(response);
		}
	}
}