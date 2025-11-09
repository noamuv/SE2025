using System;

namespace SE2025.Models
{
    public class Patient
    {
        //Primary and foreign key
        public int User_ID { get; set; }

        //Forgein keys
        public int Clinician_User_ID { get; set; }
        public int Gender_ID { get; set; }
        public DateTime Date_of_Birth { get; set; }
        public string Notes { get; set; }

        //Navigation properties (relationships)
        public User User { get; set; }
        public CarerAccess CarerAccess { get; set; }
    }

}
