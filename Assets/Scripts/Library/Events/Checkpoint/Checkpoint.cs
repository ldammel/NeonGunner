using System;
using System.Collections;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;
using Library.Character;
using Sirenix.Utilities;
using UnityEngine;

namespace Library.Events.Checkpoint
{
    public class Checkpoint : MonoBehaviour
    {

        [SerializeField] private BGCcTrs path;
        [SerializeField] private float timeToStop;

        [SerializeField] private BGCurve[] curves;
        [SerializeField] private GameObject enemy;

        [SerializeField] private int spawnAmount;

        [SerializeField] private float timeToContinue;
            

        private bool _activated;
        private float _curSpeed;

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
            if (!_activated) return;
            path.Speed = 0;
            
            gameObject.GetComponent<Collider>().enabled = false;
            curves.ForEach(x => StartCoroutine(Spawn(x,spawnAmount)));
            StartCoroutine(Continue(timeToContinue));
            _activated = false;
        }
        
        IEnumerator Spawn(BGCurve lane, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                yield return new WaitForSeconds(1);
                var go = Instantiate(enemy, lane.Points[0].PointTransform);
                go.transform.parent = lane.transform;
                go.transform.localPosition = lane.Points[0].PositionLocal;
                go.GetComponent<WaypointMovement>().path = lane;
                go.GetComponent<WaypointMovement>().moveSpeed = 2;
            }
        }

        IEnumerator Continue(float time)
        {
            yield return  new WaitForSeconds(time);
            path.Speed = _curSpeed;
        }
    }
}
