using System;
using PPAC_API.DAL.ResponseModel;

namespace PPAC_API.BAL.Interfaces
{
	public interface IPPAC_Repository
	{
		public Task<IEnumerable<PPACResponse>> GetAllDetails();
	}
}

