using ITB2203Application.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITB2203Application.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SpeakersController : ControllerBase
	{
		private readonly DataContext _context;

		public SpeakersController(DataContext context)
		{
			_context = context;
		}

	}
}
