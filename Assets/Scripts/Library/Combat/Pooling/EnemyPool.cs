using System.Collections.Generic;
using UnityEngine;

namespace Library.Combat.Pooling
{
    public class EnemyPool: MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        private readonly Queue<GameObject> _objects = new Queue<GameObject>();

        private void Start()
        {
            AddEnemies(10);
        }

        public GameObject Get()
        {
            if (_objects.Count == 0)
            {
                AddEnemies(1);
            }

            return _objects.Dequeue();
        }

        public void ResetShots()
        {
            for (int i = 0; i < _objects.Count; i++)
            {
                Destroy(_objects.Dequeue());
            }
            AddEnemies(10);
        }

        private void AddEnemies(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var newObject = Instantiate(prefab, gameObject.transform);
                newObject.SetActive(false);
                _objects.Enqueue(newObject);
            }
        }

        public void ReturnToPool(GameObject enemy)
        {
            enemy.gameObject.SetActive(false);
            _objects.Enqueue(enemy);
        }
    }
}