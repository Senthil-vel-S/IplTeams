using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using World.Web.Dto;

namespace World.Web.Pages
{
    public class iplteamsModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public iplteamsModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public List<teamDto> Teams { get; set; }
        public async void OnGet()
        {
            var httpClient = _httpClientFactory.CreateClient("WorldWebAPI");
            Teams = await httpClient.GetFromJsonAsync<List<teamDto>>("api/Teams"); 
        }
    }
}
