using Library.Combat.Enemy;
using TMPro;
using UnityEngine;

namespace Library.UI
{
    public class ScoreText : MonoBehaviour
    {
        public TextMeshProUGUI text;

        private int score;

        // Update is called once per frame
        void Update()
        {
            score = EnemySpawnController.totalKills;
            text.text = score + " Enemys Killed";
        }
    }
}
