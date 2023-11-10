using System.Runtime.Serialization;

namespace DoctorBLLibrary
{
    [Serializable]
    public class InValidModifyActionException : Exception
    {
        string message;
        public InValidModifyActionException()
        {
            message = "The action you have specified is not valid";
        }
        public override string Message => message;

    }
}