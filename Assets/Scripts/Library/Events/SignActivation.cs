using System;
using Library.Character;
using PathCreation;
using UnityEngine;

namespace Library.Events
{
    public class SignActivation : MonoBehaviour
    {
        [SerializeField] private PathCreator path; 
        [SerializeField] private PathCreator mainPath; 
        private WaypointMovement move;
        [SerializeField] private GameObject[] deactivate;
        public bool activated;

        private void Start()
        {
            move = GameObject.FindGameObjectWithTag("Player").GetComponent<WaypointMovement>();
        }

        public void ChangePath(WaypointMovement _move)
        {
            if (activated)
            {
                _move.path = mainPath;
                move.OnPathChanged();
                gameObject.SetActive(false);
            }
            else
            {
                _move.path = path;
                move.dist = 0;
            }
        }

        public void PathSign()
        {
            deactivate[0].GetComponent<SignActivation>().activated = true;
            gameObject.SetActive(false);
        }
    }
}
