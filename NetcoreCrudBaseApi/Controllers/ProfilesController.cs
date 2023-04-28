using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetcoreCrudBaseApi.Controllers.Base;
using NetcoreCrudBaseApi.Domains.Dtos.Profiles;
using NetcoreCrudBaseApi.Domains.Services;
using NetcoreCrudBaseApi.Infrastructure.Exceptions;
using NetcoreCrudBaseApi.Infrastructure.Responses;

namespace NetcoreCrudBaseApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ProfilesController : ControllerBase, ICrudController<CreateProfileDto, UpdateProfileDto, ReadProfileDto>
{
    private readonly ProfileService _service;
    public ProfilesController(ProfileService service)
    {
        _service = service;
    }
    /// <summary>
    /// Create a record in database
    /// </summary>
    /// <param name="resquest">Object for create</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Request was created successful</response>
    /// <response code="400">Request has errors</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] CreateProfileDto resquest)
    {
        var id = _service.Create(resquest);
        return CreatedAtAction(nameof(Read), new { id }, ResponseMessage.CreatedSuccess());
    }
    /// <summary>
    /// Read a record in database
    /// </summary>
    /// <param name="id">PK record</param>
    /// <returns>IActionResult</returns>
    /// <response code="404">Request was not found</response>
    /// <response code="200">Request was successful</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Read(long id)
    {
        var reference = _service.Read(id);
        return (reference != null) ? Ok(reference) : NotFound(ResponseMessage.NotFound());
    }
    /// <summary>
    /// Update a record in database
    /// </summary>
    /// <param name="id">PK record</param>
    /// <param name="resquest">Object for update</param>
    /// <returns>IActionResult</returns>
    /// <response code="400">Request has errors</response>
    /// <response code="403">Request was forbidden</response>
    /// <response code="404">Request was not found</response>
    /// <response code="200">Request was successful</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Update(long id, [FromBody] UpdateProfileDto resquest)
    {
        try
        {
            return _service.Update(id, resquest) ? Ok(ResponseMessage.UpdatedSuccess()) : NotFound(ResponseMessage.NotFound());
        }
        catch (ForbiddenAccessException ex)
        {
            return StatusCode(StatusCodes.Status403Forbidden, ResponseForbidden.EmitMessage(ex.Message));
        }
    }
    /// <summary>
    /// Search records in database
    /// </summary>
    /// <param name="skip"></param>
    /// <param name="take"></param>
    /// <returns>IEnumerable</returns>
    /// <response code="200">Request was successful</response>    
    [HttpGet("search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ReadProfileDto> Search([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _service.Search(skip, take);
    }
    /// <summary>
    /// Delete a record database
    /// </summary>
    /// <param name="id">PK record</param>    
    /// <returns>IActionResult</returns>
    /// <response code="403">Request was forbidden</response>
    /// <response code="404">Request was not found</response>
    /// <response code="200">Request was successful</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult Delete(long id)
    {
        try
        {
            return _service.Delete(id) ? Ok(ResponseMessage.DeletedSuccess()) : NotFound(ResponseMessage.NotFound());
        }
        catch (ForbiddenAccessException ex)
        {
            return StatusCode(StatusCodes.Status403Forbidden, ResponseForbidden.EmitMessage(ex.Message));
        }

    }

}
