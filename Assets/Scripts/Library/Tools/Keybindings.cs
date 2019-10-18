using Library.Base;
using UnityEngine;

namespace Library.Tools
{
    [CreateAssetMenu (fileName = "Keybindings", menuName = "Keybindings/New Keybindings")]
    public class Keybindings : BaseScriptableObject
    {
        public KeyCode jump, fire, interact, pause, inventory;

        public KeyCode CheckKey(string key)
        {
            switch (key)
            {
                case "jump":
                    return jump;
                case "fire":
                    return fire;
                case "interact":
                    return interact;
                case "pause":
                    return pause;
                case"inventory":
                    return inventory;
                default:
                    Debug.LogError(key + " is not a Valid Key!");
                    return KeyCode.None;
            }
        }
    }
}
