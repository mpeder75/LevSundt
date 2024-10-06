using System.Net.Mime;
using LevSundt.Bmi.Application.Command;
using LevSundt.Bmi.Application.Command.Dto;
using LevSundt.Bmi.Application.Queries;
using LevSundt.Bmi.Application.Queries.Dto;
using Microsoft.AspNetCore.Mvc;

namespace LevSundt.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BmiController : ControllerBase
{
    private readonly IBmiGetAllQuery _bmiGetAllQuery;
    private readonly IBmiGetQuery _bmiGetQuery;
    private readonly ICreateBmiCommand _createBmiCommand;
    private readonly IEditBmiCommand _editBmiCommand;

    public BmiController(IBmiGetAllQuery bmiGetAllQuery, IBmiGetQuery bmiGetQuery, ICreateBmiCommand createBmiCommand,
        IEditBmiCommand editBmiCommand)
    {
        _bmiGetAllQuery = bmiGetAllQuery;
        _bmiGetQuery = bmiGetQuery;
        _createBmiCommand = createBmiCommand;
        _editBmiCommand = editBmiCommand;
    }

    [HttpGet("{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<BmiQueryResultDto>> Get(string userId)
    {
        var result = _bmiGetAllQuery.GetAll(userId).ToList();

        if (!result.Any()) return NotFound();
        return result.ToList();
    }

    [HttpGet("{id}/{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<BmiQueryResultDto> Get(int id, string userId)
    {
        var result = _bmiGetQuery.Get(id, userId);
        if (result == null) return NotFound();
        return result;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Post(BmiCreateRequestDto request)
    {
        try
        {
            _createBmiCommand.Create(request);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpPut]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Put(BmiEditRequestDto request)
    {
        try
        {
            _editBmiCommand.Edit(request);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
}