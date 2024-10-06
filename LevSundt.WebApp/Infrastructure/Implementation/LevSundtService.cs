using LevSundt.WebApp.Infrastructure.Contract;
using LevSundt.WebApp.Infrastructure.Contract.Dto;

namespace LevSundt.WebApp.Infrastructure.Implementation;

public class LevSundtService : ILevSundtService
{
    private readonly HttpClient _httpClient;

    public LevSundtService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    async Task ILevSundtService.Create(BmiCreateRequestDto bmiCreateRequestDto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/bmi", bmiCreateRequestDto);

        if (response.IsSuccessStatusCode) return;

        var message = await response.Content.ReadAsStringAsync();
        throw new Exception(message);
    }

    async Task ILevSundtService.Edit(BmiEditRequestDto bmiEditRequestDto)
    {
        var response = await _httpClient.PutAsJsonAsync("api/bmi", bmiEditRequestDto);

        if (response.IsSuccessStatusCode) return;

        var message = await response.Content.ReadAsStringAsync();
        throw new Exception(message);
    }

    async Task<BmiQueryResultDto?> ILevSundtService.Get(int id, string userId)
    {
        return await _httpClient.GetFromJsonAsync<BmiQueryResultDto>($"api/bmi/{userId}/{id}");
    }

    async Task<IEnumerable<BmiQueryResultDto>?> ILevSundtService.GetAll(string userId)
    {
        /// <summary>
        /// Metode modtager en userId og returnerer en liste af BmiQueryResultDto fra et API endpoint
        /// 1. Metoden er erklæret som async, hvilket indikerer, at den kan udføre asynkrone operationer.
        /// 2. Metoden tager en string parameter kaldet userId, som repræsenterer bruger-ID'et, der bruges til at hente BMI-dataene.
        /// 3. Inde i metoden bruger den _httpClient objektet til at lave en HTTP GET-forespørgsel til det specificerede API endpoint.
        /// 4. GetFromJsonAsync metoden kaldes på _httpClient objektet, som sender GET-forespørgslen og deserialiserer JSON-responsen til en collection af BmiQueryResultDto objekter.
        /// 5. Metoden returnerer den deserialiserede samling af BmiQueryResultDto objekter.
        /// </summary>

        return await _httpClient.GetFromJsonAsync<IEnumerable<BmiQueryResultDto>>($"api/bmi/{userId}");
    }
}