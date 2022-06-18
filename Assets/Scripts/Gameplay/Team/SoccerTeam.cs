using System.Collections.Generic;
using Leopotam.Ecs;

namespace FootballECS
{
    public struct SoccerTeam
    {
        public string Name;
        public TeamType Type;
        public List<EcsEntity> Players;
    }
}
