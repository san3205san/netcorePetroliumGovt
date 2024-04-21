using System;
namespace PPAC_API.DAL.ResponseModel
{
    public class PPACResponse
    {
        public string MONTH { get; set; }
        public int COUNT_OF_RECORDS { get; set; }
        public string COMPANY { get;set;}
        public required List<DATA> DATA { get; set; }
        
    }

    public class DATA
    {
        

        public string PRODUCT_CODE { get; set; }

        public int TRANSPORT_MODE { get; set; }

        public string STATE_CODE { get; set; }

        public string DISTRICT_CODE { get; set; }

        public int CUSTOMER_CATEGORY { get; set; }

        public int END_USE { get; set; }

        public decimal QUANTITY { get; set; }

        
    }

}



