namespace DoctorModelLibrary
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int PhoneNumber { get; set; }
        public int Experience { get; set; }

        public Doctor()
        {
            PhoneNumber = 1;
            Experience = 1;

        }

        public Doctor(int id, string name, int phoneNumber, int experience)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Experience = experience;
        }

        public override string ToString()
        {
            int phonenumber = PhoneNumber;
            return $"Doctor Id : {Id}\nDoctor Name : {Name}\nDoctor PhoneNumber Price : Rs. {PhoneNumber}\nDoctor Experience In Hand : {Experience}";
        }
    }
}

