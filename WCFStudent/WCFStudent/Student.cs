using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFStudent
{
	[DataContract]
	public class Student 
	{
		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public string Navn { get; set; }
		[DataMember]
		public string Efternavn { get; set; }
		[DataMember]
		public int Alder { get; set; }

		public Student(int id, string navn, string efternavn, int alder)
		{
			this.Id = id;
			this.Navn = navn;
			this.Efternavn = efternavn;
			this.Alder = alder;
		}

		

		public override string ToString()
		{
			return $"Navn: {Navn}, Efternavn: {Efternavn}, Alder: {Alder}";
		}
	}
}