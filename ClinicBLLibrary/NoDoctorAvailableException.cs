using System.Runtime.Serialization;

namespace DoctorBLLibrary
{
    [Serializable]
    public class NoDoctorsAvailableException : Exception
    {
        string message;
        public NoDoctorsAvailableException()
        {
            message = "No Doctors are available currently";
        }

        public override string Message => message;
    }
}
