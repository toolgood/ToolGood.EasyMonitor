﻿using Microsoft.AspNetCore.Mvc;

namespace WebsiteServiceClient.Controllers
{
    //Server
    public class ServerController : ClientControllerBase
    {
        [HttpPost]
        public IActionResult GetServiceList(long timestamp,string sign)
        {
            return View();
        }

        [HttpPost]
        public IActionResult StopService(long timestamp,string sign)
        {
            return View();
        }

        [HttpPost]
        public IActionResult StartService(long timestamp,string sign)
        {
            return View();
        }

        [HttpPost]
        public IActionResult InstallService(long timestamp,string sign)
        {
            return View();
        }

        [HttpPost]
        public IActionResult UninstallService(long timestamp,string sign)
        {
            return View();
        }


        [HttpPost]
        public IActionResult UploadService(long timestamp,string sign)
        {
            return View();
        }

        [HttpPost]
        public IActionResult BlackupService(long timestamp,string sign)
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult UpdateService(long timestamp,string sign)
        {
            return View();
        }

        [HttpPost]
        public IActionResult RestoreService(long timestamp,string sign)
        {
            return View();
        }

    }


}