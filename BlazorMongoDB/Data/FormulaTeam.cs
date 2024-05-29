using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace FormulaDatabase.Data
{
    public class FormulaTeam
    {
		public byte[]? Photo { get; set; }
		public string ImageUrl { get; set; } = "";

		[BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? FullTeamName { get; set; }
        public string? Base { get; set; }
        public string? TeamChief { get; set; }
        public string? TechnicalChief { get; set; }
        public string? Chassis { get; set; }
        public string? PowerUnit { get; set; }
        public int FirstTeamEntry { get; set; }
        public int WorldChampionships { get; set; }
        public int HighestRaceFinish { get; set; }
        public int HighestRaceFinishHowManyTimes { get; set; }
        public int PolePositions { get; set; }
        public int FastestLaps { get; set; }
        public string? FirstDriver { get; set; }
        public string? SecondDriver { get; set; }
        public string? ReserveDriver { get; set; }

    }
}
