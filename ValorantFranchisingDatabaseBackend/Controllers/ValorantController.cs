using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ValorantController : ControllerBase
{
    private readonly ValorantApiService _valorantApiService;

    public ValorantController(ValorantApiService valorantApiService)
    {
        _valorantApiService = valorantApiService;
    }

    [HttpGet("teams/{region}")]
    public async Task<IActionResult> GetTeamsByRegion(string region)
    {
        var teams = await _valorantApiService.GetTeamsByRegionAsync(region);
        return Ok(teams);
    }

    [HttpGet("teams/all")]
    public async Task<IActionResult> GetAllTeams()
    {
        var teams = await _valorantApiService.GetAllTeamsAsync();
        return Ok(teams);
    }

    [HttpGet("players/all")]
    public async Task<IActionResult> GetAllPlayers()
    {
        try
        {
            var players = await _valorantApiService.GetAllPlayersAsync();
            if (players == null || players.Count == 0)
            {
                return NotFound("No players found.");
            }
            return Ok(players);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("players/{teamId}")]
    public async Task<IActionResult> GetPlayersByTeam(int teamId)
    {
        var players = await _valorantApiService.GetPlayersByTeamAsync(teamId);
        return Ok(players);
    }

    [HttpGet("player-stats/{playerId}")]
    public async Task<IActionResult> GetPlayerStats(int playerId)
    {
        var stats = await _valorantApiService.GetPlayerStatsAsync(playerId);
        return Ok(stats);
    }
}
