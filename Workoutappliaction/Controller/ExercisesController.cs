using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Workoutappliaction.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExercisesController : ControllerBase
    {
        private readonly DataContext _context;

        public ExercisesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionresult GetExercises()
        {
            return Ok(_context.ExerciseList());
        }

        [HttpGet("{id}")]
        public IActionresult GetDetails(int? id)
        {
            var exercise = _context.ExerciseList?.FirstOrDefault(e => e.Id == id);
            if (exercise == null)
            {
                return NotFound();
            }
            return Ok(exercise);
        }

        [HttpPost]
        public Iactionresult Create([Frombody] Exercise exercise)
        {
           var dbExercise = _context.ExerciseList?.Find(exercise.Id);
           if (dbExercise != null)
           {
               _context.add(exercise);
               _context.SaveChanges();

               return CreatedAtAction(nameof(GetDetails), new {id = exercise.Id}, exercise);
           }
           else 
           {
               return Conflict();
           }
        }

        [HttpPut("{id}")]
        public IActionresult update(int? id, [Frombody] Exercise exercise)
        {
            if (id != exercise.Id || !_context.ExerciseList.Any(e => e.Id == id))
            {
                return NotFound();
            }
            _context.Update(exercise);
            _context.SaveChanges();

            return NoContent();
        }

    }
}