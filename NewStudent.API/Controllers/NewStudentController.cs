using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using NewStudent.Business.Contract;
using NewStudent.Entity.Models;
using NewStudent.ViewModels;

namespace NewStudent.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NewStudentController : ControllerBase
	{
		private readonly INewStudentBusiness _studentBusiness;
		public NewStudentController(INewStudentBusiness studentBusiness)
		{
			_studentBusiness = studentBusiness;
		}

		[HttpGet]
		public async Task<IActionResult> GetList()
		{
			var result = await _studentBusiness.GetList();
			if (!result.Any()) return BadRequest();

			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id)
		{
			var result = await _studentBusiness.GetById(id);
			if (result == null) return BadRequest();

			return Ok(result);
		}

		[HttpDelete]
		public async Task<IActionResult> Delete([FromHeader] Guid id)
		{
			await _studentBusiness.Delete(id);
			return Ok("Deleted");
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] StudentEntryModel student)
		{
			await _studentBusiness.Add(student);
			return CreatedAtAction("Add", student);
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromBody] Student student)
		{
			await _studentBusiness.Update(student);
			return Ok("Updated!");
		}
	}
}
