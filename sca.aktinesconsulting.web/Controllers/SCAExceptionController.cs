using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using sca.aktinesconsulting.service.Implementation;
using sca.aktinesconsulting.service.Interface;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using sca.aktinesconsulting.web.Common;

namespace sca.aktinesconsulting.web.Controllers
{
    [Authorize]
    public class SCAExceptionController : Controller
    {
        private readonly IFileService _fileService;
        private readonly ISCAExceptionService _exceptionService;
        public SCAExceptionController(IFileService fileService, ISCAExceptionService exceptionService)
        {
            _fileService = fileService;
            _exceptionService = exceptionService;
        }
        public IActionResult Index()
        {
            return View();
        }
     

        [HttpPost]
        public async Task<string> ProcessBookingEntry([FromForm] IFormFile file)
        {
           
            var userId= (int)HttpContext.User.GetUserId();
            if (file == null)
                return string.Empty;
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream).ConfigureAwait(false);
                var dt = _fileService.ExcelDataReader(memoryStream, string.Empty, "X").FirstOrDefault();
                if (dt != null)
                {
                    return JsonConvert.SerializeObject(await _exceptionService.Identify(userId,dt));
                }
            } 
            return string.Empty;
        }


       

    }
}
