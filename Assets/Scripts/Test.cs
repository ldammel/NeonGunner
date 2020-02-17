using System.Collections;
using Library.Data;
using UnityEngine;
using Library.Events;
using Library.Tools;

public class Test : MonoBehaviour
{
    [SerializeField] private WeaponSelector selector;
    [SerializeField] private GameObject qImage;
    [SerializeField] private GameObject eImage;
    
    

    private void Start()
    {
        selector = GameObject.Find("---PLAYER---/Player").GetComponent<WeaponSelector>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.Instance.TriggerMenu();
        }

        if (PauseMenu.Instance.pauseActive) return;if (LevelManager.Instance.winScreen.activeSelf) return;
        
        if (Input.GetMouseButtonDown(0))
        {
            selector.SelectWeapon(0);
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (PlayerPrefs.GetString("Difficulty") == "Easy" ||
                PlayerPrefs.GetString("Difficulty") == "Medium") return;
            selector.SelectWeapon(1);
        }
        if (SpawnNextPatternManager.Instance.levelNumber < 14) return;
        if (Input.GetKeyDown(KeyCode.A))
        {
            selector.SwitchLane(-3);
            qImage.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            qImage.SetActive(false);
        }  
        if (Input.GetKeyDown(KeyCode.D))
        {
            selector.SwitchLane(3);
            eImage.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            eImage.SetActive(false);
        } 
    }
}
