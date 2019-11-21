using System;
using Library.Character;
using Library.Character.Upgrades;
using Library.Combat.Enemy;
using Library.Tools;
using Library.UI;
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
        public GameObject codeMenu;

        public bool pauseActive;
        private bool changedSpeed = false;
        private float _speed;

        private void Start()
        {
            _speed = GameObject.FindGameObjectWithTag("Player").GetComponent<WaypointMovement>().speed;
            pauseActive = false;
            menuObject.SetActive(false);
        }

        private void Update()
        {
            Cursor.visible = pauseActive;
            Cursor.lockState = pauseActive ? CursorLockMode.None : CursorLockMode.Locked;
            if (Input.GetKeyDown(KeyCode.F8))
            {
                TriggerMenu();
                codeMenu.SetActive(!codeMenu.activeSelf);
            }
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

        public void CheatCodes(string code)
        {
            switch (code)
            {
                case "motherlode" :
                    gameObject.GetComponent<UpgradeManager>().CheatMoney();
                    NotificationManager.Instance.SetNewNotification("Added 10000 Money!", 3);
                    SoundManager.Instance.PlaySound("Enabled");
                    return;
                case "blasphemy":
                    GameObject.FindGameObjectWithTag("Player").GetComponent<EnemyHealth>().godMode = !GameObject.FindGameObjectWithTag("Player").GetComponent<EnemyHealth>().godMode;
                    NotificationManager.Instance.SetNewNotification( GameObject.FindGameObjectWithTag("Player").GetComponent<EnemyHealth>().godMode ? "Godmode Activated" : "Godmode Deactivated", 3);
                    SoundManager.Instance.PlaySound(GameObject.FindGameObjectWithTag("Player").GetComponent<EnemyHealth>().godMode ? "Enabled" : "Disabled");
                    return;
                case "gottagofast":
                    if (!changedSpeed)
                    {
                        GameObject.FindGameObjectWithTag("Player").GetComponent<WaypointMovement>().SetSpeed(2);
                        NotificationManager.Instance.SetNewNotification("Speed Up!", 3);
                        SoundManager.Instance.PlaySound("Enabled");
                        changedSpeed = true;
                    }
                    else
                    {
                        GameObject.FindGameObjectWithTag("Player").GetComponent<WaypointMovement>().SetSpeed(-2);
                        NotificationManager.Instance.SetNewNotification("Slow Down!", 3);
                        SoundManager.Instance.PlaySound("Disabled");
                        changedSpeed = false;
                    }
                    return;
                case "kamikaze":
                    NotificationManager.Instance.SetNewNotification("KAMIKAZEE!", 3);
                    GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<EnemySpawnController>().SpawnEnemies(8);
                    SoundManager.Instance.PlaySound("Enabled");
                    return;
                default:
                    return;
            }
        }

    }
}
