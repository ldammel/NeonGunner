using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Library.Audio
{
    public class AudioSyncer : MonoBehaviour
    {
        public float bias;
        public float timeStep;
        public float timeToBeat;
        public float restSmoothTime;

        private float _previousAudioValue;
        private float _audioValue;
        private float _timer;

        protected bool IsBeat;
        
        private void Update()
        {
            OnUpdate();
        }
        
        public virtual void OnUpdate()
        {
           //Update audio value
           _previousAudioValue = _audioValue;
           _audioValue = AudioSpectrum.SpectrumValue;
           
           //If audio value went below or above the bias during this frame
           if ((_previousAudioValue > bias && _audioValue <= bias) || (_previousAudioValue <= bias && _audioValue > bias))
           {
               //if minimum beat interval is reached
               if (_timer > timeStep)
               {
                   OnBeat();
               }
           }

           _timer += Time.deltaTime;
        }
        
        public virtual void OnBeat()
        {
            _timer = 0;
            IsBeat = true;
        }

    }
}