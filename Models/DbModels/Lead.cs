using Models.Abstract;

namespace Models.DbModels
{
    public class Lead: Entity
    {
        public string PhoneNumber { get; set; }
        public bool IsSendSMS { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}
