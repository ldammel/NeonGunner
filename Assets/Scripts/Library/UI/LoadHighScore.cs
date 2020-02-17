using Library.Data;
using Sirenix.Utilities;
using TMPro;
using UnityEngine;

namespace Library.UI
{
    public class LoadHighScore : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI[] text;

        private void Update()
        {
            LoadScore();
        }

        private void LoadScore()
        {
            SaveData.Instance.LoadHighScore();
            if (SaveData.Instance.highScoreList.IsNullOrEmpty()) return;
            for (int i = 0; i < SaveData.Instance.highScoreList.Length; i++)
            {
                text[i].text = (i+1) + ": " + SaveData.Instance.highScoreList[i].username + " : " + SaveData.Instance.highScoreList[i].score + " : " + SaveData.Instance.highScoreList[i].level;
            }
        }

    }
}
