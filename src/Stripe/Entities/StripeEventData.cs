using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Stripe
{
	public class StripeEventData
	{
		[JsonProperty("previous_attributes")]
		public object PreviousAttributes { get; set; }

		[JsonProperty("object")]
		public object Object { get; set; }
	}
}