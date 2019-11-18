using System;
using Library.Character;
using Library.Tools;
using UnityEngine;

namespace Library.UI
{
    public class SpeedDisplay : MonoBehaviour
    {
        public GameObject[] pointer;
        private WaypointMovement mov;

        private void Start()
        {
            mov = GameObject.FindGameObjectWithTag("Player").GetComponent<WaypointMovement>();
        }

        private void Update()
        {
            if (mov.speed >= 6)
            {
                pointer[5].SetActive(true);
                for (int i = 0; i < pointer.Length-1; i++)
                {
                    pointer[i].SetActive(false);
                }
                return;
            }
            
            for (int i = 0; i < pointer.Length; i++)
            {
                pointer[i].SetActive(i == mov.speed ? true : false);
            }

        }
    }
}
