using System;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;
using Library.Events;
using UnityEngine;

namespace Library.Character
{
    public class SpeedController : MonoBehaviour
    {
        public BGCcTrs path;
        private float _speed;

        private void Start()
        {
            _speed = path.Speed;
        }

        private void Update()
        {
            path.Speed = PauseMenu.Instance.pauseActive ? 0 : _speed;
        }
    }
}
