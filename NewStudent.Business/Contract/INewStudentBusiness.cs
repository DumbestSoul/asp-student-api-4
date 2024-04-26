using NewStudent.Entity.Models;
using NewStudent.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewStudent.Business.Contract
{
	public interface INewStudentBusiness
	{
		//CREATE
		Task Add(StudentEntryModel student);
		//READ
		Task<List<Student>> GetList();
		Task<StudentEntryModel> GetById(Guid id);
		//UPDATE
		Task Update(Student student);
		//DELETE
		Task Delete(Guid id);
	}
}
