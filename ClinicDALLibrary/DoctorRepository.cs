using DoctorDALLibrary;
using DoctorModelLibrary;

namespace DoctorDALLibrary
{
    public class DoctorRepository : IRepository
    {
        Dictionary<int, Doctor> doctors = new Dictionary<int, Doctor>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Doctor">Doctor object that has to be added</param>
        /// <returns>The doctor that has been added</returns>
        public Doctor Add(Doctor doctor)
        {
            int id = GetTheNextId();
            try
            {
                doctor.Id = id;
                doctors.Add(doctor.Id, doctor);
                return doctor;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("The doctor Id already exists");
                Console.WriteLine(e.Message);
            }
            return null;

        }

        private int GetTheNextId()
        {
            if (Doctor.Count == 0)
                return 1;
            int id = doctors.Keys.Max();
            return ++id;
        }

        /// <summary>
        /// Deletes the doctor from teh dictionary using the id as key
        /// </summary>
        /// <param name="id">The Id of the doctor to be deleted</param>
        /// <returns>The deleted doctor</returns>
        public Doctor Delete(int id)
        {
            var doctor = Doctor[id];
            doctors.Remove(id);
            return doctor;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns> Getting all the items using dictionaries</returns>

        public List<Doctor> GetAll()
        {
            var doctorList = doctors.Values.ToList();
            return doctorList;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">The id of the doctors are getting</param>
        /// <returns> returns the doctor using id</returns>
        public Doctor GetById(int id)
        {
            return doctors[id];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="doctor"> Doctors updated using id from the dictionary</param>
        /// <returns>Returns the updated doctor</returns>
        public Doctor Modify (Doctor doctor)
        {
            doctors[doctor.Id] = doctor;
            return doctors[doctor.Id];
        }
    }
}