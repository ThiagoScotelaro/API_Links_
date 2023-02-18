using Aula3.Entities;
using Aula3.Models;
using Aula3.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Aula3.Controllers
{
    [ApiController]
    [Route("api/shortenedLinks")]
    public class ShortenedLinksController : ControllerBase
    {
        private readonly EncurtaUrlDbContext _context;

        public ShortenedLinksController(EncurtaUrlDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Links);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var link = _context.Links.SingleOrDefault(x => x.Id == id);
            if (link == null)
            {
                return NotFound();
            }
            return Ok(link);

        }
        /// <summary>
        /// Cadastrar um link encurtado
        /// </summary>
        /// <remark>
        /// {"title": "Linkedin Thiago Scotelaro", "Destinationlink":"https://www.linkedin.com/in/thiago-scotelaro/"}
        /// </remark>
        /// <param name="model">Dados de Link</param>
        /// <returns> Objeto recém criado</returns>
        /// <response code= "201"> Sucesso </response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(AddUpdate model)
        {
            var link = new ShortLink(model.Title, model.DestinationLink);
            _context.Links.Add(link);
            _context.SaveChanges();
            return CreatedAtAction("GetById", new { id = link.Id }, link);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, AddUpdate model)
        {
            var link = _context.Links.SingleOrDefault(x => x.Id == id);
            if (link == null)
            {
                return NotFound();
            }
            link.Update(model.Title, model.DestinationLink);
            _context.Links.Update(link);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var link = _context.Links.SingleOrDefault(x => x.Id == id);
            if (link == null)
            {
                return NotFound();
            }
            _context.Links.Remove(link);
            _context.SaveChanges();
            return NoContent();

        }
        [HttpGet("/{code}")]
        public IActionResult Redirectlink(string code)
        {
            var link = _context.Links.SingleOrDefault(x => x.Code == code);
            if (link == null)
            {
                return NotFound();
            }
            return Redirect(link.DestinationLink);
        }
    }
}