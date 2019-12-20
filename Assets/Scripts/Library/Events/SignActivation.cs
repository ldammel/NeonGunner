using System;
using BansheeGz.BGSpline.Curve;
using Library.Character;
using UnityEngine;

namespace Library.Events
{
    public class SignActivation : MonoBehaviour
    {
        [SerializeField] private BGCurve path; 
        [SerializeField] private BGCurve mainPath;
        [SerializeField] private GameObject[] deactivate;
    }
}
