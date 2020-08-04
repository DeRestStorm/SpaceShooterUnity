using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "LevelData", order = 0)]
    public class LevelData : ScriptableObject
    {
        public ushort Number;
        public ushort NextLevel;
        public EnemyData EnemyData;
        public ushort TimeToWin = 30;
    }
}