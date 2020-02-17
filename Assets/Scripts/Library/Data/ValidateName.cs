using System.Linq;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace Library.Data
{
    public class ValidateName : MonoBehaviour
    {
        [SerializeField] private string[] badWords;

        [SerializeField] private GameObject[] enableObjects;
        [SerializeField] private GameObject[] disableObjects;
        [SerializeField] private Image disableImage;
        [SerializeField] private GameObject badWordWarning;
        [SerializeField] private GameObject tooShortWarning;
        [SerializeField] private GameObject tooLongWarning;

        public void ValidateInputName(string username)
        {
            Debug.Log("started validation on: "+ username);
            badWordWarning.SetActive(false);
            tooShortWarning.SetActive(false);
            if (username.IsNullOrWhitespace() || username.Length < 2)
            {
                tooShortWarning.SetActive(true);
                return;
            }
            if (username.Length > 14)
            {
                tooLongWarning.SetActive(true);
                return;
            }
            if (badWords.Any(username.Contains))
            {
                badWordWarning.SetActive(true);
                return;
            }

            disableImage.enabled = false;
            enableObjects.ForEach(x => x.SetActive(true));
            disableObjects.ForEach(x => x.SetActive(false));
            SaveData.Instance.SaveHighScore(username);
        }

    }
}
