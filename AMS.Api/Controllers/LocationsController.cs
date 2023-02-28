using AMS.Application.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        // [HttpPost]
        // public ActionResult<LocationDto> CreateAuthor(LocationForCreationDto author)
        // {
        //     var authorEntity = _mapper.Map<Entities.Author>(author);
        //     _courseLibraryRepository.AddAuthor(authorEntity);
        //     _courseLibraryRepository.Save();
        //
        //     var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);
        //
        //     var links = CreateLinksForAuthor(authorToReturn.Id, null);
        //
        //     var linkedResourceToReturn = authorToReturn.ShapeData(null)
        //         as IDictionary<string, object>;
        //     linkedResourceToReturn.Add("links", links);
        //
        //     return CreatedAtRoute("GetAuthor",
        //         new { authorId = linkedResourceToReturn["Id"] },
        //         linkedResourceToReturn);
        // }
    }
}
