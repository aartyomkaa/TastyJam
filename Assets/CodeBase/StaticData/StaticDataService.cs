using System.Collections.Generic;
using System.Linq;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<MonsterTypeID, MonsterStaticData> _monsters;

        public void LoadMonsters()
        {
            _monsters = Resources
                .LoadAll<MonsterStaticData>("StaticData/Monsters")
                .ToDictionary(x => x.MonsterTypeID, x => x);
        }

        public MonsterStaticData ForMonster(MonsterTypeID typeID) => 
            _monsters.TryGetValue(typeID, out MonsterStaticData data) ? data : null;
    }
}