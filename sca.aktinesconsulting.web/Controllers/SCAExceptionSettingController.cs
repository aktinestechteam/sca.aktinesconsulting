using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sca.aktinesconsulting.entitiy;
using sca.aktinesconsulting.service.Interface;
using sca.aktinesconsulting.web.Common;
using sca.aktinesconsulting.web.FieldMapper;
using sca.aktinesconsulting.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.web.Controllers
{
    [Authorize]
    public class SCAExceptionSettingController : Controller
    {
        private readonly ISCAExceptionService _scaExceptionService;

        public SCAExceptionSettingController(ISCAExceptionService scaExceptionService)
        {
            _scaExceptionService = scaExceptionService;
        }

        [Route("/scaexception/setting/add")]
        [Route("/scaexception/setting/update/{exceptionId?}")]
        public IActionResult Index(int exceptionId = 0)
        {
            if (!User.IsAllowed(Permissions.SCARule, PermissionType.Create))
                return Redirect("/SCAException/Index");

                ViewData["exceptionId"] = exceptionId;
            return View("AddUpdate");
        }

        [Route("/scaexception/setting/view")]
        public IActionResult Exceptions()
        {
            if (!User.IsAllowed(Permissions.SCARule, PermissionType.Create))
                return Redirect("/SCAException/Index");

            return View();
        }

        [HttpGet]
        public async Task<IEnumerable<SCAException>> GetAll()
        {
            return await _scaExceptionService.GetAll();
        }

        [HttpGet]
        public async Task<SCAException> GetById([FromQuery] int scaExceptionId)
        {
            return await _scaExceptionService.GetById(scaExceptionId);
        }



        [HttpPost]
        public async Task<string> AddUpdate([FromBody] SCAExceptionModel modal)
        {
           
            var entity = Mapper.MapSCAException(modal);
            var bookingEntry = Mapper.MapBookingEntry(entity);
            var scaException = await _scaExceptionService.Validate(bookingEntry);
            var isExceptionFound = false;
            int?[] exceptionRules = null;
            if (scaException.Exceptions != null && scaException.Exceptions.Count > 0)
            {
              
                if (
                    (modal.SCAExceptionId != 0 && scaException.Exceptions[0].SCAExceptionId != modal.SCAExceptionId)
                    || modal.SCAExceptionId == 0)
                {
                    exceptionRules = scaException.Exceptions.Select(e => e.SCAExceptionId).ToArray();
                    isExceptionFound = true;
                }
            }
            if (!isExceptionFound)
            {
                if (modal.SCAExceptionId != 0)
                {
                    entity.UpdatedBy = HttpContext.User.GetUserId();
                    entity.UpdatedOn = DateTime.UtcNow;
                    await _scaExceptionService.Update(entity);
                }
                else
                {
                    entity.CreatedBy = HttpContext.User.GetUserId();
                    entity.CreatedOn = DateTime.UtcNow;
                    await _scaExceptionService.Add(entity);
                }
            }
            return exceptionRules == null || !isExceptionFound ? null : string.Join(",", exceptionRules);
        }



        [HttpPost]
        public async Task<IActionResult> Delete([FromQuery] int scaExceptionId)
        {
            var userId = HttpContext.User.GetUserId();
            if (userId != null)
                await _scaExceptionService.Delete(scaExceptionId, (int)userId);
            return Ok();
        }

    }
}
