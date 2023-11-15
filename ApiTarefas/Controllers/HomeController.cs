using ApiTarefas.ModelViews;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiTarefas.controllers {
	[ApiController]
	[Route("api/[controller]")]
	public class HomeController : ControllerBase {
		//verb definition HTTP
		[HttpGet]
       public HomeView Index() {
			return new HomeView {
				Message = "Welcome to Tasks API",
				Docs = "/swagger"
			};
		}
	}
}
