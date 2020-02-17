using System.Collections;
using TMPro;
using UnityEngine;

namespace Library.UI
{
    public class NotificationManager : MonoBehaviour
    {
        public static NotificationManager Instance
        {
            get
            {
                if (_instance!= null) return _instance;
                _instance = FindObjectOfType<NotificationManager>();
                return _instance!= null ? _instance : CreateNewInstance();
            }
        }
        private static NotificationManager _instance;
        private static NotificationManager CreateNewInstance()
        {
            var prefab = Resources.Load<NotificationManager>("Prefabs/Managers/NotificationManager");
            _instance = Instantiate(prefab);
            return _instance;
        }
        
        
        [SerializeField] private TextMeshProUGUI displayText;
        private IEnumerator _notificationCoroutine;

        private void Awake()
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        public void SetNewNotification(string message, float displayTime, Color color)
        {
            if (_notificationCoroutine != null) StopCoroutine(_notificationCoroutine);
            _notificationCoroutine = FadeOutNotification(message, displayTime, color);
            StartCoroutine(_notificationCoroutine);
        }

        private IEnumerator FadeOutNotification(string message, float time , Color color)
        {
            displayText.text = message;
            displayText.color = color;
            displayText.gameObject.SetActive(true);
            yield return  new WaitForSeconds(time);
            displayText.gameObject.SetActive(false);
        }
    }
}
