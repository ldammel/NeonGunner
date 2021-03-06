﻿using System.Collections.Generic;
using UnityEngine;

namespace Library.Combat.Pooling
{
    public class BulletShotPool : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        private readonly Queue<GameObject> _objects = new Queue<GameObject>();

        private void Start()
        {
            AddShots(10);
        }

        public GameObject Get()
        {
            if (_objects.Count == 0)
            {
                AddShots(1);
            }

            return _objects.Dequeue();
        }

        public void ResetShots()
        {
            for (int i = 0; i < _objects.Count; i++)
            {
                Destroy(_objects.Dequeue());
            }
            AddShots(10);
        }

        private void AddShots(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var newObject = Instantiate(prefab, gameObject.transform);
                newObject.SetActive(false);
                _objects.Enqueue(newObject);
                newObject.GetComponent<IGameObjectPooled>().Pool = this;
            }
        }

        public void ReturnToPool(GameObject shot)
        {
            shot.gameObject.SetActive(false);
            _objects.Enqueue(shot);
        }
    }
}