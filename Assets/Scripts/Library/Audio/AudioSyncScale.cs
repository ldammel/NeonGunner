using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Library.Audio
{
    public class AudioSyncScale : AudioSyncer
    {
        public Vector3 beatScale;
        public Vector3 restScale;
        
        public override void OnBeat()
        {
            base.OnBeat();

            StopCoroutine(MoveToScale(beatScale));
            StartCoroutine(MoveToScale(beatScale));
        }
        
        public override void OnUpdate()
        {
            base.OnUpdate();

            if (IsBeat) return;

            transform.localScale = Vector3.Lerp(transform.localScale, restScale, restSmoothTime * Time.deltaTime);
        }
        
        private IEnumerator MoveToScale(Vector3 target)
        {
            Vector3 curr = transform.localScale;
            Vector3 initial = curr;
            float timer = 0;

            while (curr != target)
            {
                curr = Vector3.Lerp(initial, target, timer / timeToBeat);
                timer += Time.deltaTime;

                transform.localScale = curr;

                yield return null;
            }

            IsBeat = false;
        }
    }
}
