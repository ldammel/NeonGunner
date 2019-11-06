using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Library.Events
{
    public class SceneSwitch : MonoBehaviour
    {
        [SerializeField] private string sceneName;

        public void SwitchScene()
        {
            SceneManager.LoadScene(sceneName);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
