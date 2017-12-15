using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActionMessage
{ }
public class Player : MonoBehaviour {

    

    [SerializeField] private KeyCode _ActionKey = KeyCode.F;
    
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(_ActionKey))
        {
            _Action();
        }
	}

    private void _Action()
    {
        var action = new ActionMessage();
        
        MessageDispatcher.Send(action);
        
    }
    private void ReceivePause( PausedMessage paused)
    {
        gameObject.SetActive(false);
    }

    private void ReceiveUnPause(UnPausedMessage unpaused)
    {
        gameObject.SetActive(true);
    }

    private void Awake()
    {
        MessageDispatcher.AddListner(this);
    }
}
