using System;

namespace SE2025.Models
{
    public class Carer
    {
        //Primary and foreign key
        public int User_ID { get; set; }

        public string? Availability_Schedule { get; set; } //? indicates that the property can be null

        //Navigation properties (relationships)
        public User User { get; set; }

        //Collection (a carer can have multiple access records)
        public ICollection<CarerAccess> CarerAccesses { get; set; }
    }
}

