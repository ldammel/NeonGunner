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
        public float speed;

        private void Start()
        {
            speed = path.Speed;
        }
    }
}
