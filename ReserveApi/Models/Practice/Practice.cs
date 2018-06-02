using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace ReserveApi.Models
{
    public class Practice
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Practice_id { get; set; }
        public string Practice_name { get; set; }
        public string Speciality { get; set; }
        public string License_number { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip_code { get; set; }
        public string Cellphone { get; set; }
    }
}
