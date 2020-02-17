using Library.Data;
using Sirenix.Utilities;
using TMPro;
using UnityEngine;

namespace Library.UI
{
    public class LoadHighscore : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI[] text;

        private void Update()
        {
            LoadScore();
        }

        public void LoadScore()
        {
            SaveData.Instance.LoadHighScore();
            if (SaveData.Instance.highscoreList.IsNullOrEmpty()) return;
            for (int i = 0; i < SaveData.Instance.highscoreList.Length; i++)
            {
                text[i].text = (i+1) + ": " + SaveData.Instance.highscoreList[i].username + " : " + SaveData.Instance.highscoreList[i].score + " : " + SaveData.Instance.highscoreList[i].level;
            }
        }

    }
}
