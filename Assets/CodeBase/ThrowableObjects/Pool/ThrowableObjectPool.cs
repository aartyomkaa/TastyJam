using CodeBase.ThrowableObjects.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.ThrowableObjects.Pool
{
    public class ThrowableObjectPool : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _objectPrefabs;

        private static Transform _parentObjects;
        private static List<PooledObjectInfo> _objectPools;
        private static List<GameObject> _staticObjectPrefabs;

        public static GameObject SpwanThrowableObject(Vector3 spawnPosition)
        {
            int objectToSpawnIndex = UnityEngine.Random.Range(0, _staticObjectPrefabs.Count);
            GameObject objectToSpawn = _staticObjectPrefabs[objectToSpawnIndex];
            return SpwanThrowableObject(objectToSpawn, spawnPosition);
        }

        public static GameObject SpwanThrowableObject(GameObject objectToSpawn, Vector3 spawnPosition)
        {
            SpawnableObject spawnableObject = objectToSpawn.GetComponent<SpawnableObject>();

            PooledObjectInfo pool = _objectPools.Find(p => p.LookupString == spawnableObject.GetType().Name);

            if (pool == null)
            {
                pool = new PooledObjectInfo() { LookupString = spawnableObject.GetType().Name };
                _objectPools.Add(pool);
            }

            GameObject spawnableObj = pool.InactiveObjects.FirstOrDefault();

            if (spawnableObj == null)
            {
                spawnableObj = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
                spawnableObj.transform.SetParent(_parentObjects, true);
            }
            else
            {
                spawnableObj.transform.position = spawnPosition;
                spawnableObj.transform.SetParent(_parentObjects, true);
                pool.InactiveObjects.Remove(spawnableObj);
                spawnableObj.SetActive(true);
            }

            return spawnableObj;
        }

        public static void ReturnObjectToPool(GameObject obj)
        {
            PooledObjectInfo pool = _objectPools.Find(p => p.LookupString == obj.GetComponent<SpawnableObject>().GetType().Name);

            if (pool == null)
            {
                Debug.LogWarning("Trying to release an object that is not pooled: " + obj.name);
            }
            else
            {
                obj.SetActive(false);
                pool.InactiveObjects.Add(obj);
            }
        }

        private void Awake()
        {
            _parentObjects = transform;
            _objectPools = new List<PooledObjectInfo>();
            _staticObjectPrefabs = _objectPrefabs;
        }

        private void Start()
        {
            SpwanThrowableObject(new Vector3(2, 2, 0));
            SpwanThrowableObject(new Vector3(-2, -2, 0));
            SpwanThrowableObject(new Vector3(4, -4, 0));
            SpwanThrowableObject(new Vector3(-4, 4, 0));
        }



    }
}