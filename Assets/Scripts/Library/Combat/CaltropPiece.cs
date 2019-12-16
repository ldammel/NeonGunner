using System;
using System.Collections;
using UnityEngine;

namespace Library.Combat
{
    public class CaltropPiece : MonoBehaviour
    {
        [SerializeField] private GameObject vfx;
        [SerializeField] private float timeUntilDelete;

        private Rigidbody rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            StartCoroutine(StartForce());
        }

        IEnumerator StartForce()
        {
            yield return new WaitForSeconds(0.2f);
            vfx.SetActive(true);
            Destroy(gameObject, timeUntilDelete);
        }

    }
}
