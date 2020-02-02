using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToActivate;

    public void ActivateObjects()
    {
        objectsToActivate.ForEach(x => x.SetActive(true));
    }
}
