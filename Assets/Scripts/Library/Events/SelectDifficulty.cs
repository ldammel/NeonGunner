using UnityEngine;

namespace Library.Events
{
    public class SelectDifficulty : MonoBehaviour
    {
        public void DifMode(string mode)
        {
            PlayerPrefs.SetString("Difficulty", mode);
        }
    }
}
