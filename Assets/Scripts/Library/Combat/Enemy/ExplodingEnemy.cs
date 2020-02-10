using System.Collections;
using Library.Character;
using Library.Combat.Pooling;
using Library.Events;
using UnityEngine;

namespace Library.Combat.Enemy
{
    public class ExplodingEnemy : MonoBehaviour
    {
        public GameObject explosionVfx;
        public int damage;
        public float switchTime;
        public MeshRenderer rend;
        public Material switchMat;
        private Material baseMat;

        private WaypointMovement mov;
        public BoxCollider col;

        private bool switching;

        private void Start()
        {
            baseMat = rend.material;
            if(col == null)col = GetComponent<BoxCollider>();
            mov = GameObject.Find("---PLAYER---/Player").GetComponent<WaypointMovement>();
        }

        private void Update()
        {
            col.center = new Vector3(0,0.54f, -(mov.moveSpeed / 6));
            if (!switching) StartCoroutine(SwitchMat());

        }

        private void OnTriggerEnter(Collider other)
        {
            if(!other.CompareTag("Player")) return;
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
            Instantiate(explosionVfx, transform.position, transform.rotation);
            LevelEnd.Instance.enemiesKilled = 0;
            gameObject.GetComponent<EnemyPooled>().ReturnToPool();
        }

        IEnumerator SwitchMat()
        {
            switching = true;
            rend.material = switchMat;
            yield return new WaitForSeconds(switchTime);
            rend.material = baseMat;
            yield return new WaitForSeconds(0.2f);
            switching = false;
        }
    }
}
