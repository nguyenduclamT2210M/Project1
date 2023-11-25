using Microsoft.AspNetCore.Mvc;
using Project1.Entities;
using Project1.DTOs;
using Project1.Models;

namespace Project1.Controllers
{
    [ApiController]
    [Route("/api/SericeType")]
    public class SericeTypeController : Controller
    {
        private readonly ProjectContext _context;
        public SericeTypeController(ProjectContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<SericeTypeDTO> std = _context.SericeTypes
                .Select(s => new SericeTypeDTO
                {
                    IdServiceType = s.IdServiceType,
                    Name = s.Name,
                    Description = s.Description,
                    Price = s.Price,
                })
                .ToList();
            return Ok(std);
        }
        [HttpPost]
        public IActionResult Create(SericeTypeModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    SericeTypes sericetype = new SericeTypes
                    {
                        Name = model.Name,
                        Description = model.Description,
                        Price = model.Price,
                    };
                    _context.SericeTypes.Add(sericetype);
                    _context.SaveChanges();
                    return Created("", new SericeTypeDTO
                    {
                        IdServiceType = sericetype.IdServiceType,
                        Name = sericetype.Name,
                        Description = sericetype.Description,
                        Price = sericetype.Price,
                    });
                }catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest("Done");
        }
    }
}
