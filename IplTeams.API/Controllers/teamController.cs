using AutoMapper;
using IplTeams.API.Data;
using IplTeams.API.Dto.Teams;
using IplTeams.API.Models;
using IplTeams.API.Repository;
using IplTeams.API.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IplTeams.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class teamController : ControllerBase
    {
        private readonly ITeamsRepository _teamRepository;
        private readonly IMapper _mapper;
        public teamController(ITeamsRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<GetTeamDto>>> GetAll()
        {
            var teams =await _teamRepository.GetAll();
            if(teams==null)
            {
                return NoContent();
            }
            var teamDto = _mapper.Map<List<GetTeamDto>>(teams);
            return Ok(teamDto);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<GetTeamDto>> GetById(int id)
        {
            var teams =await _teamRepository.GetById(id);
            if (teams == null)
            {
                return NoContent();
            }
            var teamDto = _mapper.Map<GetTeamDto>(teams);
            return Ok(teamDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<CreateTeamDto>> Create([FromBody] CreateTeamDto teamDto)
        {
            var result = _teamRepository.IsTeamsExists(x=>x.Name==teamDto.Name);
            if(result)
            {
                return Conflict("Team already exists");
            }
            var team = _mapper.Map<team>(teamDto);
            await _teamRepository.Create(team);
            return CreatedAtAction("GetById",new {id=team.Id},team);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UpdateTeamDto>> Update(int id, [FromBody] UpdateTeamDto teamDto)
        {
            if(teamDto==null || id!=teamDto.Id)
            {
                return BadRequest();
            }
            var team = _mapper.Map<team>(teamDto);
            await _teamRepository.Update(team);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<team>> Delete(int id)
        {
            if(id==0)
            {
                return BadRequest();
            }
            var team =await _teamRepository.GetById(id);
            if(team==null)
            {
                return NotFound();
            }
            await _teamRepository.Delete(team);
            return NoContent();
        }
    }
}
