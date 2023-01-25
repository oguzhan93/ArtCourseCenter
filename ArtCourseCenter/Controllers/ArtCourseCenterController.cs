using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using ArtCourseCenter.Models;

namespace ArtCourseCenter.Controllers
{
    //You can put "api" at the beginning of the Route address
    [Route("/[controller]/[action]")]
    [ApiController]
    public class ArtCourseCenterController : ControllerBase
    {

        private readonly Context _context;
        
        public ArtCourseCenterController(Context context)
        {
            _context = context;
        }


        //Trainee CRUD Operations

        //Prints all of the trainees.
        [HttpGet]
        public async Task<IActionResult> GetAllTrainees()
        {
            return Ok(await _context.Trainees.ToListAsync());
        }

        //Prints the trainee that has the given "Id".
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{Id:int}", Name = "GetSingleTrainee")]
        public async Task<ActionResult<Trainee>> GetSingleTrainee(int Id)
        {
            if (Id < 0)
                return BadRequest();

            var TempTrainee = await _context.Trainees.FindAsync(Id);

            if (TempTrainee == null)
                return NotFound("The Trainee does not exist!");

            return Ok(TempTrainee);
        }



        //Appends new trainee into the system.
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<List<Trainee>>> AddNewTrainee(Trainee Trainee)
        {
            _context.Trainees.Add(Trainee);
            await _context.SaveChangesAsync();
            return Ok(await _context.Trainees.ToListAsync());
        }


        //Updates every attribute of the given "Trainee".
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut(Name = "UpdateTrainee")]
        public async Task<ActionResult<List<Trainee>>> UpdateTrainee(Trainee Trainee)
        {
            if (Trainee == null)
                return BadRequest();

            var TempTrainee = await _context.Trainees.FindAsync(Trainee.Id);

            if (TempTrainee == null)
                return NotFound("The Trainee does not exist!");

            TempTrainee.RegisterDate = Trainee.RegisterDate;
            TempTrainee.Age = Trainee.Age;
            TempTrainee.Name = Trainee.Name;
            TempTrainee.HasPaidTheFee = Trainee.HasPaidTheFee;
            TempTrainee.TRIdentityNumber = Trainee.TRIdentityNumber;

            await _context.SaveChangesAsync();

            return Ok(await _context.Trainees.ToListAsync());
        }


        //Removes the traine that has the given "Id".
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{Id:int}", Name = "DeleteTrainee")]
        public async Task<ActionResult<List<Trainee>>> DeleteTrainee(int Id)
        {
            if (Id < 0)
                return BadRequest();

            var TempTrainee = await _context.Trainees.FindAsync(Id);

            if (TempTrainee == null)
                return NotFound("The Trainee does not exist!");

            _context.Trainees.Remove(TempTrainee);
            await _context.SaveChangesAsync();
            return Ok(await _context.Trainees.ToListAsync());
        }




        //Instructor CRUD Operations

        //Prints all of the Instructors.
        [HttpGet]
        public async Task<IActionResult> GetAllInstructors()
        {

            return Ok(await _context.Instructors.ToListAsync());
        }


        //Prints the Instructor that has the given "Id".
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{Id:int}", Name = "GetSingleInstructor")]
        public async Task<ActionResult<Instructor>> GetSingleInstructor(int Id)
        {
            if (Id < 0)
                return BadRequest();

            var TempInstructor = await _context.Instructors.FindAsync(Id);

            if (TempInstructor == null)
                return NotFound("The Instructor does not exist!");

            return Ok(TempInstructor);
        }

        //Appends new Instructor into the system.
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<List<Instructor>>> AddNewInstructor(Instructor Instructor)
        {
            _context.Instructors.Add(Instructor);
            await _context.SaveChangesAsync();
            return Ok(await _context.Instructors.ToListAsync());
        }


        //Updates every attribute of the given "Instructor".
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut(Name = "UpdateInstructor")]
        public async Task<ActionResult<List<Instructor>>> UpdateInstructor(Instructor Instructor)
        {
            if (Instructor == null)
                return BadRequest();

            var TempInstructor = await _context.Instructors.FindAsync(Instructor.Id);

            if (TempInstructor == null)
                return NotFound("The Instructor does not exist!");

            TempInstructor.Salary = Instructor.Salary;
            TempInstructor.CourseName = Instructor.CourseName;
            TempInstructor.Name = Instructor.Name;
            TempInstructor.TRIdentityNumber = Instructor.TRIdentityNumber;

            await _context.SaveChangesAsync();

            return Ok(await _context.Instructors.ToListAsync());
        }


        //Removes the Instructor that has the given "Id".
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{Id:int}", Name = "DeleteInstructor")]
        public async Task<ActionResult<List<Instructor>>> DeleteInstructor(int Id)
        {
            if (Id < 0)
                return BadRequest();

            var TempInstructor = await _context.Instructors.FindAsync(Id);

            if (TempInstructor == null)
                return NotFound("The Instructor does not exist");

            _context.Instructors.Remove(TempInstructor);
            await _context.SaveChangesAsync();
            return Ok(await _context.Instructors.ToListAsync());
        }





        //Course CRUD Operations

        //Prints all of the Courses.
        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        { 
            return Ok(await _context.Courses.ToListAsync());
        }



        //Prints the Course that has the given "Id".
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{Id:int}", Name = "GetSingleCourse")]
        public async Task<ActionResult<Course>> GetSingleCourse(int Id)
        {
            if (Id < 0)
                return BadRequest();

            var TempCourse = await _context. Courses.FindAsync(Id);

            if (TempCourse == null)
                return NotFound("The Course does not exist!");

            return Ok(TempCourse);
        }

        //Appends new Course into the system.
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<List<Course>>> AddNewCourse(Course Course)
        {
            _context.Courses.Add(Course);
            await _context.SaveChangesAsync();
            return Ok(await _context.Courses.ToListAsync());
        }


        //Updates every attribute of the given "Course".
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut(Name = "UpdateCourse")]
        public async Task<ActionResult<List<Course>>> UpdateCourse(Course Course)
        {
            if (Course == null)
                return BadRequest();

            var TempCourse = await _context.Courses.FindAsync(Course.Id);

            if (TempCourse == null) 
                return NotFound("The Course does not exist!");

            TempCourse.Name = Course.Name;
            TempCourse.Quota = Course.Quota;
            TempCourse.Fee = Course.Fee;
            TempCourse.IsAvailable = Course.IsAvailable;

            await _context.SaveChangesAsync();

            return Ok(await _context.Courses.ToListAsync());
        }


        //Removes the Course that has the given "Id".
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{Id:int}", Name = "DeleteCourse")]
        public async Task<ActionResult<List<Course>>> DeleteCourse(int Id)
        {
            if (Id < 0)
                return BadRequest();

            var TempCourse = await _context.Courses.FindAsync(Id);

            if (TempCourse == null)
                return NotFound("The Course does not exist!");

            _context.Courses.Remove(TempCourse);
            await _context.SaveChangesAsync();
            return Ok(await _context.Courses.ToListAsync());
        }

        //CoursesAndTrainees CRUD Operations

        //Prints all of the CoursesAndTrainees
        [HttpGet]
        public async Task<IActionResult> GetAllCoursesAndTrainees()
        {
            return Ok(await _context.CoursesAndTrainees.ToListAsync());
        }



        //Prints the CoursesAndTrainees that has the given "Id".
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{Id:int}", Name = "GetSingleCoursesAndTrainees")]
        public async Task<ActionResult<Course>> GetSingleCoursesAndTrainees(int Id)
        {
            if (Id < 0)
                return BadRequest();

            var TempCoursesAndTrainees = await _context.CoursesAndTrainees.FindAsync(Id);

            if (TempCoursesAndTrainees == null)
                return NotFound("The CoursesAndTrainees does not exist!");

            return Ok(TempCoursesAndTrainees);
        }

        //Appends new CoursesAndTrainees into the system.
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<List<CoursesAndTrainees>>> AddNewCoursesAndTrainees(CoursesAndTrainees CoursesAndTrainees)
        {
            _context.CoursesAndTrainees.Add(CoursesAndTrainees);
            await _context.SaveChangesAsync();
            return Ok(await _context.CoursesAndTrainees.ToListAsync());
        }


        //Updates every attribute of the given "CoursesAndTrainees".
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut(Name = "UpdateCoursesAndTrainees")]
        public async Task<ActionResult<List<CoursesAndTrainees>>> UpdateCoursesAndTrainees(CoursesAndTrainees CoursesAndTrainees)
        {
            if (CoursesAndTrainees == null)
                return BadRequest();

            var TempCoursesAndTrainees = await _context.CoursesAndTrainees.FindAsync(CoursesAndTrainees.Id);

            if (TempCoursesAndTrainees == null)
                return NotFound("The Course does not exist!");

            TempCoursesAndTrainees.TraineId = CoursesAndTrainees.TraineId;
            TempCoursesAndTrainees.CourseId = CoursesAndTrainees.CourseId;
           

            await _context.SaveChangesAsync();

            return Ok(await _context.CoursesAndTrainees.ToListAsync());
        }


        //Removes the CoursesAndTrainees that has the given "Id".
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{Id:int}", Name = "DeleteCoursesAndTrainees")]
        public async Task<ActionResult<List<CoursesAndTrainees>>> DeleteCoursesAndTrainees(int Id)
        {
            if (Id < 0)
                return BadRequest();

            var TempCoursesAndTrainees = await _context.CoursesAndTrainees.FindAsync(Id);

            if (TempCoursesAndTrainees == null)
                return NotFound("The CoursesAndTrainees does not exist!");

            _context.CoursesAndTrainees.Remove(TempCoursesAndTrainees);
            await _context.SaveChangesAsync();
            return Ok(await _context.CoursesAndTrainees.ToListAsync());
        }

    }
}


