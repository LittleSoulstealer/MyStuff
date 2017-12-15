using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingActiveOnPause : MonoBehaviour {

    [SerializeField] private bool _Invert;

    private void ReceivePause(PausedMessage paused)
    {
    
        gameObject.SetActive(_Invert);
    }

    private void ReceiveUnPause(UnPausedMessage unpaused)
    {
        gameObject.SetActive(!_Invert);
    }
    private void Awake()
    {
        MessageDispatcher.AddListner(this);
    }
}
