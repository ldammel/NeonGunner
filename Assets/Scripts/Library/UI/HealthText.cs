using Library.Combat.Enemy;
using TMPro;
using UnityEngine;
namespace Library.UI
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
