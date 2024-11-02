using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "KnightData", menuName = "StaticData/Knight")]
    public class KnightStaticData : ScriptableObject
    {
        [Range(1, 100)]
        public int Hp;

        [Range(1, 30)]
        public float Damage;
        
        [Range(1, 100)]
        public float MoveSpeed;

        [Range(0.5f, 1f)]
        public float EffectiveDistance;
        
        [Range(1f, 10f)]
        public float AggroRange;
        
        [Range(1f, 2f)] 
        public float AttackRange;

        public LayerMask Enemy;
    }
}