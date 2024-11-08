using Sda2.Masterdata.Abstractions;
using System.Net;

namespace Sda2.Masterdata.Services;

public class TicketingHttpService : ITicketingHttpService
{
    private const string BaseUri = "https://localhost:5003/ticketing";
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<TicketingHttpService> _logger;

    public TicketingHttpService(IHttpClientFactory httpClientFactory, ILogger<TicketingHttpService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    private Task<HttpClient> GetHttpClientAsync()
    {
        var client = _httpClientFactory.CreateClient();
        client.Timeout = TimeSpan.FromSeconds(10);
        return Task.FromResult(client);
    }

    public async Task<bool> DeleteTicketsAsync(int customerId)
    {
        _logger.LogInformation($"Executing HttpRequest from {nameof(TicketingHttpService)}.{nameof(DeleteTicketsAsync)}");
        using HttpClient client = await GetHttpClientAsync();
        string request = $"{BaseUri}/TicketSystem/deletebycustomerid/{customerId}";
        _logger.LogInformation($"Prepared request: {request}");
        using HttpResponseMessage? response = await client.DeleteAsync(request);
        return GetResponseResultAsync(response);
    }

    public bool GetResponseResultAsync(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
            throw new HttpRequestException(
                $"The request on {response.Headers.Location} failed with status code {response.StatusCode}: {response.ReasonPhrase}");

        bool success = response.StatusCode == HttpStatusCode.NoContent ? true : false;
        _logger.LogInformation($"Result from HttpRequest. TicketSystems and its items have been deleted:{success}");

        return success;
    }
}
