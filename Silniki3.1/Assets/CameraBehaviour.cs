using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

[RequireComponent(typeof (PostProcessingBehaviour))]
public class CameraBehaviour : MonoBehaviour {

    private void ReceivePaused(PausedMessage paused)
    {
        SetSaturation(0.0f);
    }


    private void Awake()
    {
        MessageDispatcher.AddListner(this);
    }
    private void ReceiveUnPaused(UnPausedMessage paused)
    {
        SetSaturation(1.0f);
    }

    private void SetSaturation (float value)
    {
        var behaviour = GetComponent<PostProcessingBehaviour>();
   
        var grading = behaviour.profile.colorGrading;
        var settings = grading.settings;
        settings.basic.saturation = value;
        grading.settings = settings;
    }

    private void OnApplicationQuit()
    {
        SetSaturation(1.0f);
    }
}
