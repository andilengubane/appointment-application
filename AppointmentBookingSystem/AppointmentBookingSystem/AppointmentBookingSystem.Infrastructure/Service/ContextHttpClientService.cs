using System.Net.Http.Json;
using AppointmentBookingSystem.Domain.Dto;
using AppointmentBookingSystem.Domain.Interface;

namespace AppointmentBookingSystem.Infrastructure.Service
{
    public class ContextHttpClientService(HttpClient httpClient) : IExternalRepository, IContextHttpClientService
    {
        const string _baseUrl = "api/ExternalVender";

        public async Task<ResponseDto> GetData()
        {
            var result = await httpClient.GetFromJsonAsync<ResponseDto>(_baseUrl);
            if (result is not null)
            {
                return result;
            }
            else
            {
                throw new HttpRequestException("Response content was null.");
            }
        }

        public async Task<ResponseDto> PostData(ResponseDto responseDto)
        {
            var response = await httpClient.PostAsJsonAsync(_baseUrl, responseDto);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ResponseDto>();
                if (result is not null)
                {
                    return result;
                }
                else
                {
                    throw new HttpRequestException("Response content was null.");
                }
            }
            else
            {
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}");
            }
        }
    }
}
