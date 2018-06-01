using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public void SoundFX(AudioClip sound,Vector3 position) {
        AudioSource.PlayClipAtPoint(sound,position);
    }

    public void SoundBGMap(AudioClip sound,Vector3 position) {
        AudioSource.PlayClipAtPoint(sound,position);
    }

}









// new className.MethodName();