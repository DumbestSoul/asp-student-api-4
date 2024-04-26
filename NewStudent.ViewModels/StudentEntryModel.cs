using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewStudent.ViewModels
{
	public class StudentEntryModel
	{
		public string StudentName { get; set; } = null!;

		public string? City { get; set; }

		public DateTime JoinDate { get; set; }

		public int Std { get; set; }
	}
}
