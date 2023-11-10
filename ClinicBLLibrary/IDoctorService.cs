using DoctorModelLibrary;
using DoctorDALLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DoctorBLLibrary
{
    public interface IDoctorService
    {
        public Doctor AddDoctor(Doctor doctor);
        public Doctor ModifyDoctorphonenumber(int id, float phonenumber);
        public Doctor ModifyDoctorExperience(int id, int quantity, string action);
        public Doctor GetDoctor(int id);
        public List<Doctor> GetDoctors();
        public Doctor Delete(int id);
    }
}