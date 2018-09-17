using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using First_task.source.data;
using First_task.source.domain.use_cases;
using First_task.source.presentation;

namespace First_task.source{
	class FirstProjectRoot{
		public static void Main(string[] args){
			FetchStudent fetchStudent = new FetchStudent(new StudentRepository());
			FetchTeacher fetchTeacher = new FetchTeacher(new TeacherRepository());
			MainUi ui = new MainUi(fetchStudent, fetchTeacher);
			ui.Print();
		}
	}
}