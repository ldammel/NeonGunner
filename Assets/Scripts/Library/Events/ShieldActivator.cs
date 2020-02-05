using System;
using System.Collections;
using Library.Tools;
using UnityEngine;

public class ShieldActivator : MonoBehaviour
{
        [SerializeField] private GameObject shield;
        [SerializeField] private Transform shieldPos;
        [SerializeField] private float activeTime;

        private void Update()
        {
                if(Input.GetMouseButtonDown(0) && !shield.activeSelf) StartCoroutine(Activate());
        }

        IEnumerator Activate()
        {
                var sTransform = shield.transform;
                sTransform.position = shieldPos.position;
                sTransform.rotation = shieldPos.rotation;
                shield.SetActive(true);
                yield return new WaitForSeconds(activeTime);
                shield.SetActive(false);
        }
}
