using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingParticleController : MonoBehaviour {

    public Transform affector;

    private ParticleSystemRenderer psr;

	void Start () {
        psr = GetComponent<ParticleSystemRenderer>();
        if(affector == null)affector = GameObject.Find("---PLAYER---/Player/particle").transform;
	}
	
	void Update () {
        psr.material.SetVector("_Affector", affector.position);
    }
}
