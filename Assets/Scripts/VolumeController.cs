using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField]
    private Slider _volumeSlider;

    public void OnVolumeChanged()
    {
        AudioListener.volume = _volumeSlider.value;
    }
}
