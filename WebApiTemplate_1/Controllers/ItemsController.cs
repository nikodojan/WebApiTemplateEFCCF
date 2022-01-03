using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTemplateV1.Managers;
using WebApiTemplateV1.Models;

namespace WebApiTemplateV1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        //TODO: create reference for Manager
        private ItemsManager _manager;

        public ItemsController(ItemsManager manager)
        {
            //TODO: inject the repository/manger
            _manager = manager;
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> Get()
        {
            var result = await _manager.GetAllAsync();
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetById(int id)
        {
            var entity = await _manager.GetByIdAsync(id);
            if (entity is null) return NotFound($"Id {id} was not found.");
            return Ok(entity);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]   
        [HttpPost]
        public async Task<ActionResult<Item>> Post([FromBody] Item value)
        {
            var entity = await _manager.AddAsync(value);
            if (entity is null) return Conflict("An error occurred while posting the new item.");
            return Created(entity.Id.ToString(), entity);
        }
        
        [HttpPut("{id}")]   
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]  
        public async Task<ActionResult<Item>> Put(int id, [FromBody] Item entity)
        {   
            if (id != entity.Id) return BadRequest();
            var result = await _manager.UpdateAsync(id, entity);
            if (result is null) return NotFound($"Id {id} was not found.");
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _manager.DeleteAsync(id);
            return result ? Ok() : NotFound();
        }
    }
}
