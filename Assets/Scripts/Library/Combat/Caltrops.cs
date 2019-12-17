using System;
using Library.Tools;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Library.Combat
{
    public class Caltrops : MonoBehaviour
    {
        public int caltropAmount;
        [SerializeField] private GameObject caltropPrefab;
        [SerializeField] private float fireRate;
        private float _fireTimer;


        private void Update()
        {
            if (Input.GetMouseButton(0) && _fireTimer >= fireRate)
            {
                for (int i = 0; i < caltropAmount; i++)
                {
                    var go = Instantiate(caltropPrefab);
                    var position = transform.position;
                    go.transform.position = new Vector3(position.x + Random.Range(-10,10), position.y, position.z+ Random.Range(-10,10));
                }
                _fireTimer = 0;
            }
            
            _fireTimer += Time.deltaTime;
        }
    }
}
