using StudentMS.ViewModel.Catalog.Students;
using StudentMS.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentMS.Application.Catalog.Students
{
    public interface IManageStudentService
    {
        Task<PageResultBase<StudentVM>> GetAllPaging(PagingRequestBase request);
        Task<int> Create(StudentRequest request);
        Task<int> Update(int studentId, StudentRequest request);
        Task<int> Delete(int studentId);
        Task<StudentVM> GetById(int studentId);
    }
}
