using System;

namespace SE2025.Models
{
    public class User_Type
    {
        //Primary key
        public int User_Type_ID { get; set; }

        public enum Type_Name { get; set; } // e.g., "Carer", "Patient
        public string Description { get; set; } // Description of the user type

        //Navigation properties (relationships)
        public ICollection<User> Users { get; set; }
    }
}


