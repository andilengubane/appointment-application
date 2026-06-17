using AppointmentBookingSystem.Domain.Dto;

namespace AppointmentBookingSystem.Domain.Interface
{
    public interface IContextHttpClientService
    {
        Task<ResponseDto> GetData();
        Task<ResponseDto> PostData(ResponseDto response);
    }
}
