using System.Collections;
using Library.Character;
using UnityEngine;

namespace Library.UI
{
 public class NotificationTrigger : MonoBehaviour
 {
  [SerializeField] private string notificationText;
  [SerializeField] private float displayTime;
  [SerializeField] private Color color = Color.white;

  private WaypointMovement player;
  private float baseSpeed;
  public bool tutorial;

  private void Start()
  {
   player = GameObject.Find("---PLAYER---/Player").GetComponent<WaypointMovement>();
   baseSpeed = player.moveSpeed;
  }

  private void OnTriggerEnter(Collider other)
  {
   if (!other.CompareTag("Player")) return;
   if (tutorial)
   {
    StartCoroutine(Tutorial());
   }
   else NotificationManager.Instance.SetNewNotification(notificationText, displayTime, color);
  }

  IEnumerator Tutorial()
  {
   player.moveSpeed = 10;
   NotificationManager.Instance.SetNewNotification(notificationText, displayTime, color);
   yield return new WaitForSeconds(displayTime-2);
   player.moveSpeed = baseSpeed;
  }
 }
}
