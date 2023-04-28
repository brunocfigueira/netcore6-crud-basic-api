using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetcoreCrudBaseApi.Controllers.Base;
using NetcoreCrudBaseApi.Domains.Dtos.ProfilePermission;
using NetcoreCrudBaseApi.Domains.Services;
using NetcoreCrudBaseApi.Infrastructure.Exceptions;
using NetcoreCrudBaseApi.Infrastructure.Responses;

namespace NetcoreCrudBaseApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ProfilePermissionController : ControllerBase, ICrudController<CreateProfilePermissionDto, UpdateProfilePermissionDto, ReadProfilePermissionDto>
{
    private readonly ProfilePermissionService _service;
    public ProfilePermissionController(ProfilePermissionService service)
    {
        _service = service;
    }
    /// <summary>
    /// Create a record in database
    /// </summary>
    /// <param name="resquest">Object for create</param>
    /// <returns>IActionResult</returns>
    /// <response code="400">Request has errors</response>
    /// <response code="403">Request was forbidden</response>
    /// <response code="201">Request was created successful</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult Create([FromBody] CreateProfilePermissionDto resquest)
    {
        try
        {
            var profileId = _service.Create(resquest);
            return CreatedAtAction(nameof(Read), new { profileId }, ResponseMessage.CreatedSuccess());
        }
        catch (RuleViolationException ex)
        {
            return BadRequest(ResponseErrors.RuleViolation(ex.Message));
        }
        catch (ForbiddenAccessException ex)
        {
            return StatusCode(StatusCodes.Status403Forbidden, ResponseForbidden.EmitMessage(ex.Message));
        }
    }
    /// <summary>
    /// Read a record in database
    /// </summary>
    /// <param name="profileId">PK record</param>
    /// <returns>IActionResult</returns>
    /// <response code="404">Request was not found</response>
    /// <response code="200">Request was successful</response>
    [HttpGet("{profileId}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Read(long profileId)
    {
        var reference = _service.ReadByProfileId(profileId);
        return (reference != null) ? Ok(reference) : NotFound(ResponseMessage.NotFound());
    }

    /// <summary>
    /// Update a record in database
    /// </summary>
    /// <param name="profileId">PK record</param>
    /// <param name="resquest">Object for update</param>
    /// <returns>IActionResult</returns>
    /// <response code="400">Request has errors</response>
    /// <response code="403">Request was forbidden</response>
    /// <response code="404">Request was not found</response>
    /// <response code="200">Request was successful</response>
    [HttpPut("{profileId}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Update(long profileId, [FromBody] UpdateProfilePermissionDto resquest)
    {
        try
        {
            return _service.Update(profileId, resquest) ? Ok(ResponseMessage.UpdatedSuccess()) : NotFound(ResponseMessage.NotFound());
        }
        catch (RuleViolationException ex)
        {
            return BadRequest(ResponseErrors.RuleViolation(ex.Message));
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
    public IEnumerable<ReadProfilePermissionDto> Search([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _service.Search(skip, take);
    }
    /// <summary>
    /// Delete a record database
    /// </summary>
    /// <param name="profileId">PK record</param>    
    /// <returns>IActionResult</returns>
    /// <response code="403">Request was forbidden</response>
    /// <response code="404">Request was not found</response>
    /// <response code="200">Request was successful</response>
    [HttpDelete("{profileId}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult Delete(long profileId)
    {
        try
        {
            return _service.Delete(profileId) ? Ok(ResponseMessage.DeletedSuccess()) : NotFound(ResponseMessage.NotFound());
        }
        catch (RuleViolationException ex)
        {
            return BadRequest(ResponseErrors.RuleViolation(ex.Message));
        }
        catch (ForbiddenAccessException ex)
        {
            return StatusCode(StatusCodes.Status403Forbidden, ResponseForbidden.EmitMessage(ex.Message));
        }
    }
}
