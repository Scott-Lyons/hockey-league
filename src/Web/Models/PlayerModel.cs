using System;
using System.Collections.Generic;

namespace Web.Models
{
    public class PlayerModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid PositionIdx { get; set; }
        public DateTime TimeInTeam { get; set; }
        public IEnumerable<PlayerPositionModel> PlayerPositions { get; set; }
    }
}