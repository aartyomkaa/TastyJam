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
        private GameObject HeroGameObject { get; set; }

        public GameFactory(IAssets assets, IStaticDataService staticData)
        {
            _assets = assets;
            _staticData = staticData;
        }

        public GameObject CreateHero(GameObject at)
        {
            HeroGameObject = _assets.InstantiateAt(AssetPath.Hero, at.transform.position);
            
            return HeroGameObject;
        }

        public GameObject CreateKnight(GameObject at)
        {
            KnightStaticData knightData = _staticData.ForKnight();
            GameObject knight = _assets.InstantiateAt(AssetPath.Knight, at.transform.position);

            KnightMover mover = knight.GetComponent<KnightMover>();
            
            KnightStateMachine knightStateMachine = new KnightStateMachine(
                knight.GetComponent<Animator>(),
                mover,
                knight.GetComponent<KnightAttacker>(),
                knightData);
            
            mover.Construct(knightData.MoveSpeed);
            knight.GetComponent<KnightDefender>().Construct(knightStateMachine);
            
            return knight;
        }

        public GameObject CreateHud() => 
            _assets.Instantiate(AssetPath.Hud);

        public GameObject CreateMonster(MonsterTypeID monsterTypeID, Transform parent)
        {
            MonsterStaticData monsterData = _staticData.ForMonster(monsterTypeID);
            GameObject monster = Object.Instantiate(monsterData.Prefab, parent.position, Quaternion.identity, parent);

            //IHealth health = monster.GetComponent<IHealth>();
            //health.Current = monsterData.Hp;
            //health.Max = monsterData.Hp;
            
            //monster.GetComponent<ActorUI>().Construct(health);
            //monster.GetComponent<AgentMoveToPlayer>().Construct(HeroGameObject.transform);
            //monster.GetComponent<NavMeshAgent>().speed = monsterData.MoveSpeed;

            //LootSpawner loot = monster.GetComponentInChildren<LootSpawner>();
            //loot.SetLoot(monsterData.MinLoot, monsterData.MaxLoot);
            //loot.Construckt(this);
            
            //Attack.attack = monster.GetComponent<Attack>();
            //attack.Construct(HeroGameObject.transform);
            //attack.Damage = monsterData.Damage;
            //attack.Cleavage = monsterData.Cleavage;
            //attack.EffectiveDistance = monsterData.EffectiveDistance;
            
            //monster.GetComponent<RotateToHero>()?.Construct(HeroGameObject.transform);

            return monster;
        }
    }
}