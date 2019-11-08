using UnityEngine;
namespace Library.Base
{
    public abstract class BaseScriptableObject : ScriptableObject
    {
        [HideInInspector]public string Name;
        [HideInInspector]public float BaseValue;
    }
}
