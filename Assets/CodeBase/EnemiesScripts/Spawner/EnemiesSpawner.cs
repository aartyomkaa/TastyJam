using System.Collections;
using CodeBase.Infrastructure.Factory;
using CodeBase.StaticData;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private int _enemiesCount = 20;
    [SerializeField] private int _minGroupCount = 1;
    [SerializeField] private int _maxGroupCount = 5;
    [SerializeField] private float _minSpawnDelay = 7;
    [SerializeField] private float _maxSpawnDelay = 7;
    [SerializeField] private float _randomRange = 0.1f;
    
    private Transform _knight;
    private EnemyStaticData _data;

    public void Construct(Transform knight, EnemyStaticData enemyData)
    {
        _knight = knight;
        _data = enemyData;
    }

    private void Start()
    {
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        int _spawnedCount = 0;
        while (_spawnedCount < _enemiesCount)
        {
            bool _xAxisToIncrease = Random.value < 0.5f;
            bool _xPosHalf = Random.value < 0.5f;
            bool _yPosHalf = Random.value < 0.5f;

            float _xPosToSpawn = GetXPosition(_xAxisToIncrease, _xPosHalf);

            float _yPosToSpawn = GetYPosition(_xAxisToIncrease, _xPosHalf);

            Vector2 _groupSpawnPos = Camera.main.ViewportToWorldPoint(new Vector2(_xPosToSpawn, _yPosToSpawn));
            
            int _enemiesInGroup = Mathf.Min(_enemiesCount - _spawnedCount, 
                (int)(Random.Range(_minGroupCount, _maxGroupCount)));
            
            for (int i = _enemiesInGroup; i > 0; i--)
            {
                Vector2 position = _groupSpawnPos + new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

                CreateEnemy(position);
            }
            
            yield return new WaitForSeconds(Random.Range(_minSpawnDelay, _maxSpawnDelay));
        }
    }
    
    private void CreateEnemy(Vector3 position)
    {
        GameObject enemy = Instantiate(_data.Prefab, position, Quaternion.identity);
                
        enemy.GetComponent<Enemy>().Construct(_data, _knight);
    }

    private float GetXPosition(bool isIncrease, bool isHalf)
    {
        float _xPosToSpawn = isIncrease ? (isHalf ? 1.2f + Random.Range(0, _randomRange) : -0.2f - Random.Range(0, _randomRange)) 
            : Random.Range(0 - _randomRange, 1 + _randomRange);

        return _xPosToSpawn;
    }

    private float GetYPosition(bool isIncrease, bool isHalf)
    {
        float _yPosToSpawn = isIncrease  ? Random.Range(0 - _randomRange, 1 + _randomRange)
            : (isHalf ? 1.2f + Random.Range(0, _randomRange) : -0.2f - Random.Range(0, _randomRange));

        return _yPosToSpawn;
    }
}
