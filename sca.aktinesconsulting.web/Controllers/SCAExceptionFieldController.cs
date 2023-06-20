using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sca.aktinesconsulting.entitiy;
using sca.aktinesconsulting.service.Interface;
using sca.aktinesconsulting.web.Common;
using sca.aktinesconsulting.web.Models;
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

        [HttpGet]
        public async Task<IList<SCAExceptionField>> GetBySCAExceptionFieldTypeId(int? scaExceptionFieldTypeId)
        {
            return await _scaExceptionFieldService.GetBySCAExceptionFieldTypeId(scaExceptionFieldTypeId);
        }

        [HttpPost]
        public async Task<int> AddUpdate([FromBody] SCAExceptionFieldModel scaExceptionFieldModel)
        {
            scaExceptionFieldModel.UserId= (int)HttpContext.User.GetUserId();
            return await _scaExceptionFieldService.AddUpdate(scaExceptionFieldModel.SCAExceptionFieldTypeId, scaExceptionFieldModel.Name,scaExceptionFieldModel.UserId);
        }

        [HttpPost]
        public async Task<int> Delete([FromQuery] int scaExceptionFieldId)
        {
            return await _scaExceptionFieldService.Delete(scaExceptionFieldId);
        }

    }
}
