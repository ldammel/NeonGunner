
using BansheeGz.BGSpline.Components;
using UnityEngine;

namespace Library.Character
{
    public class SpeedController : MonoBehaviour
    {
        public BGCcTrs[] path;
        public float speed;

        private void Start()
        {
            path = FindObjectsOfType<BGCcTrs>();
            speed = path[0].Speed;
        }
    }
}
