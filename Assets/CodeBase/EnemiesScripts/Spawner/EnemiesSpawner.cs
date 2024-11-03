using System.Collections;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private EnemyController[] _enemiesPrefs;
    [SerializeField] private int _enemiesCount = 20;
    [SerializeField] private int _minGroupCount = 1;
    [SerializeField] private int _maxGroupCount = 5;
    [SerializeField] private float _minSpawnDelay = 7;
    [SerializeField] private float _maxSpawnDelay = 7;
    [SerializeField] private float _randomRange = 0.1f;

    private void Start()
    {
        StartCoroutine(Spawning());
    }

    public IEnumerator Spawning()
    {
        int _spawnedCount = 0;
        while (_spawnedCount < _enemiesCount)
        {
            yield return new WaitForSeconds(Random.Range(_minSpawnDelay, _maxSpawnDelay));

            bool _xAxisToIncrease = Random.value < 0.5f;
            bool _xPosHalf = Random.value < 0.5f;
            bool _yPosHalf = Random.value < 0.5f;
            float _xPosToSpawn = _xAxisToIncrease ? (_xPosHalf ? 1.2f + Random.Range(0, _randomRange) : -0.2f - Random.Range(0, _randomRange)) 
                : Random.Range(0 - _randomRange, 1 + _randomRange);
            float _yPosToSpawn = _xAxisToIncrease ? Random.Range(0 - _randomRange, 1 + _randomRange)
                : (_xPosHalf ? 1.2f + Random.Range(0, _randomRange) : -0.2f - Random.Range(0, _randomRange));

            Vector2 _groupSpawnPos = Camera.main.ViewportToWorldPoint(new Vector2(_xPosToSpawn, _yPosToSpawn));


            int _enemiesInGroup = Mathf.Min(_enemiesCount - _spawnedCount, 
                (int)(Random.Range(_minGroupCount, _maxGroupCount)));
            for (int i = _enemiesInGroup; i > 0; i--)
            {
                Instantiate(_enemiesPrefs[Random.Range(0, _enemiesPrefs.Length - 1)],
                    _groupSpawnPos + new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)), Quaternion.identity);
            }
        }
    }
}
