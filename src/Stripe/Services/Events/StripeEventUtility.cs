using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Stripe
{
	public static class StripeEventUtility
	{
		public static StripeEvent ParseEvent(string json)
		{
			return Mapper<StripeEvent>.MapFromJson(json);
		}

		public static T ParseEventDataItem<T>(object dataItem)
		{

            return Mapper<T>.MapFromJson(dataItem.ToString());
		}

        public static T ParseEventDataItemType<T>(object dataItem)
        {
            return Mapper<T>.MapFromJson(dataItem.ToString());
        }
	}
}