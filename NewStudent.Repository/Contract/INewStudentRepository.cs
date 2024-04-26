using NewStudent.Entity.Models;
using NewStudent.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewStudent.Repository.Contract
{
	public interface INewStudentRepository
	{
		//READ 
		//GET LIST
		Task<List<Student>> GetList();
		//GET STUDENT BY ID
		Task<Student> GetById(Guid id);

		//CREATE
		Task Add(StudentEntryModel student);
		//UPDATE
		Task Update(Student student);
		//DELETE
		Task Delete(Guid id);
	}
}
