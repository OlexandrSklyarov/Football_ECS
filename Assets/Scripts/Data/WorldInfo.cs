using System;
using UnityEngine;

namespace FootballECS
{
    [Serializable]
    public class WorldInfo
    {
        public Transform[] RedTeamStartPositions;
        public Transform[] BlueTeamStartPositions;
    }
}
