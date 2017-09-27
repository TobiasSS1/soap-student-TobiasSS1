using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace WCFStudenterConsumer
{
	class Program
	{ 
		/// <summary>
		/// ok
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			using (var Client = new StudenterReferance.Service1Client())
			{
				Console.WriteLine("Kommandoer:");
				Console.WriteLine("###################################################");
				Console.WriteLine("/add");
				Console.WriteLine("/remove");
				Console.WriteLine("/find");
				Console.WriteLine("/edit");
				Console.WriteLine("/findall <- Virker ikke");
				Console.WriteLine("###################################################");
				Console.WriteLine(" ");

				while (true)
				{
				string UserInput = Console.ReadLine();


					//Find All
					if (UserInput.ToLower() == "/findall")
					{
						foreach (var Student in Client.GetAllStudent())
						{


							Console.WriteLine(" ");
							Console.WriteLine("id        : " + Student.Id);
							Console.WriteLine("navn      : " + Student.Navn);
							Console.WriteLine("efternavn : " + Student.Efternavn);
							Console.WriteLine("alder     : " + Student.Alder);
							Console.WriteLine(" ");

						}
					}

						//Find
						if (UserInput.ToLower() == "/find")
				{
					Console.WriteLine("id:");
					int id = Convert.ToInt32(Console.ReadLine());
					string navn = Client.FindStudent(id).Navn;
					string enavn = Client.FindStudent(id).Efternavn;
					int alder = Client.FindStudent(id).Alder;

					Console.WriteLine(" ");
					Console.WriteLine("navn      : " + navn);
					Console.WriteLine("efternavn : " + enavn);
					Console.WriteLine("alder     : " + alder);
					Console.WriteLine(" ");
				}

					//Remove
					if (UserInput.ToLower() == "/remove")
					{
					Console.WriteLine("id:");
					int id = Convert.ToInt32(Console.ReadLine());
					string navn = Client.FindStudent(id).Navn;
					Client.RemoveStudent(id);
					Console.WriteLine(" ");
					Console.WriteLine("Removed: " + navn );
					Console.WriteLine(" ");
					}

					//Add
					if (UserInput.ToLower() == "/add")
				{
					Console.WriteLine("id:");

					int id = Convert.ToInt32(Console.ReadLine());

					if (Client.FindStudent(id) != null)
					{
						throw new ArgumentException("Eleven med id'en " + id + " eksistere jo allerede, brug /edit hvis du vil skrive eleven om" );
					}

					Console.WriteLine(" ");
					Console.WriteLine("navn:");
					string Navn = Console.ReadLine();

					Console.WriteLine(" ");
					Console.WriteLine("efternavn:");
					string ENavn = Console.ReadLine();
		
					Console.WriteLine(" ");
					Console.WriteLine("alder:");
					int Alder = Convert.ToInt32(Console.ReadLine());

						Console.WriteLine(" ");
					Console.WriteLine("Ny elev: ");
					Console.WriteLine("navn      : " + Navn);
					Console.WriteLine("efternavn : " + ENavn);
					Console.WriteLine("alder     : " + Alder);
						Console.WriteLine(" ");

						Client.Addstudent(id, Navn, ENavn, Alder);
				}

					//Edit
					if (UserInput.ToLower() == "/edit")
					{
						Console.WriteLine("id:");

						int id = Convert.ToInt32(Console.ReadLine());

						if (Client.FindStudent(id) == null)
						{
							throw new ArgumentException("der er ingen elever med id'en " + id + ". Brug /add hvis du vil tilføje en elev i stedet");
						}

						string navn = Client.FindStudent(id).Navn;
						string enavn = Client.FindStudent(id).Efternavn;
						int alder = Client.FindStudent(id).Alder;
						//Vis gamle
						Console.WriteLine(" ");
						Console.WriteLine("gammel elev: ");
						Console.WriteLine(" ");
						Console.WriteLine("navn      : " + navn);
						Console.WriteLine("efternavn : " + enavn);
						Console.WriteLine("alder     : " + alder);
						Console.WriteLine(" ");

						//Slet gamle
						Client.RemoveStudent(id);

						//Opret ny
						Console.WriteLine("ny elev:");
						Console.WriteLine(" ");
						Console.WriteLine("navn:");
						string Navn = Console.ReadLine();

						Console.WriteLine(" ");
						Console.WriteLine("efternavn:");
						string ENavn = Console.ReadLine();

						Console.WriteLine(" ");
						Console.WriteLine("alder:");
						int Alder = Convert.ToInt32(Console.ReadLine());

						//Resultat
						Console.WriteLine(" ");
						Console.WriteLine("Elev rettet: ");
						Console.WriteLine("navn      : " + Navn);
						Console.WriteLine("efternavn : " + ENavn);
						Console.WriteLine("alder     : " + Alder);
						Console.WriteLine(" ");

						Client.Addstudent(id, Navn, ENavn, Alder);
					}
				}
			}
		}
	}
}
