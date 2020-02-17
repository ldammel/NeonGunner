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

  private WaypointMovement _player;
  private float _baseSpeed;
  public bool tutorial;

  private void Start()
  {
   _player = GameObject.Find("---PLAYER---/Player").GetComponent<WaypointMovement>();
   _baseSpeed = _player.moveSpeed;
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

  private IEnumerator Tutorial()
  {
   _player.moveSpeed = 10;
   NotificationManager.Instance.SetNewNotification(notificationText, displayTime, color);
   yield return new WaitForSeconds(displayTime-2);
   _player.moveSpeed = _baseSpeed;
  }
 }
}
