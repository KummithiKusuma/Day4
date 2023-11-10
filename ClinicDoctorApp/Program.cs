using DoctorModelLibrary;
using DoctorBLLibrary;
using DoctorDALLibrary;
using System.Numerics;

namespace ClinicApp
{
    internal class Program
    {
        IDoctorService doctorService;
        public Program()
        {
            doctorService = new DoctorService();
        }
        void DisplayAdminMenu()
        {
            Console.WriteLine("1. Add Doctor");
            Console.WriteLine("2. Modify Doctor phonenumber ");
            Console.WriteLine("3. modify Doctor experience ");
            Console.WriteLine("4. Delete Doctor");
            Console.WriteLine("5. Print All Details");
            Console.WriteLine("0. Exit");
        }
        void StartAdminActivities()
        {
            int choice;
            do
            {
                DisplayAdminMenu();
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye bye");
                        break;
                    case 1:
                        AddDoctor();
                        break;
                    case 2:
                        Modifyphonenumber();
                        break;
                    case 3:
                        Modifyexperience();
                        break;
                    case 4:
                        DeleteDoctor();
                        break;
                    case 5:
                        PrintAllDetails();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }
        private void PrintAllDetails()
        {
            Console.WriteLine("***********************************");
            var details = doctorService.GetDetails();
            foreach (var item in details)
            {
                Console.WriteLine(item);
                Console.WriteLine("-------------------------------");
            }
            Console.WriteLine("***********************************");
        }
        void AddDetails()
        {
            try
            {
               Doctor doctor = TakeDoctorDetails();
                var result = DoctorService.AddDoctor(doctor);
                if (result != null)
                {
                    Console.WriteLine("Doctor added");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);

            }
            catch (NotAddedException e)
            {
                Console.WriteLine(e.Message);
            }

        }
        Doctor TakeDoctorDetails()
        {
            Doctor octort = new Doctor();
            Console.WriteLine("Please enter the doctor name");
            doctor.Name = Console.ReadLine();
            Console.WriteLine("Please enter the doctor phone number");
            doctor.Price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the doctor qualification");
            doctor.Qualification = Console.ReadLine();
            Console.WriteLine("Please enter the doctor experience");
            doctor.Experience = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the doctor Fees");
            doctor.Discount = Convert.ToInt32(Console.ReadLine());
            return doctor;
        }
        int GetDoctorIdFromUser()
        {
            int id;
            Console.WriteLine("Please enter the doctor id");
            id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
        private void DeleteDoctor()
        {
            try
            {
                int id = GetDoctorIdFromUser();
                if (doctorService.Delete(id) != null)
                    Console.WriteLine("doctor deleted");
            }
            catch (NoSuchProductException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void Modifyphonenumber()
        {
            var id = GetDoctorIdFromUser();
            Console.WriteLine("Please enter the new phonenumber");
            float phone = Convert.ToSingle(Console.ReadLine());
            doctor = new Doctor();
            doctor.PhoneNumber = phonenumber;
            doctor.Id = id;
            try
            {
                var result = DoctorService.ModifyPhoneNumber(id, phonenumber);
                if (result != null)
                    Console.WriteLine("Update success");
            }
            catch (NoSuchDoctorException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void Modifyexperience()
        {
            var id = GetDoctorIdFromUser();
            Console.WriteLine("Please enter the new experience");
            float phone = Convert.ToSingle(Console.ReadLine());
            doctor = new Doctor();
            doctor.Experience = experience;
            Doctor.Id = id;
            try
            {
                var result = DoctorService.ModifyExperience(id, experience);
                if (result != null)
                    Console.WriteLine("Update success");
            }
            catch (NoSuchDoctorException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static int Main(string[] args)
        {
            Program program = new Program();
            program.StartAdminActivities();
            Console.WriteLine("Hello, World!");
            return 0;
        }
    }
}
