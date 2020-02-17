using Library.Combat;
using Library.Events;
using UnityEngine;

namespace Library.Data
{
    public class WeaponSelector : MonoBehaviour
    {
        [SerializeField] private GameObject[] weapons;
        [SerializeField] private GameObject[] selectedGb;
        [SerializeField] private GameObject[] selectedArrow;
        [SerializeField] private GameObject selectedGo;
        public float transitionSpeed = 3f;
        public float targetPos;
        private Quaternion _prevRotation;
        private int _curWeapon;

        public void SelectWeapon(int index)
        {
            if(_curWeapon == index) return;
            for (int i = 0; i < weapons.Length; i++)
            {
                if (weapons[i].activeSelf) _prevRotation = i == 1 ? new Quaternion(0,0,0,0) : weapons[i].GetComponentInChildren<GunMovement>().gameObject.transform.rotation;
                weapons[index].GetComponentInChildren<GunMovement>().gameObject.transform.rotation = index == 1 ? new Quaternion(0,0,0,0) : _prevRotation;
                weapons[i].SetActive(i == index);
                selectedGb[i].SetActive(i == index);
                selectedArrow[i].SetActive(i == index);
            }
            _curWeapon = index;
        }

        private void Update()
        {
            if (PauseMenu.Instance.pauseActive) return;
            selectedGo.SetActive(PlayerPrefs.GetString("Difficulty") == "Hard");
            var transform1 = transform;
            var position = transform1.position;
            position = new Vector3(Vector3.Slerp(new Vector3(position.x, position.y,position.z), new Vector3(targetPos, position.y,position.z), transitionSpeed*Time.deltaTime).x, position.y,position.z);
            position = new Vector3(Mathf.Clamp(position.x ,-3,3), position.y,position.z);
            transform1.position = position;
        }

        public void SwitchLane(float amount)
        {
            targetPos += amount;
            targetPos = Mathf.Clamp(targetPos, -3, 3);
        }
    }    
}
