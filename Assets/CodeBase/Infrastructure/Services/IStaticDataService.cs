using CodeBase.Infrastructure.StaticData;

namespace CodeBase.Infrastructure.Services
{
    public interface IStaticDataService : IService
    {
        void LoadMonsters();
        MonsterStaticData ForMonster(MonsterTypeID typeID);
    }
}