using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentMS.Application.Catalog.Students;
using StudentMS.ViewModel.Catalog.Students;
using StudentMS.ViewModel.Common;
using System.Threading.Tasks;

namespace StudentMS.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IManageStudentService _studentService;
        public StudentController(IManageStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public async Task<IActionResult> Filter([FromQuery]PagingRequestBase request)
        {
            var result = await _studentService.GetAllPaging(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudentRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _studentService.Create(request);
            if(result > 0)
            {
                return Ok(result);
            }
            return BadRequest();

        }
        [HttpPut("{studentId}/Edit")]
        public async Task<IActionResult> Update(int studentId, [FromBody]StudentRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _studentService.Update(studentId, request);
            if( result > 0)
            {
                return Ok(result);
            }
            ModelState.AddModelError("", $"Student with id {studentId} does not exist!");
            return BadRequest();
        }
        [HttpDelete("{studentId}/Delete")]
        public async Task<IActionResult> Delete(int studentId)
        {
            var result = await _studentService.Delete(studentId);
            if (result > 0)
            {
                return Ok(result);
            }
            ModelState.AddModelError("", $"Student with id {studentId} does not exist!");
            return BadRequest();
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetById(int studentId)
        {
            var result = await _studentService.GetById(studentId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
