using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Library.UI
{
 public class NotificationTrigger : MonoBehaviour
 {
  [SerializeField] private string notificationText;
  [SerializeField] private float displayTime;

  private void OnTriggerEnter(Collider other)
  {
   if (!other.CompareTag("Player")) return;
   NotificationManager.Instance.SetNewNotification(notificationText, displayTime);
  }
 }
}
