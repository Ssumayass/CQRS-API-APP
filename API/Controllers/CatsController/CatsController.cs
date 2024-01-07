using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.Queries.Cats.GetAll;
using Application.Queries.Cats.GetById;
using Application.Dtos;
using Application.Commands.Cats.UpdateCat;
using Application.Commands.Cats.DeleteCat;
using Application.Commands.Cats.AddCat;

namespace API.Controllers.CatsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : Controller
    {
        internal readonly IMediator _mediator;
        public CatsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get all birds from database
        [HttpGet]
        [Route("getAllCats")]
        public async Task<IActionResult> GetAllCats()
        {
            return Ok(await _mediator.Send(new GetAllCatsQuery()));
        }

        // Get a bird by Id
        [HttpGet]
        [Route("getCatById/{birdId}")]
        public async Task<IActionResult> GetCatById(Guid birdId)
        {
            return Ok(await _mediator.Send(new GetCatByIdQuery(birdId)));
        }

        // Create a new bird 
        [HttpPost]
        [Route("addNewCat")]
        public async Task<IActionResult> AddCat([FromBody] CatDto newCat)
        {
            return Ok(await _mediator.Send(new AddCatCommand(newCat)));
        }

        // Update a specific bird
        [HttpPut]
        [Route("updateCat/{updatedCatId}")]
        public async Task<IActionResult> UpdateCat([FromBody] CatDto updatedCat, Guid updatedCatId)
        {
            return Ok(await _mediator.Send(new UpdateCatByIdCommand(updatedCat, updatedCatId)));
        }

        // Delete a bird by Id
        [HttpDelete]
        [Route("deleteCCatById/{birdId}")]
        public async Task<IActionResult> DeleteCatById(Guid birdId)
        {
            return Ok(await _mediator.Send(new DeleteCatByIdCommand(birdId)));
        }
    }
}