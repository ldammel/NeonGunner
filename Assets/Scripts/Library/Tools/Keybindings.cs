using Library.Base;
using UnityEngine;

namespace Library.Tools
{
    [CreateAssetMenu (fileName = "Keybindings", menuName = "Keybindings/New Keybindings")]
    public class Keybindings : BaseScriptableObject
    {
        public KeyCode flak, flame, mg, options;

        public KeyCode CheckKey(string key)
        {
            switch (key)
            {
                case "mg":
                    return mg;
                case "flak":
                    return flak;
                case "flame":
                    return flame;
                case "options":
                    return options;
                default:
                    Debug.LogError(key + " is not a Valid Key!");
                    return KeyCode.None;
            }
        }
    }
}
