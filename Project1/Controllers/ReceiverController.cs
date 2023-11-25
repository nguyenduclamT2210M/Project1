using Microsoft.AspNetCore.Mvc;
using Project1.DTOs;
using Project1.Entities;
using Project1.Models;

namespace Project1.Controllers
{
    [ApiController]
    [Route("/api/receiver")]
    public class ReceiverController : Controller
    {
        private readonly ProjectContext _context;
        public ReceiverController(ProjectContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<ReceiverDTO> receivers = _context.Receivers
                .Select( m => new ReceiverDTO
                {
                    IdReceiver = m.IdReceiver,
                    Name = m.Name,
                    Address = m.Address,
                    Tel = m.Tel,
                })
                .ToList();
            return Ok(receivers);
        }
        [HttpPost]
        public IActionResult Create(ReceiverDTO model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    Receivers receivers = new Receivers
                    {
                        Name = model.Name,
                        Address = model.Address,
                        Tel = model.Tel,
                    };
                    _context.Receivers.Add(receivers);
                    _context.SaveChanges();
                    return Created("",new ReceiverDTO{
                        IdReceiver = receivers.IdReceiver,
                        Name = receivers.Name,
                        Address = receivers.Address,
                        Tel = receivers.Tel,
                    });
                }catch (Exception ex)
                { 
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest("Done");
        }
        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            try
            {
                Receivers receivers = _context.Receivers.Find(id);
                _context.Receivers.Remove(receivers);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Edit(ReceiverDTO model)
        {
            if( ModelState.IsValid )
            {
                try
                {
                    _context.Receivers.Update(new Receivers
                    {
                        IdReceiver= model.IdReceiver,
                        Name = model.Name,
                        Address = model.Address,
                        Tel = model.Tel,
                    });
                    _context.SaveChanges();
                    return Ok("Successfully");
                }catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest("Done");
        }

    }
}
