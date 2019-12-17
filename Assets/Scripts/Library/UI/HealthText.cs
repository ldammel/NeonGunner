using Library.Combat.Enemy;
using UnityEngine;
using UnityEngine.UI;

namespace Library.UI
{
    public class HealthText : MonoBehaviour
    {
        public Image healthImage;
                                      public EnemyHealth eh;

        // Update is called once per frame
        void Update()
        {
            healthImage.fillAmount = eh.curHealth / eh.maxHealth;
        }
    }
}
