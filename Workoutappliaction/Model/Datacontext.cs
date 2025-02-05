using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Workoutappliaction.Model
{
    public class Datacontext : DbContext
    {
        public Datacontext(DbContextOptions<Datacontext> options) : base(options) 
        {

        }

        public DbSet<Exercise>? Exerciselist { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Exercise>().HasData(
                new Exercise
                {
                    Id = 1,
                    Title = "Käte kõverdused jala tõstega",
                    Description = "Tavalised kätekõverdused korda mööda jalga tõstes",
                    Intensity = Exercise.ExerciseIntensity.Normal,
                    RecommendedDurationInSeconds = 40,
                    RecommendedTimeInSecondsBeforeExercise = 10,
                    RecommendedTimeInSecondsAfterExercise = 10
                },
                new Exercise
                {
                    Id = 2,
                    Title = "Slaalomhüpped",
                    Description = "Kükist hüpped küljelt küljele",
                    Intensity = Exercise.ExerciseIntensity.High,
                    RecommendedDurationInSeconds = 40,
                    RecommendedTimeInSecondsBeforeExercise = 10,
                    RecommendedTimeInSecondsAfterExercise = 10,
                    RestTimeInstructions = "Venita reie esikülge"
                },
                new Exercise
                {
                    Id = 3,
                    Title = "Alt läbi jooks",
                    Description = "Toenglamangus jooksmine",
                    Intensity = Exercise.ExerciseIntensity.Normal,
                    RecommendedDurationInSeconds = 40,
                    RecommendedTimeInSecondsBeforeExercise = 10,
                    RecommendedTimeInSecondsAfterExercise = 10
                }
            ); 
        }
    }
}

    
   
