using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Base;
using UnityEngine;

namespace Assets.Scripts.Pooler
{
    public class PoolerController : IController
    {
        private const string WarningMessage = "The pool with tag \"{0}\" doesn't exist.";
        
        private readonly IPoolerView _view;

        public PoolerController(IPoolerView view)
        {
            _view = view;
        }

        public Task Initialize()
        {
            FillPoolDictionary();
            return Task.CompletedTask;
        }

        public Task Dispose()
        {
            ClearPoolDictionary();
            return Task.CompletedTask;
        }
        
        private void FillPoolDictionary()
        {
            foreach (var pool in _view.IPools)
            {
                var objectPool = new Queue<GameObject>();

                for (int i = 0; i < pool.Size; i++)
                {
                    GameObject gameObjectInstance = Object.Instantiate(pool.Prefab);
                    gameObjectInstance.SetActive(false);
                    objectPool.Enqueue(gameObjectInstance);
                }

                _view.PoolDictionary.Add(pool.Tag, objectPool);
            }
        }
        
        private void ClearPoolDictionary()
        {
            foreach (var poolEntry in _view.PoolDictionary)
            {
                poolEntry.Value.Clear();
            }
            
            _view.PoolDictionary.Clear();
        }
        
        public GameObject SpawnFromPool(IStringReference tag, Vector3 position, Quaternion rotation)
        {
            if (!_view.PoolDictionary.ContainsKey(tag))
            {
                Debug.LogWarning(string.Format(WarningMessage, tag.Value));
                return null;
            }

            GameObject objectToSpawn = _view.PoolDictionary[tag].Dequeue();

            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

            _view.PoolDictionary[tag].Enqueue(objectToSpawn);

            return objectToSpawn;
        }
    }
}