using Microsoft.EntityFrameworkCore;
using StudentMS.Data.EF;
using StudentMS.Data.Entities;
using StudentMS.ViewModel.Catalog.Students;
using StudentMS.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMS.Application.Catalog.Students
{
    public class ManageStudentService : IManageStudentService
    {
        private readonly StudentMSDbContext _context;
        public ManageStudentService(StudentMSDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(StudentRequest request)
        {
            var student = new Student()
            {
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                Sex = request.Sex,
                Dob = request.Dob,
                Address = request.Address
            };
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student.Id;
        }

        public async Task<PageResultBase<StudentVM>> GetAllPaging(PagingRequestBase request)
        {
            var result = new List<StudentVM>();
            var query = _context.Students.AsQueryable();
            if (!string.IsNullOrEmpty(request.KeyWord))
            {
                query = query.Where(x => x.Name.Contains(request.KeyWord));
            }

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                                    .Take(request.PageSize)
                                    .Select(x => new StudentVM(x))
                                    .ToListAsync();
            foreach (var student in data)
            {
                student.Average = CalculateStudentAverage(student.Id);
            }
            return new PageResultBase<StudentVM>()
            {
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecord = query.Count()
            };
        }
        private float CalculateStudentAverage(int studentId)
        {
            // mac dinh so mon hoc = 3
            var totalScore = _context.Grades.Where(x => x.StudentId == studentId).Sum(x => x.Score);
            return (float)Math.Round(totalScore / 3, 2);
        }

        public async Task<int> Update(int studentId, StudentRequest request)
        {
            var student = await _context.Students.FindAsync(studentId);
            if(student == null)
            {
                return 0;
            }
            student.Name = request.Name;
            student.Sex = request.Sex;
            student.PhoneNumber = request.PhoneNumber;
            student.Address = request.Address;
            student.Dob = request.Dob;
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(int studentId)
        {
            var student = await _context.Students.FindAsync(studentId);
            if (student == null)
            {
                return 0;
            }
            _context.Students.Remove(student);
            return await _context.SaveChangesAsync();
        }

        public async Task<StudentVM> GetById(int studentId)
        {
            var student = await _context.Students.FindAsync(studentId);
            if( student == null)
            {
                return null;
            }
            var studentVM = new StudentVM(student);
            return studentVM;
        }
    }
}
