using System;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;
using UnityEngine;

namespace Library.Events
{
    public class SignActivation : MonoBehaviour
    {
        [SerializeField] private BGCcTrs curPath; 
        [SerializeField] private BGCcTrs otherPath;
        [SerializeField] private MeshRenderer sign;
        [SerializeField] private GameObject signDisplay;
        [SerializeField] private Material activeMaterial;
        [SerializeField] private Material baseMaterial;
        [SerializeField] private float distance;

        public bool active;
        
        private GameObject player;

        private void Start()
        {
            player = GameObject.Find("---PLAYER---/Player");
        }

        public void ActivateNextPath()
        {
            curPath.ObjectToManipulate = null;
            otherPath.ObjectToManipulate = player.transform;
            otherPath.Distance = distance;
        }

        private void Update()
        {
            signDisplay.transform.localScale = active ? new Vector3(1, 1, 1) : new Vector3(1, 1, -1); 
            sign.material = active ? activeMaterial : baseMaterial;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player") || !active) return;
            ActivateNextPath();
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
