using System;
using Library.Combat.Enemy;
using UnityEngine;
using UnityEngine.UIElements;

namespace Library.Events
{
    public class ComboNova : MonoBehaviour
    {
        private GameObject _nova;
        [SerializeField] private float maxSize = 300;
        [SerializeField] private float time = 2;

        private void Start()
        {
            _nova = gameObject;
        }

        private void Update()
        {
            if (!_nova.activeSelf) return;
            var localScale = _nova.transform.localScale;
            _nova.transform.Rotate(0,2,0);
            localScale = new Vector3((localScale.x + ((maxSize/time) * Time.deltaTime)), (localScale.y + ((maxSize/time) * Time.deltaTime)),(localScale.z + ((maxSize/time) * Time.deltaTime)));
            _nova.transform.localScale = localScale;
            if (!(_nova.transform.localScale.x >= maxSize)) return;
            _nova.transform.localScale = new Vector3(0,0,0);
            _nova.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Enemy")) return;
            if(other.GetComponent<EnemyHealth>() != null) other.GetComponent<EnemyHealth>().TakeDamage(500);
            LevelEnd.Instance.enemiesKilled = 0;
        }
    }
}
