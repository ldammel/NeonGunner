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
        private WaypointMovement _move;
        [SerializeField] private GameObject[] deactivate;
        public bool activated;

        private void Start()
        {
            _move = GameObject.FindGameObjectWithTag("Player").GetComponent<WaypointMovement>();
        }

        public void ChangePath(WaypointMovement move)
        {
            if (activated)
            {
                move.path = mainPath;
                _move.OnPathChanged();
                gameObject.SetActive(false);
            }
            else
            {
                move.path = path;
                _move.currentDistance = 0;
            }
        }

        public void PathSignActivation()
        {
            deactivate[0].GetComponent<SignActivation>().activated = true;
            gameObject.SetActive(false);
        }
    }
}
