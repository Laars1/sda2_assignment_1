using Sda.Ticketing.Abstractions;
using Sda.Ticketing.Models;
using System.Text;

namespace Sda.Ticketing.Services;

public class TaxHttpService : ITaxHttpService
{
    private const string BaseUri = "http://167.71.46.254:8080/function/taxcheckout";
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<TaxHttpService> _logger;

    public TaxHttpService(IHttpClientFactory httpClientFactory, ILogger<TaxHttpService> logger)
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

    public async Task<Tax?> GetTaxFromFaas(int year, float price)
    {
        _logger.LogInformation($"Executing HttpRequest from {nameof(TaxHttpService)}.{nameof(GetTaxFromFaas)}");
        using HttpClient client = await GetHttpClientAsync();

        HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, BaseUri);

        requestMessage.Content = new StringContent($"{{\"year\":\"{year}\",\"price\":{price}}}", Encoding.UTF8, "application/json");

        _logger.LogInformation($"Prepared request: {BaseUri} with content {await requestMessage.Content.ReadAsStringAsync()}");

        using HttpResponseMessage? response = await client.SendAsync(requestMessage);
        return await GetResponseResultAsync(response);
    }

    public async Task<Tax?> GetResponseResultAsync(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
            throw new HttpRequestException(
                $"The request on {response.Headers.Location} failed with status code {response.StatusCode}: {response.ReasonPhrase}");

        var x = await response.Content.ReadAsStringAsync();
        Tax? result = await response.Content.ReadFromJsonAsync<Tax>();

        _logger.LogInformation($"Result from HttpRequest. Taxes have been loaded from faas with result: {result?.total_price}");

        return result;
    }
}
