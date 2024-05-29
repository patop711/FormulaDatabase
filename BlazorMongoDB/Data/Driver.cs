
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FormulaDatabase.Data
{
    public class Driver
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Country { get; set; }
        public string? PlaceOfBirth { get; set; }
        public string? Team { get; set; }
        public int RacingNumber { get; set; }
        public int Podiums { get; set; }
        public double Points { get; set; }
        public int GrandPrixEntered { get; set; }
        public int WorldChampionships { get; set; }
        public int HighestRaceFinish { get; set; }
        public int HighestRaceFinishHowManyTimes { get; set; }
        public int HighestGridPosition { get; set; }

        public byte[]? Photo { get; set; }
        public string? ImageUrl { get; set; } = "";
    }
}
