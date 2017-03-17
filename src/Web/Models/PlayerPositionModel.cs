using System;
using Domain;

namespace Web.Models
{
    public class PlayerPositionModel
    {
        public Guid Idx { get; set; }
        public string Name { get; set; }

        public static implicit operator PlayerPositionModel(PlayerPosition playerPosition)
        {
            return new PlayerPositionModel
            {
                Idx = playerPosition.Idx,
                Name = playerPosition.Name
            };
        }
    }
}