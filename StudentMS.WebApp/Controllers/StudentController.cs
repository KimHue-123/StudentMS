using Microsoft.AspNetCore.Mvc;
using StudentMS.ViewModel.Catalog.Students;
using StudentMS.ViewModel.Common;
using StudentMS.WebApp.Services;
using System.Threading.Tasks;

namespace StudentMS.WebApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentApi _studentApi;
        public StudentController(IStudentApi studentApi)
        {
            _studentApi = studentApi;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string keyWord, int pageIndex = 1, int pageSize =2)
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
                var b = TempData["result"];
            }
            ViewBag.KeyWord = keyWord;
            var request = new PagingRequestBase(pageIndex, pageSize, keyWord);
            var result = await _studentApi.GetStudentPaging(request);
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentRequest request)
        {
            var result = await _studentApi.CreateStudent(request);
            if(result > 0)
            {
                TempData["result"] = "Student is created successully!";
                return RedirectToAction("Index");
            }
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int studentId)
        {
            var result = await _studentApi.GetStudentById(studentId);
            if(result != null)
            {
                return View(result);
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int studentId, StudentRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _studentApi.EditStudent(studentId, request);
            if (result > 0)
            {
                TempData["result"] = "Student is updated successully!";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int studentId)
        {
            var result = await _studentApi.DeleteStudent(studentId);
            if(result > 0)
            {
                TempData["result"] = "Student is deleted successully!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
    }
}
