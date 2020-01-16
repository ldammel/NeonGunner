﻿using System;
using System.Collections;
using System.Collections.Generic;
using BansheeGz.BGSpline.Curve;
using Library.Character;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Library.Combat.Enemy
{
    public class WaypointManager : MonoBehaviour
    {
        [BoxGroup("Paths")]
        [SerializeField] private BGCurve pathLeft;
        [BoxGroup("Paths")]
        [SerializeField] private BGCurve pathRight;
        [BoxGroup("Paths")]
        [SerializeField] private BGCurve pathUpLeft;
        [BoxGroup("Paths")]
        [SerializeField] private BGCurve pathUpRight;

        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private GameObject[] portalVfx;

        public void TriggerSpawn(int lane, float[] delay)
        {
            switch (lane)
            {
                case 1:
                    StartCoroutine(Spawn(pathLeft, delay,0));
                    break;
                case 2:
                    StartCoroutine(Spawn(pathRight, delay,1));
                    break;
                case 3:
                    StartCoroutine(Spawn(pathUpLeft, delay,2));
                    break;
                case 4:
                    StartCoroutine(Spawn(pathUpRight, delay,3));
                    break;
                default:
                    break;
            }
        }

        IEnumerator Spawn(BGCurve lane, float[] delay, int portalIndex)
        {
            portalVfx[portalIndex].SetActive(true);
            for (int i = 0; i < delay.Length; i++)
            {
                yield return new WaitForSeconds(delay[i]);
                var go = Instantiate(enemyPrefab, lane.Points[0].PointTransform);
                go.transform.parent = lane.transform;
                go.transform.localPosition = lane.Points[0].PositionLocal;
                go.GetComponent<WaypointMovement>().path = lane;
            }
            portalVfx[portalIndex].SetActive(false);
        }
    }
}