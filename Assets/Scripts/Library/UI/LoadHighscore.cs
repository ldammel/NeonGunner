﻿using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Library.UI
{
    [ExecuteInEditMode]
    public class LoadHighscore : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text1;
        [SerializeField] private TextMeshProUGUI text2;
        [SerializeField] private TextMeshProUGUI text3;
        [SerializeField] private TextMeshProUGUI text4;
        [SerializeField] private TextMeshProUGUI text5;

        private void Start()
        {
            text1.text = "1: " + PlayerPrefs.GetString("HighScore1Name") + " - " + PlayerPrefs.GetFloat("HighScore1");
            text2.text = "2: " + PlayerPrefs.GetString("HighScore2Name") + " - " + PlayerPrefs.GetFloat("HighScore2");
            text3.text = "3: " + PlayerPrefs.GetString("HighScore3Name") + " - " + PlayerPrefs.GetFloat("HighScore3");
            text4.text = "4: " + PlayerPrefs.GetString("HighScore4Name") + " - " + PlayerPrefs.GetFloat("HighScore4");
            text5.text = "5: " + PlayerPrefs.GetString("HighScore5Name") + " - " + PlayerPrefs.GetFloat("HighScore5");
        }

        [Button("Reset Highscore")]
        public void ResetHighscore()
        {
            PlayerPrefs.SetFloat("HighScore1", 0);
            PlayerPrefs.SetFloat("HighScore2", 0);
            PlayerPrefs.SetFloat("HighScore3", 0);
            PlayerPrefs.SetFloat("HighScore4", 0);
            PlayerPrefs.SetFloat("HighScore5", 0);
            text1.text = "1: " + PlayerPrefs.GetString("HighScore1Name") + " - " + PlayerPrefs.GetFloat("HighScore1");
            text2.text = "2: " + PlayerPrefs.GetString("HighScore2Name") + " - " + PlayerPrefs.GetFloat("HighScore2");
            text3.text = "3: " + PlayerPrefs.GetString("HighScore3Name") + " - " + PlayerPrefs.GetFloat("HighScore3");
            text4.text = "4: " + PlayerPrefs.GetString("HighScore4Name") + " - " + PlayerPrefs.GetFloat("HighScore4");
            text5.text = "5: " + PlayerPrefs.GetString("HighScore5Name") + " - " + PlayerPrefs.GetFloat("HighScore5");
        }
    }
}