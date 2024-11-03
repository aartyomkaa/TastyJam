using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    public int MaxHp = 100;
    public int Dmg = 35;
    public float Cooldown = 0.85f;
    public float DamageRange = 0.9f;
    public float Speed = 0.7f;
    public float VisibilityRange = 0.8f;
}
