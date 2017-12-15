using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PausedMessage { }

public class UnPausedMessage { }
public class PauseController : MonoBehaviour {

    [SerializeField] private KeyCode _PauseKey = KeyCode.P;
    private bool _Paused = false;
    // Use this for initialization
   
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(_PauseKey))
        {
            if (_Paused == false)
            {
                _Pause();
            }
            else
            {
                _Unpause();
            }
        }
	}

    void _Pause()
    
    {
        _Paused = true;
        Debug.Log("Game Paused");
        var paused = new PausedMessage();
        MessageDispatcher.Send(paused);

       
    }

    void _Unpause()
    {
        _Paused = false;
        Debug.Log("Game Unpaused");
        var unpaused = new UnPausedMessage();
        MessageDispatcher.Send(unpaused);
    }


    private void Awake()
    {
        MessageDispatcher.AddListner(this);
    }
}
