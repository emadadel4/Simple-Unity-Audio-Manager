﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JSAM; // Using the namespace to make things easier to type out

public class LoopPointExample : MonoBehaviour
{
    [SerializeField] JSAMMusicFileObject music;

    [SerializeField] AudioPlayerMusic player;

    [SerializeField] UnityEngine.UI.Slider progressSlider = null;

    [SerializeField] UnityEngine.UI.Text buttonText = null;

    AudioSource sourceToTrack;

    public void CheckTheFile()
    {
#if UNITY_EDITOR
        UnityEditor.Selection.activeObject = music;
#endif
    }

    public void Update()
    {
        if (sourceToTrack != null)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                sourceToTrack.time = Mathf.Clamp(sourceToTrack.time - 5f, 0, sourceToTrack.clip.length - 0.01f);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                sourceToTrack.time = Mathf.Clamp(sourceToTrack.time + 5f, 0, sourceToTrack.clip.length - 0.01f);
            }
            progressSlider.value = sourceToTrack.time / sourceToTrack.clip.length;
        }
        else
        {
            if (player.MusicHelper)
            {
                sourceToTrack = player.MusicHelper.AudioSource;
            }
        }
    }
}
