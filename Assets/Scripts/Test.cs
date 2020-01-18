using Library.Combat;
using Library.Combat.Pooling;
using UnityEngine;
using Library.Events;
using Library.Tools;

public class Test : MonoBehaviour
{
    private void Update()
    {
        if (InputManager.Instance.KeyDown("options"))
        {
            PauseMenu.Instance.TriggerMenu();
        }
    }
}
