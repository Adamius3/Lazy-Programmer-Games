using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/*
 * Coded by:
 * Timothy Garcia 300898955
 */
public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    //Method to set volume
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        Debug.Log(volume);
    }
}
