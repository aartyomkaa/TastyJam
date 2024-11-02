using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "ObjectData", menuName = "StaticData/Object")]
    public class ThrowableObjectStaticData : ScriptableObject
    {
        public float Speed = 10;
        public float MaxDistance = 5;
    }
}
