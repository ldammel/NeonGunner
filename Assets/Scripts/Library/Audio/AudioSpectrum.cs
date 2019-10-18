using UnityEngine;

namespace Library.Audio
{
    public class AudioSpectrum : MonoBehaviour
    {
        private float[] _audioSpectrum;
        public static float SpectrumValue { get; private set; }

        void Start()
        {
            //Initialize the buffer
            _audioSpectrum = new float[64];
        }
        
        void Update()
        {
            //Get the spectrum data
            AudioListener.GetSpectrumData(_audioSpectrum, 0, FFTWindow.Hamming);
            
            //assign spectrum value
            if (_audioSpectrum != null && _audioSpectrum.Length > 0)
            {
                SpectrumValue = _audioSpectrum[0] * 100;
            }

        }
    }
}
