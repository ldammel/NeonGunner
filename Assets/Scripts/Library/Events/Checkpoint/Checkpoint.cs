using System;
using System.Collections;
using System.Collections.Generic;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;
using Library.Character;
using Library.Combat.Enemy;
using Sirenix.Utilities;
using UnityEngine;

namespace Library.Events.Checkpoint
{
    public class Checkpoint : MonoBehaviour
    {

        [SerializeField] private BGCcTrs path;

        [SerializeField] private BGCurve[] curves;
        [SerializeField] private GameObject enemy;

        [SerializeField] private int spawnAmount;

        private bool _activated;
        private float _curSpeed;

        [SerializeField] private List<GameObject> enemies = new List<GameObject>();
        
        public int enemyAmount;

        private void Start()
        {
            _curSpeed = path.Speed;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            _activated = true;
        }

        private void Update()
        {
            if (enemyAmount == 0 && !PauseMenu.Instance.pauseActive)
            {
                path.Speed = _curSpeed;
            }
            if (!_activated) return;
            path.Speed = 0;
            
            gameObject.GetComponent<Collider>().enabled = false;
            curves.ForEach(x => StartCoroutine(Spawn(x,spawnAmount)));
            StartCoroutine(ForceDestroy());
            _activated = false;
        }

        IEnumerator ForceDestroy()
        {
            yield return new WaitForSeconds(20);
            foreach (var e in enemies)
            {
                if (e != null)
                {
                    Destroy(e);
                }
            }
            enemyAmount = 0;
            enemies.Clear();
        }

        IEnumerator Spawn(BGCurve lane, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                enemyAmount++;
                yield return new WaitForSeconds(1);
                var go = Instantiate(enemy, lane.Points[0].PointTransform);
                go.transform.parent = lane.transform;
                go.transform.localPosition = lane.Points[0].PositionLocal;
                go.GetComponent<WaypointMovement>().path = lane;
                go.GetComponent<WaypointMovement>().moveSpeed = 2;
                go.GetComponent<WaypointMovement>().destroyOnEnd = false;
                go.GetComponent<EnemyHealth>().isCheckPoint = true;
                go.GetComponent<EnemyHealth>().check = this;
                enemies.Add(go);
            }
        }
    }
}
