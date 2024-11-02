using UnityEngine;

namespace CodeBase.StaticData
{
    public class KnightStaticData
    {
        [Range(1, 100)]
        public int Hp;

        [Range(1, 30)]
        public float Damage;
        
        [Range(1, 100)]
        public float MoveSpeed;

        [Range(0.5f, 1f)]
        public float EffectiveDistance;

        public GameObject Prefab;
    }
}