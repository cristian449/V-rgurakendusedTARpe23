using ITB2203Application.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITB2203Application.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AttendeesController : ControllerBase
	{
		private readonly DataContext _context;

		public AttendeesController(DataContext context)
		{
			_context = context;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Attendee>> GetSpeaker(string? name = null)
		{
			var query = _context.Attendees!.AsQueryable();

			if (name != null)
				query = query.Where(x => x.Name != null && x.Name.ToUpper().Contains(name.ToUpper()));

			return Ok(query);
		}

		[HttpGet("{id}")]
		public ActionResult<Attendee> GetAttendee(int id)
		{
			var attendee = _context.Attendees!.Find(id);

			if (attendee == null)
			{
				return NotFound();
			}

			return Ok(attendee);
		}

		[HttpPut("{Id}")]
		public IActionResult PutAttendee(int Id, Attendee attendee)
		{
			if (!attendee.Email.Contains("@"))
			{
				return BadRequest("400 Bad request");
			}

			var dbAttendee = _context.Attendees!.AsNoTracking().FirstOrDefault(x => x.Id == attendee.Id);
			if (Id != attendee.Id || dbAttendee == null)
			{
				return NotFound();
			}

			_context.Update(attendee);
			_context.SaveChanges();

			return NoContent();
		}

		[HttpPost]
		public ActionResult<Attendee> PostAttendee(Attendee attendee)
		{
			if (!attendee.Email.Contains("@"))
			{
				return BadRequest("400 Bad Request.");
			}

			_context.Add(attendee);
			_context.SaveChanges();

			return CreatedAtAction(nameof(GetSpeaker), new { Id = attendee.Id }, attendee);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteAttendee(int id)
		{
			var attendee = _context.Attendees!.Find(id);
			if (attendee == null)
			{
				return NotFound();
			}

			_context.Remove(attendee);
			_context.SaveChanges();

			return NoContent();
		}
	}
}
