using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    // Start scene -> Option menu -> Volume settings
    //[SerializeField] private AudioSource audioSource;
    //[SerializeField] private Slider slider;
    public Slider volumeSlider;
    public AudioSource audioSource;

    private void Start()
    {
        // Ініціалізація слайдера та встановлення початкової гучності
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.5f);
        audioSource.volume = volumeSlider.value;

        // Додавання обробника події на зміну значення слайдера
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    private void ChangeVolume(float volume)
    {
        // Оновлення гучності аудіо
        audioSource.volume = volume;

        // Збереження значення гучності в PlayerPrefs
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
