using System;

namespace SE2025.Models
{
    public class CarerAccess
    {
        //Primary key
        public int Access_ID { get; set; }

        //Foreign keys
        public int Carer_User_ID { get; set; }
        public int Patient_User_ID { get; set; }

        public int Permission_Level { get; set; }
        public int Granted_By_User_ID { get; set; }
        public int Revoked_By_User_ID { get; set; } // Can be null if access is not revoked
        public DateTime Granted_At { get; set; }
        public DateTime? Revoked_At { get; set; } // Nullable to indicate access may not be revoked yet

        //Navigation properties (relationships)
        public Carer Carer { get; set; }
        public Patient Patient { get; set; }
    }
}
