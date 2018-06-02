using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace ReserveApi.Models
{
    public class Appointments
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Patient_id { get; set; }
        public string Appointment_date { get; set; }
        public string Practice_id { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }
    }
}
