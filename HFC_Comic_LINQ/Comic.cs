using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace HFC_Comic_LINQ
{
   public class Comic
    {
        public string Name { get; set; }
        public int Issue { get; set; }

        public override string ToString() => $"{Name} (Issue #{Issue})";

        public  static readonly IEnumerable<Comic> Catalogue =
            new List<Comic>
            {
                new Comic { Name="Johny America vs. the Pinko", Issue=6},
                new Comic { Name="Rock and Roll (limited edition)", Issue=19},
                new Comic { Name="Woman's Work", Issue=36},
                new Comic { Name="Hippie Madness (misprinted)", Issue=57},
                new Comic {Name = "Revenge of the New Wave Freak (damaged)", Issue=68},
                new Comic { Name="Black Monday", Issue =74},
                new Comic { Name = "Tribal Tattoo Madness", Issue=83},
                new Comic { Name = "The Death of the Object", Issue=97},
            };

        public static readonly IReadOnlyDictionary<int, decimal> Prices =
            new Dictionary<int, decimal>
            {
                { 6, 3600m },
                { 19, 500m },
                { 36, 650m },
                { 57, 13525m },
                { 68, 250m },
                { 74, 75m },
                { 83, 25.75m },
                { 97, 35.25m },
            };

        public static readonly IEnumerable<Review> Reviews = new[]
        {
            new Review() {Issue = 36, Critic = Critics.MuddyCritic, Score=37.6},
            new Review() {Issue = 74, Critic = Critics.RottenTornadoes, Score = 22.8},
            new Review() {Issue = 74, Critic = Critics.MuddyCritic, Score = 84.2},
            new Review() {Issue = 83, Critic = Critics.RottenTornadoes, Score = 89.4},
            new Review() {Issue = 97, Critic = Critics.MuddyCritic, Score = 98.1},
        };
    }

  public  class Review
    {
        public int Issue { get; set; }
        public Critics Critic { get; set; }
        public double Score { get; set; }
    }

  public  enum Critics 
    {
        MuddyCritic,
        RottenTornadoes,
    }

 public   enum PriceRange
    {
        Cheap,
        Expensive,
    }



}
