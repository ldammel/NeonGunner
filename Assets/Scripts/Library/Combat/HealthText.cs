using Library.Combat.Enemy;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace Library.Combat
{
    public class HealthText : MonoBehaviour
    {
        public TextMeshProUGUI text;
        public EnemyHealth eh;

        // Update is called once per frame
        void Update()
        {
            text.text = eh.curHealth + " / " +  eh.maxHealth;
        }
    }
}
