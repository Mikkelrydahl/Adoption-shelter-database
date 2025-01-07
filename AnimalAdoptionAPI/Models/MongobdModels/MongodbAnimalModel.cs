using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;


namespace AnimalAdoptionAPI.MongodbModels;


public class Animal
{
    [BsonId]
    public int _id { get; set; }


    [BsonElement("pet_name")]
    public string PetName { get; set; }


    [BsonElement("age")]
    public int Age { get; set; }


    [BsonElement("species")]
    public string Species { get; set; }


    [BsonElement("breed")]
    public string Breed { get; set; }


    [BsonElement("medical_appointments")]
    public List<MedicalAppointment> MedicalAppointments { get; set; }


    [BsonElement("medical_records")]
    public List<MedicalRecord> MedicalRecords { get; set; }
}


public class MedicalAppointment
{
    [BsonElement("employee_id")]
    public int EmployeeId { get; set; }


    [BsonElement("start_time")]
    public DateTime StartTime { get; set; }


    [BsonElement("appointment_description")]
    public string AppointmentDescription { get; set; }
}


public class MedicalRecord
{
    [BsonElement("appointment_description")]
    public string AppointmentDescription { get; set; }


    [BsonElement("employee_id")]
    public int EmployeeId { get; set; }
}
