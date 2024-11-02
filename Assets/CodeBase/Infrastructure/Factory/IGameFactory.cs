using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateHero(GameObject at);
        GameObject CreateHud();
        GameObject CreateMonster(MonsterTypeID monsterTypeID, Transform parent);
        //LootPiece CreateLoot();
        //void CreateSpawner(Vector3 at, string spawnerId, MonsterTypeID spawnerDataMonsterTypeID);
    }
}