using NewStudent.Business.Contract;
using NewStudent.Entity.Models;
using NewStudent.Repository.Contract;
using NewStudent.ViewModels;

namespace NewStudent.Business.Business
{
	public class NewStudentBusiness : INewStudentBusiness
	{
		private readonly INewStudentRepository _studentRepository;
		public NewStudentBusiness(INewStudentRepository studentRepository)
		{
			_studentRepository = studentRepository;
		}
		public async Task Add(StudentEntryModel student)
		{
			await _studentRepository.Add(student);
		}

		public async Task Delete(Guid id)
		{
			await _studentRepository.Delete(id);
			return;
		}

		public async Task<StudentEntryModel> GetById(Guid id)
		{
			Student student = new();
			student = await _studentRepository.GetById(id);
			if (student == null) return null;

			StudentEntryModel std = new();
			
			//MAPPING
			std.StudentName = student.StudentName;
			std.City = student.City;
			std.JoinDate = student.JoinDate;
			std.Std = student.Std;
			
			return std;
		}

		public async Task<List<Student>> GetList()
		{
			List<Student> student = new();

			student = await _studentRepository.GetList();
			return student;
		}

		public async Task Update(Student student)
		{
			await _studentRepository.Update(student);
		}
	}
}
