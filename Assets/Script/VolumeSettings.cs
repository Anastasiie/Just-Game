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
        // ����������� �������� �� ������������ ��������� �������
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.5f);
        audioSource.volume = volumeSlider.value;

        // ��������� ��������� ��䳿 �� ���� �������� ��������
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    private void ChangeVolume(float volume)
    {
        // ��������� ������� ����
        audioSource.volume = volume;

        // ���������� �������� ������� � PlayerPrefs
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
