using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPluseTransform : MonoBehaviour
{
    [SerializeField] private Transform[] _spinLights;

    [SerializeField] private float[] _spinSpeeds;

    [SerializeField] private float _waveAmplitude = 0.05f;

    [SerializeField] private float _waveSpeed = 5f;

    [SerializeField] private float _waveOffset = 0.85f;

    //Rotates and varies spinlights behind button.
    private void Update()
    {
        for (int i = 0; i < _spinLights.Length; i++)
        {
            // Rotate
            Vector3 rotation = new Vector3();
            rotation.z = _spinSpeeds[i] * Time.deltaTime;
            _spinLights[i].Rotate(rotation);

            // Wave
            float wave = Mathf.Sin(Time.time * _waveSpeed) * _waveAmplitude + _waveOffset;
            Vector3 waveScale = new Vector3(wave, wave, wave);
            _spinLights[i].localScale = waveScale;
        }
    }
}
