using System;
using System.Collections;
using System.Collections.Generic;
using Library.Events;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public SceneSwitch sceneSwitch;
    public float duration;
    public Image image;

    private bool _ready;

    private void Start()
    {
        StartCoroutine(FadeTo(1, duration));
    }

    private void Update()
    {
        if(image.color.a >= 0.9) StartCoroutine(FadeTo(0, duration));
        if(image.color.a <= 0.01 && _ready) sceneSwitch.SwitchScene();
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = image.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha,aValue,t));
            image.color = newColor;
            _ready = true;
            yield return null;
        }
    }
    
}
