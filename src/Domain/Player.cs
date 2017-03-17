using System;

namespace Domain
{
    public class Player : Entity
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime TimeInTeam { get; set; }
        public Guid PlayerPositionIdx { get; set; }
        public Guid TeamIdx { get; set; }
    }
}