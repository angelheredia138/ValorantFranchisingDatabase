using System.Net.Http.Json;
using System.Text.Json;

public class ValorantApiService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://vlr-franchising-api-eze5a7bxc3ehh4ga.canadacentral-01.azurewebsites.net/api";

    public ValorantApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Team>> GetTeamsByRegionAsync(string region)
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}/Teams/scrape/{region}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<Team>>();
    }

    public async Task<List<Team>> GetAllTeamsAsync()
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}/Teams/scrape/all");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<Team>>();
    }

    public async Task<List<Player>?> GetAllPlayersAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/Players/scrape/all");
            response.EnsureSuccessStatusCode();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return await response.Content.ReadFromJsonAsync<List<Player>>(options);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching players: {ex.Message}");
            throw;
        }
    }


    public async Task<List<Player>> GetPlayersByTeamAsync(int teamId)
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}/Players/scrape/{teamId}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<Player>>();
    }

    public async Task<PlayerStats> GetPlayerStatsAsync(int playerId)
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}/PlayerStats/scrape/{playerId}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<PlayerStats>();
    }
}
