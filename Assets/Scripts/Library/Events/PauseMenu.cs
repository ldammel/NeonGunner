using UnityEngine;

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

        public AudioSource audio;

        public bool pauseActive;

        private void Start()
        {
            menuObject.SetActive(pauseActive);
        }

        private void Update()
        {
            Cursor.visible = pauseActive;
            Cursor.lockState = pauseActive ? CursorLockMode.None : CursorLockMode.Locked;
            if (pauseActive)
            {
                audio.Pause();
            }
            else audio.UnPause();
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void TriggerMenu()
        {
            menuObject.SetActive(!menuObject.activeSelf);
            pauseActive = !pauseActive;
        }
    }
}
