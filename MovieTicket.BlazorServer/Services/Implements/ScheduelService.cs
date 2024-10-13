using MovieTicket.Application.DataTransferObjs.Schedule.Request;
using MovieTicket.Application.DataTransferObjs.Schedule;
using MovieTicket.BlazorServer.Services.Interfaces;

namespace MovieTicket.BlazorServer.Services.Implements
{
    public class ScheduelService : IScheduelService
    {
        private readonly HttpClient _http;
        public ScheduelService(HttpClient http)
        {
            _http = http;
        }
        public async Task<bool> CreateAsync(CreateScheduleRequest createScheduleRequest)
        {
            var result = await _http.PostAsJsonAsync("api/Schedule/Create", createScheduleRequest);
            if (result == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _http.DeleteAsync($"api/Schedule/Delete?id={id}");
            if (result == null)
            {
                return false;
            }
            return true;
        }

        public async Task<IQueryable<ScheduleDto>> GetAllAsync()
        {
            var lst = await _http.GetFromJsonAsync<List<ScheduleDto>>("api/Schedule/GetAll");
            return lst.AsQueryable();
        }

        public async Task<IQueryable<FilmForCreateDto>> GetFilmAsync()
        {
            var lst = await _http.GetFromJsonAsync<List<FilmForCreateDto>>($"api/Schedule/GetFilmWithoutScheduel");
            return lst.AsQueryable();
        }

        public async Task<ScheduleDto> GetByIdAsync(Guid id)
        {
            var result = await _http.GetFromJsonAsync<ScheduleDto>($"api/Schedule/GetById?id={id}");
            return result;
        }

        public async Task<bool> UpdateAsync(UpdateScheduleRequest updateScheduleRequest)
        {
            var result = await _http.PutAsJsonAsync($"api/Schedule/Update", updateScheduleRequest);
            if (result == null)
            {
                return false;
            }
            return true;
        }
    }
}
