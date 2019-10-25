using System;
using Library.Character;
using PathCreation;
using UnityEngine;

namespace Library.Events
{
    public class SignActivation : MonoBehaviour
    {
        [SerializeField] private PathCreator path; 
        private WaypointMovement move;
        [SerializeField] private GameObject[] deactivate;

        private void Start()
        {
            move = GameObject.FindGameObjectWithTag("Player").GetComponent<WaypointMovement>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("PlayerBullet"))
            {
                PathSign();
            }
        }

        public void ChangePath(WaypointMovement _move)
        {
            _move.path = path;
            move.dist = 0;
        }

        public void PathSign()
        {
            move.path = path;
            move.OnPathChanged();
            for (int i = 0; i < deactivate.Length; i++)
            {
                deactivate[i].SetActive(false);
            }
        }
    }
}
