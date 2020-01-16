using Library.Character;
using Library.Character.Upgrades;
using Library.Combat.Enemy;
using Library.Tools;
using Library.UI;
using Sirenix.Utilities;
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
        public GameObject codeMenu;

        public bool pauseActive;
        private bool changedSpeed = false;
        private SpeedController con;
        private float _speed;

        private void Start()
        {
           // _speed = GameObject.FindGameObjectWithTag("Player").GetComponent<WaypointMovement>().moveSpeed;
           menuObject.SetActive(pauseActive);
           con = FindObjectOfType<SpeedController>();
        }

        private void Update()
        {
            Cursor.visible = pauseActive;
            Cursor.lockState = pauseActive ? CursorLockMode.None : CursorLockMode.Locked;
            if (!Input.GetKeyDown(KeyCode.F8)) return;
            TriggerMenu();
            codeMenu.SetActive(!codeMenu.activeSelf);
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void TriggerMenu()
        {
            menuObject.SetActive(!menuObject.activeSelf);
            pauseActive = !pauseActive;
            if (FindObjectOfType<Checkpoint.Checkpoint>().enemyAmount == 0)
            {
                con.path.ForEach(x => x.Speed = pauseActive ? 0 : con.speed);
            }

            if(!pauseActive)FindObjectOfType<Test>().Transi();
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
