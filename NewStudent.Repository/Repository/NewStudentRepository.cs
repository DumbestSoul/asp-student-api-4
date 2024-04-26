using Microsoft.EntityFrameworkCore;
using NewStudent.Entity.Models;
using NewStudent.Repository.Contract;
using NewStudent.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewStudent.Repository.Repository
{
	public class NewStudentRepository : INewStudentRepository
	{
		private readonly NewStudentContext _dbContext;
		public NewStudentRepository(NewStudentContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task Add(StudentEntryModel student)
		{
			Student std = new();

			std.StudentName = student.StudentName;
			std.City = student.City;
			std.JoinDate = student.JoinDate;
			std.Std = student.Std;

			await _dbContext.Students.AddAsync(std);
			await _dbContext.SaveChangesAsync();
		}

		public async Task Delete(Guid id)
		{
			try
			{
				var result = await _dbContext.Students.FirstAsync(p => p.Id == id);
				_dbContext.Students.Remove(result);
				await _dbContext.SaveChangesAsync();
			}
			catch(Exception e)
			{
				return;
			}
		}

		public async Task<Student> GetById(Guid id)
		{

			Student std = new();
			var res = await _dbContext.Students.FirstAsync(p => p.Id == id);
			if (res == null) return std;
			return res;

		}

		public async Task<List<Student>> GetList()
		{
			List<Student> student = new();
			try
			{
				student = await _dbContext.Students.ToListAsync();
				return student;
			}
			catch(Exception e)
			{
				return student;
			}
		}

		public async Task Update(Student student)
		{
			Student std = new();
			try
			{
				std = await _dbContext.Students.FirstAsync(p => p.Id == student.Id);
				std.StudentName = student.StudentName;
				std.City = student.City;
				std.JoinDate = student.JoinDate;
				std.Std = student.Std;

				_dbContext.Update(std);
				await _dbContext.SaveChangesAsync();
			}catch(Exception ex)
			{
				return;
			}
		}
	}
}
