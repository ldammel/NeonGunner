using Library.Tools;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
 public int destroyTime;
 public string soundName;
 public bool destroy;
 private void Start()
 {
  if (!destroy) return;
  Destroy(this.gameObject,destroyTime);
 }

 private void OnEnable()
 {
  if (destroy) return;
  SoundManager.Instance.PlaySound(soundName);
 }
}
