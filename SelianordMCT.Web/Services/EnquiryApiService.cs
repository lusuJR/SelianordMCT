using System.Net.Http.Headers;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using SelianordMCT.Web.Models;

namespace SelianordMCT.Web.Services;

public class EnquiryApiService
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;

    public EnquiryApiService(HttpClient httpClient, ILocalStorageService localStorage)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
        _httpClient.Timeout = TimeSpan.FromSeconds(30);
    }

    private async Task AddAuthHeaderAsync()
    {
        var token = await _localStorage.GetItemAsync<string>("authToken");

        _httpClient.DefaultRequestHeaders.Authorization = null;

        if (!string.IsNullOrWhiteSpace(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }
    }

    public async Task<List<ContactEnquiry>> GetEnquiriesAsync()
    {
        await AddAuthHeaderAsync();

        var response = await _httpClient.GetAsync("api/enquiries");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<List<ContactEnquiry>>()
               ?? new List<ContactEnquiry>();
    }

    public async Task<bool> SubmitEnquiryAsync(ContactEnquiry enquiry)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/enquiries", enquiry);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Enquiry submission failed: {response.StatusCode} - {errorContent}");
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception while submitting enquiry: {ex.Message}");
        }
    }

    public async Task UpdateStatusAsync(int id, string status)
    {
        await AddAuthHeaderAsync();

        var response = await _httpClient.PutAsJsonAsync($"api/enquiries/{id}/status", status);
        response.EnsureSuccessStatusCode();
    }
}