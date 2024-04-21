using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PPAC_API.BAL.Interfaces;
using PPAC_API.DAL.ResponseModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PPAC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PPACController : ControllerBase
    {
        // Dependency injection object for employee service
        private readonly IPPAC_Repository _ppacService;

        public PPACController(IPPAC_Repository ppacRepository)
        {
            this._ppacService = ppacRepository;
        }

        [HttpGet]  //action methos 
        public Task<IEnumerable<PPACResponse>> GetPPACData()
        {
            // calling the services 
            return _ppacService.GetAllDetails();

        }
    }
}

