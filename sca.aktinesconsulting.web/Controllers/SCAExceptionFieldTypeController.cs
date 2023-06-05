using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sca.aktinesconsulting.entitiy;
using sca.aktinesconsulting.service.Interface;
using sca.aktinesconsulting.web.Models;

namespace sca.aktinesconsulting.web.Controllers
{
    [Authorize]
    public class SCAExceptionFieldTypeController : Controller
    {


        private readonly ISCAExceptionFieldTypeService _scaExceptionFieldTypeService;

        public SCAExceptionFieldTypeController(ISCAExceptionFieldTypeService scaExceptionFieldTypeService)
        {
            _scaExceptionFieldTypeService = scaExceptionFieldTypeService;
        }


        [Route("/scaexception/master/view")]
        public async Task<IActionResult> Index()
        {
            var scaExceptionFieldTypeModel = new SCAExceptionFieldTypeModel();
            scaExceptionFieldTypeModel.SCAExceptionFieldTypes = await _scaExceptionFieldTypeService.GetAll();
            return View(scaExceptionFieldTypeModel);
        }



    }
}
