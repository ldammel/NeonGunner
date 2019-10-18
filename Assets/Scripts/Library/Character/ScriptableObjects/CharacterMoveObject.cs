using Library.Base;
using UnityEngine;
using NaughtyAttributes;

    [CreateAssetMenu(menuName = "Character / MoveObject")]
    public class CharacterMoveObject : BaseScriptableObject
    {
        [BoxGroup("Speed")]
        public int horizontalSpeed;
        [BoxGroup("Speed")]
        public int verticalSpeed;
        
        [BoxGroup("Input Axis")]
        public string horizontalInputAxis;
        [BoxGroup("Input Axis")]
        public string verticalInputAxis;
        
        public void Move(Transform objectToMove)
        {
            var h = Input.GetAxis(horizontalInputAxis) * horizontalSpeed * Time.deltaTime;
            var v = Input.GetAxis(verticalInputAxis) * verticalSpeed * Time.deltaTime;
            objectToMove.transform.Translate(h,0,v);
        }
    }
