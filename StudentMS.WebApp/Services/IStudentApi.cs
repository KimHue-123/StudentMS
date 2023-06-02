using StudentMS.ViewModel.Catalog.Students;
using StudentMS.ViewModel.Common;
using System.Threading.Tasks;

namespace StudentMS.WebApp.Services
{
    public interface IStudentApi
    {
        Task<PageResultBase<StudentVM>> GetStudentPaging(PagingRequestBase request);
        Task<int> CreateStudent(StudentRequest request);
        Task<int> EditStudent(int studentId, StudentRequest request);
        Task<int> DeleteStudent(int studentId);
        Task<StudentVM> GetStudentById(int studentId);
    }
}
