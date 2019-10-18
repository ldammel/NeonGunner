using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Library.Audio
{
    [RequireComponent(typeof(Image))]
    public class AudioSyncColor : AudioSyncer
    {
        public Color[] beatsColor;
        public Color restColor;

        private int _randomIndex;
        private Image _img;

        private void Start()
        {
            _img = GetComponent<Image>();
        }

        public override void OnBeat()
        {
            base.OnBeat();
            Color c = RandomColor();
            
            StopCoroutine(MoveToColor(c));
            StartCoroutine(MoveToColor(c));
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (IsBeat) return;

            _img.color = Color.Lerp(_img.color, restColor, restSmoothTime * Time.deltaTime);
        }

        private Color RandomColor()
        {
            if (beatsColor == null || beatsColor.Length == 0) return Color.white;
            _randomIndex = Random.Range(0, beatsColor.Length);
            return beatsColor[_randomIndex];
        }

        private IEnumerator MoveToColor(Color target)
        {
            Color cur = _img.color;
            Color initial = cur;
            float timer = 0;

            while (cur != target)
            {
                cur = Color.Lerp(initial, target, timer / timeToBeat);
                timer += Time.deltaTime;
                _img.color = cur;
                yield return null;
            }

            IsBeat = false;
        }
    }
}
