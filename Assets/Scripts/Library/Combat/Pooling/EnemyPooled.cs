using System;
using Library.Combat.Enemy;
using UnityEngine;

namespace Library.Combat.Pooling
{
    public class EnemyPooled : MonoBehaviour, IEnemyPooled
    {
        private EnemyPool _pool;

        public EnemyPool Pool
        {
            get => _pool;
            set
            {
                if (_pool == null)
                    _pool = value;
                else 
                    throw new Exception("Bad pool use, this should only get set once!");
            }
        }

        public void ReturnToPool()
        {
            _pool.ReturnToPool(gameObject);
        }
    }
    
    internal interface IEnemyPooled
    {
        EnemyPool Pool { get; set; }
    }
}