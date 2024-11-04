using CodeBase.Infrastructure.AssetManagment;
using CodeBase.Infrastructure.Services;
using CodeBase.Knight;
using CodeBase.Knight.KnightFSM;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    internal class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;
        private readonly IStaticDataService _staticData;

        public GameFactory(IAssets assets, IStaticDataService staticData)
        {
            _assets = assets;
            _staticData = staticData;
        }

        public GameObject CreateHero(GameObject at)
        {
            GameObject hero = _assets.InstantiateAt(AssetPath.Hero, at.transform.position);
            
            return hero;
        }

        public GameObject CreateKnight(GameObject at)
        {
            KnightStaticData knightData = _staticData.ForKnight();
            GameObject knight = _assets.InstantiateAt(AssetPath.Knight, at.transform.position);

            KnightMover mover = knight.GetComponent<KnightMover>();
            KnightAttacker attacker = knight.GetComponent<KnightAttacker>();
            
            KnightStateMachine knightStateMachine = new KnightStateMachine(
                knight.GetComponent<Animator>(),
                mover,
                knight.GetComponent<KnightAttacker>(),
                knightData);
            
            mover.Construct(knightData.MoveSpeed);
            attacker.Construct(knightData.Damage, knightData.AttackRadius, knightData.AttackCooldown, knightData.Enemy);
            knight.GetComponent<KnightDefender>().Construct(knightStateMachine, knightData.Hp);
            
            return knight;
        }

        public GameObject CreateHud() => 
            _assets.Instantiate(AssetPath.Hud);
        

        public GameObject CreateSpawner(EnemyStaticData enemyType, Transform knight)
        {
            var prefab = Resources.Load<GameObject>(AssetPath.Spawner);
            GameObject spawner = Object.Instantiate(prefab, Vector3.zero, Quaternion.identity);
            
            spawner.GetComponent<EnemiesSpawner>().Construct(knight, enemyType);

            return spawner;
        }
    }
}