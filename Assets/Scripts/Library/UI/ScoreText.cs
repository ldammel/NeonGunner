using Library.Combat.Enemy;
using TMPro;
using UnityEngine;

namespace Library.UI
{
    public class ScoreText : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI text;
        [SerializeField]
        private ushort neededAmount;

        private ushort score;
        

        // Update is called once per frame
        void Update()
        {
            score = EnemySpawnController.totalKills;
            text.text = score + " / " + neededAmount;
        }
    }
}
