using System;
using BansheeGz.BGSpline.Components;
using TMPro;
using UnityEngine;

namespace Library.Events.Checkpoint
{
    public class Checkpoint : MonoBehaviour
    {

        [SerializeField] private BGCcTrs path;
        [SerializeField] private float timeToStop;

        private bool _activated;
        private float _curSpeed;

        private void Start()
        {
            _curSpeed = path.Speed;
        }

        private void Update()
        {
            if (!_activated) return;
            path.Speed = Mathf.Lerp(_curSpeed, 0, timeToStop);

        }
    }
}
