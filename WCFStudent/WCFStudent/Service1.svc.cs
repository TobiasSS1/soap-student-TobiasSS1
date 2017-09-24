using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFStudent
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
	public class Service1 : IService1
	{

		static readonly List<Student> Studenterliste = new List<Student>();
		public string Addstudent(int id, string navn, string efternavn, int alder)
		{
			var student = new Student(id, navn, efternavn, alder);
			Studenterliste.Add(student);
			return student.ToString();
		}


		public Student FindStudent(int ID)
		{
			var selected = Studenterliste.FirstOrDefault(x => x.Id == ID);

			return selected;
		}

		public void RemoveStudent(int id)
		{
			var selected = Studenterliste.FirstOrDefault(x => x.Id == id);
			Studenterliste.Remove(selected);
		}

		public string EditStudent(int id, string navn, string efternavn, int alder)
		{
			var selected = Studenterliste.FirstOrDefault(x => x.Id == id);
			Studenterliste.Remove(selected);
			var student = new Student(id, navn, efternavn, alder);
			Studenterliste.Add(student);
			return student.ToString();

		}

	//Returnere kun 1 elev...
		public List<Student> GetAllStudent()
		{
			return Studenterliste;
		}

		public string GetData(int value)
		{
			return string.Format("You entered: {0}", value);
		}

		public CompositeType GetDataUsingDataContract(CompositeType composite)
		{
			if (composite == null)
			{
				throw new ArgumentNullException("composite");
			}
			if (composite.BoolValue)
			{
				composite.StringValue += "Suffix";
			}
			return composite;
		}
	}
}
