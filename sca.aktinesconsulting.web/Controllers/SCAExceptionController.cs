﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using sca.aktinesconsulting.service.Implementation;
using sca.aktinesconsulting.service.Interface;
using Newtonsoft.Json;

namespace sca.aktinesconsulting.web.Controllers
{
    public class SCAExceptionController : Controller
    {
        private readonly IFileService _fileService;
        private readonly IExceptionService _exceptionService;
        public SCAExceptionController(IFileService fileService, IExceptionService exceptionService)
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
            if (file == null)
                return string.Empty;
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream).ConfigureAwait(false);
                var dt = _fileService.ExcelDataReader(memoryStream, string.Empty, "X").FirstOrDefault();
                if (dt != null)
                {
                    return JsonConvert.SerializeObject(_exceptionService.Identify(dt));
                }
            }
            return string.Empty;
        }
    }
}