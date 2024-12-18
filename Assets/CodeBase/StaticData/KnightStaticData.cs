﻿using UnityEngine;

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
        
        [Range(1f, 100f)]
        public float AggroRange;
        
        [Range(1f, 50f)] 
        public float AttackRange;

        [Range(1f, 50f)] 
        public float PickUpRange;

        public LayerMask Enemy;
    }
}