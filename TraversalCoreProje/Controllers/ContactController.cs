using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.DTOs.Contact;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TraversalCoreProje.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(SendMessageDto sendMessageDto)
        {
            if(ModelState.IsValid)
            {
             var value = _mapper.Map<Contact>(sendMessageDto);
                value.Status = true;
            _contactService.TInsert(value);
            return RedirectToAction("Index","Default");
            }
           
            return View(sendMessageDto);
        }
    }
}
