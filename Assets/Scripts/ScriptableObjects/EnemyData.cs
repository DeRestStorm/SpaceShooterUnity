using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "EnemyData", order = 0)]
    public class EnemyData : ScriptableObject
    {
        public float Speed = 5;
        public float Damage = 1;
        public float Health = 1;
        public int ScorePoints = 10;
    }
}