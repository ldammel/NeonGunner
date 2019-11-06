using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Library.Events
{
    public class PauseMenu : MonoBehaviour
    {
        public static PauseMenu Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("There must only be one Pause Menu in the Scene!");
                Application.Quit();
            }

            Instance = this;
        }

        [SerializeField] private GameObject menuObject;

        public bool pauseActive;

        private void Start()
        {
            pauseActive = false;
            menuObject.SetActive(false);
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void TriggerMenu()
        {
            menuObject.SetActive(!menuObject.activeSelf);
            pauseActive = !pauseActive;
            Cursor.visible = pauseActive;
            Cursor.lockState = pauseActive ? CursorLockMode.None : CursorLockMode.Locked;
        }

    }
}
