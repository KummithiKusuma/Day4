

using DoctorDALLibrary;
using DoctorBLLibrary;
using DoctorModelLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DoctorBLLibrary
{
    public class DoctorService : IDoctorService
    {
        IRepository repository;
        public DoctorService()
        {
          repository = new DoctorRepository();
        }
        /// <summary>
        /// Adds the  to the collection using the repository
        /// Adds the doctor to the collection using the repository
        /// </summary>
        /// <param name="doctor">The doctor to be added</param>
        /// <returns></returns>
        /// <exception cref="NotAddedException">Doctor Id duplicated</exception>
        public Doctor AddDoctor(Doctor doctor)
        {
            var result = repository.Add(doctor);
            if (result != null)
                return result;
            throw new NotAddedException();
        }

        public Doctor Delete(int id)
        {
            var Doctor = GetDoctor(id);
            if (Doctor != null)
            {
                repository.Delete(id);
                return Doctor;
            }
            throw new NoSuchDoctorException();
        }
        /// <summary>
        /// Returns the doctor for the given Id
        /// </summary>
        /// <param name="id">Id of the doctor to be returned</param>
        /// <returns></returns>
        /// <exception cref="NoSuchDoctorException">No doctor with the given Id</exception>
        public Doctor GetDoctor(int id)
        {
            var result = repository.GetById(id);
            //if (result != null) 
            //    return result;
            //throw new NoSuchDoctorException();

            //null collasing operator
            //return result ?? throw new NoSuchDoctorException();

            return result == null ? throw new NoSuchDoctorException() : result;
        }

        public List<Doctor> GetDoctor()
        {
            var doctors = repository.GetAll();
            if (doctors.Count != 0)
                return doctors;
            throw new NoDoctorsAvailableException();
        }

        public Doctor ModifyDoctorPhoneNumber(int id, float price)
        {
            var doctor = GetDoctor(id);
            if (doctor != null)
            {
                doctor.PhoneNumber += phonenumber;
                var result = repository.Modify(doctor);
                return result;
            }
            throw new NoSuchDoctorException();
        }

        public Doctor modifyDoctorExperience(int id, int experience, string action)
        {
            var doctor = GetDoctor(id);
            if (doctor != null)
            {
                if (action == "add")
                {
                    doctor.Experience += experience;
                }
                else if (action == "remove")
                {
                    doctor.Experience -= experience;
                }
                else
                    throw new InValidModifyActionException();
                var result = repository.Modify(doctor);
                return result;
            }
            throw new NoSuchDoctorException();
        }
    }
}