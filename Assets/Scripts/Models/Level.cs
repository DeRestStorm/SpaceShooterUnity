using System;
using Enums;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class Level
    {
        public ushort Number;
        public LevelState State;

        public Level()
        {
        }

        public Level(ushort number, LevelState state)
        {
            Number = number;
            State = state;
        }
    }
}