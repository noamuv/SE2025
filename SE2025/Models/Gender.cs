using System;

namespace SE2025.Models
{
    public class Gender
    {
        //Primary and foreign key
        public int Gender_ID { get; set; }

        public string Name { get; set; } //UNIQUE

        //Navigation properties (relationships)
        public ICollection<Patient> Patients { get; set; }
    }
}


