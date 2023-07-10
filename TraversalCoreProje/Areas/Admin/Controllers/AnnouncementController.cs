using AutoMapper;
using BusinessLayer.Abstract;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DtoLayer.DTOs.AnnoucementDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TraversalCoreProje.Areas.Admin.Models.Accouncement;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnoucementService _annoucementService;
        private readonly IMapper _mapper;

        public AnnouncementController(IAnnoucementService annoucementService, IMapper mapper)
        {
            _annoucementService = annoucementService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            List<Announcement> values = _annoucementService.TGetList();
            List<AnnouncementViewModel> model = new List<AnnouncementViewModel>();
           
            foreach (var item in values)
            {
               AnnouncementViewModel modelItem = new AnnouncementViewModel();
                modelItem.AnnouncementID = item.AnnouncementID;
                modelItem.AnnouncementContent = item.AnnouncementDescription;
                modelItem.AnnouncementTitle = item.AnnouncementTitle;

                model.Add(modelItem);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult AnnouncementAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AnnouncementAdd(AnnouncementAddDto announcement)
        {
            announcement.AnnouncementDate = DateTime.Now;
            var values = _mapper.Map<Announcement>(announcement);
            _annoucementService.TInsert(values);
            return RedirectToAction("Index","Announcement");
        }

        public IActionResult AnnouncementDelete(int id)
        {
            var value = _annoucementService.TGetByID(id);
            _annoucementService.TDelete(value);
            return RedirectToAction("Index", "Announcement");
        }
        [HttpGet]
        public IActionResult AnnouncementUpdate(int id)
        {
            var values = _mapper.Map<AnnouncementUpdateDto>(_annoucementService.TGetByID(id));
            return View(values);
        }
        [HttpPost]
        public IActionResult AnnouncementUpdate(AnnouncementUpdateDto announcementUpdateDto)
        {
            var value = _mapper.Map<Announcement>(announcementUpdateDto);
            value.AnnouncementDate = DateTime.Now;
            _annoucementService.TUpdate(value);
            return RedirectToAction("Index","Announcement");

        }
    }
}
