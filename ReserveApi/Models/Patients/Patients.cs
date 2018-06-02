using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace ReserveApi.Models
{
    
    public class Patients
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Patient_id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Birthdate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip_code { get; set; }
        public string Cellphone { get; set; }
        public string Practice_id { get; set; }
        public string Next_visit_date { get; set; }
        public string Medical_notes { get; set; }
    }
}
