using System;
using Microsoft.EntityFrameworkCore;
using PPAC_API.BAL.Interfaces;
using PPAC_API.DAL;
using PPAC_API.DAL.ResponseModel;

namespace PPAC_API.BAL.Services
{
	public class PPAC_Repository : IPPAC_Repository
	{
		private readonly PPACDbContext _ppacDbContext;
		public PPAC_Repository(PPACDbContext pPACDbContext)
		{
			_ppacDbContext = pPACDbContext;
		}

        public async Task<IEnumerable<PPACResponse>> GetAllDetails()
        {
			var resultData = await _ppacDbContext.PPAC.ToListAsync();

			List<DATA> dataList = new List<DATA>();

			foreach(var r in resultData)
			{
				DATA d = new DATA
				{
					CUSTOMER_CATEGORY = r.CUSTOMER_CATEGORY,
					DISTRICT_CODE = r.REVENUE_DISTRICT_CODE,
					PRODUCT_CODE = r.PRODUCT_CODE,
					END_USE = r.END_USE,
					QUANTITY = r.QUANTITY,
					STATE_CODE = r.STATE_CODE,
					TRANSPORT_MODE = r.TRANSPORT_MODE
				};

				dataList.Add(d);
			}


			PPACResponse ppac = new PPACResponse
			{
				COMPANY = resultData[0].COMPANY_CODE,
				MONTH = resultData[0].MMM_YY,
				COUNT_OF_RECORDS = resultData.Count,
				DATA = dataList
			};

			return (IEnumerable<PPACResponse>)ppac;

        }
    }
}

