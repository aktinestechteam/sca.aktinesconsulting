using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sca.aktinesconsulting.entitiy;
using sca.aktinesconsulting.service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.web.Controllers
{
    [Authorize]
    public class SCAExceptionFieldController : Controller
    {

        private readonly ISCAExceptionFieldService _scaExceptionFieldService;


        public SCAExceptionFieldController(ISCAExceptionFieldService scaExceptionFieldService)
        {
            _scaExceptionFieldService = scaExceptionFieldService;
        }

        [HttpGet]
        public async Task<IList<SCAExceptionField>> GetAll()
        {
            return await _scaExceptionFieldService.GetAll();
        }
    }
}
