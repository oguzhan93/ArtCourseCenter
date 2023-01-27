using ArtCourseCenter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System.Globalization;
using System.Net.Http.Json;

namespace ArtCourseCenterMVC.Controllers
{

    public class HomeController : Controller
    {
        //Trainee
        public string BaseUrl = "https://localhost:44393/ArtCourseCenter/";

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TraineeOperations()
        {
            return View();
        }
        public async Task<IActionResult> GetAllTrainees()
        {

            List<ArtCourseCenter.Models.Trainee> _trainees = new List<ArtCourseCenter.Models.Trainee>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = await client.GetAsync("GetAllTrainees");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = responseMessage.Content.ReadAsStringAsync().Result;
                    _trainees = JsonConvert.DeserializeObject<List<Trainee>>(result);
                }
            }

            return View(_trainees);
        }

        [HttpGet]
        public async Task<IActionResult> GetSingleTrainee(int id)
        {
            Trainee _trainee = new Trainee();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = await client.GetAsync("GetSingleTrainee/" + id);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = responseMessage.Content.ReadAsStringAsync().Result;
                    _trainee = JsonConvert.DeserializeObject<Trainee>(result);
                }
            }

            return View(_trainee);
        }

        public IActionResult RegisterNewTrainee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterNewTrainee(Trainee _trainee)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = client.PostAsJsonAsync(BaseUrl + "AddNewTrainee", _trainee).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    ViewBag.msg = "The new Trainee has been registered successfully!";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.msg = "Something went wrong!";
                }

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTraineeAsync(int id)
        {
            Trainee _trainee = new Trainee();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = await client.GetAsync(BaseUrl + "GetSingleTrainee/" + id);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = responseMessage.Content.ReadAsStringAsync().Result;
                    _trainee = JsonConvert.DeserializeObject<Trainee>(result);
                }
            }
            return View(_trainee);
        }

        [HttpPost]
        public IActionResult UpdateTrainee(Trainee _trainee)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = client.PutAsJsonAsync(BaseUrl + "UpdateTrainee/", _trainee).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    ViewBag.msg = "The Trainee has been updated successfully!";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.msg = "Something went wrong!";
                }

            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> DeleteTraineeAsync(int id)
        {
            Trainee _trainee = new Trainee();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = await client.GetAsync(BaseUrl + "GetSingleTrainee/" + id);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = responseMessage.Content.ReadAsStringAsync().Result;
                    _trainee = JsonConvert.DeserializeObject<Trainee>(result);
                }

            }
            return View(_trainee);
        }


        public async Task<ActionResult> DeleteTrainee(int id)
        {
            string message = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                using (var responseMessage = await client.DeleteAsync(BaseUrl + "DeleteTrainee/" + id))
                {
                    message = await responseMessage.Content.ReadAsStringAsync();

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        ViewBag.msg = "The Trainee has been deleted successfully!";
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewBag.msg = "Something went wrong!";
                    }
                }
            }
            return View("Index");
        }

        // Instructor
        public async Task<IActionResult> GetAllInstructors()
        {
            List<ArtCourseCenter.Models.Instructor> _instructors = new List<ArtCourseCenter.Models.Instructor>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = await client.GetAsync("GetAllInstructors");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = responseMessage.Content.ReadAsStringAsync().Result;
                    _instructors= JsonConvert.DeserializeObject<List<Instructor>>(result);
                }
            }

            return View(_instructors);
        }

        [HttpGet]
        public async Task<IActionResult> GetSingleInstructor(int id)
        {
            Instructor _instructor = new Instructor();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = await client.GetAsync("GetSingleInstructor/" + id);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = responseMessage.Content.ReadAsStringAsync().Result;
                    _instructor = JsonConvert.DeserializeObject<Instructor>(result);
                }
            }

            return View(_instructor);
        }

        public IActionResult RegisterNewInstructor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterNewInstructor(Instructor _instructor)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = client.PostAsJsonAsync(BaseUrl + "AddNewInstructor", _instructor).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    ViewBag.msg = "The new Instructor has been registered successfully!";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.msg = "Something went wrong!";
                }

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateInstructorAsync(int id)
        {
            Instructor _instructor = new Instructor();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = await client.GetAsync(BaseUrl + "GetSingleInstructor/" + id);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = responseMessage.Content.ReadAsStringAsync().Result;
                    _instructor = JsonConvert.DeserializeObject<Instructor>(result);
                }
            }
            return View(_instructor);
        }

        [HttpPost]
        public IActionResult UpdateInstructor(Instructor _instructor)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = client.PutAsJsonAsync(BaseUrl + "UpdateInstructor/", _instructor).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    ViewBag.msg = "The Instructor has been updated successfully!";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.msg = "Something went wrong!";
                }

            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> DeleteInstructorAsync(int id)
        {
            Instructor _instructor = new Instructor();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = await client.GetAsync(BaseUrl + "GetSingleInstructor/" + id);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = responseMessage.Content.ReadAsStringAsync().Result;
                    _instructor = JsonConvert.DeserializeObject<Instructor>(result);
                }

            }
            return View(_instructor);
        }


        public async Task<ActionResult> DeleteInstructor(int id)
        {
            string message = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                using (var responseMessage = await client.DeleteAsync(BaseUrl + "DeleteInstructor/" + id))
                {
                    message = await responseMessage.Content.ReadAsStringAsync();

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        ViewBag.msg = "The Instructor has been deleted successfully!";
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewBag.msg = "Something went wrong!";
                    }
                }
            }
            return View("Index");
        }

        // Course
        public async Task<IActionResult> GetAllCourses()
        {
            List<ArtCourseCenter.Models.Course> _courses = new List<ArtCourseCenter.Models.Course>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = await client.GetAsync("GetAllCourses");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = responseMessage.Content.ReadAsStringAsync().Result;
                    _courses = JsonConvert.DeserializeObject<List<Course>>(result);
                }
            }

            return View(_courses);
        }

        [HttpGet]
        public async Task<IActionResult> GetSingleCourse(int id)
        {
            Course _course = new Course();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = await client.GetAsync("GetSingleCourse/" + id);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = responseMessage.Content.ReadAsStringAsync().Result;
                    _course = JsonConvert.DeserializeObject<Course>(result);
                }
            }

            return View(_course);
        }

        public IActionResult RegisterNewCourse()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterNewCourse(Course _course)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = client.PostAsJsonAsync(BaseUrl + "AddNewCourse", _course).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    ViewBag.msg = "The new Course has been registered successfully!";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.msg = "Something went wrong!";
                }

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCourseAsync(int id)
        {
            Course _course = new Course();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = await client.GetAsync(BaseUrl + "GetSingleCourse/" + id);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = responseMessage.Content.ReadAsStringAsync().Result;
                    _course = JsonConvert.DeserializeObject<Course>(result);
                }
            }
            return View(_course);
        }

        [HttpPost]
        public IActionResult UpdateCourse(Course _course)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = client.PutAsJsonAsync(BaseUrl + "UpdateCourse/", _course).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    ViewBag.msg = "The Course has been updated successfully!";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.msg = "Something went wrong!";
                }

            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> DeleteCourseAsync(int id)
        {
            Course _course = new Course();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = await client.GetAsync(BaseUrl + "GetSingleCourse/" + id);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = responseMessage.Content.ReadAsStringAsync().Result;
                    _course = JsonConvert.DeserializeObject<Course>(result);
                }

            }
            return View(_course);
        }


        public async Task<ActionResult> DeleteCourse(int id)
        {
            string message = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                using (var responseMessage = await client.DeleteAsync(BaseUrl + "DeleteCourse/" + id))
                {
                    message = await responseMessage.Content.ReadAsStringAsync();

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        ViewBag.msg = "The Course has been deleted successfully!";
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewBag.msg = "Something went wrong!";
                    }
                }
            }
            return View("Index");
        }


    }

}
