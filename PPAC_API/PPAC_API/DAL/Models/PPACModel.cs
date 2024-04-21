using System;
namespace PPAC_API.DAL.Models
{
	public class PPACModel
	{
        public string COMPANY_CODE { get; set; }

        public string PRODUCT_CODE { get; set; }

        public int TRANSPORT_MODE { get; set; }

        public string STATE_CODE { get; set; }

        public string REVENUE_DISTRICT_CODE { get; set; }

        public int CUSTOMER_CATEGORY { get; set; }

        public int END_USE { get; set; }

        public decimal QUANTITY { get; set; }

        public string MMM_YY { get; set; }
    }
}

