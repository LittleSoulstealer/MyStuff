using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBehaviour : MonoBehaviour {

    [SerializeField] private float _Factor = 0.5f;


    public void Scale()
    {
        transform.localScale *= _Factor;

    }


    private void Receive(ActionMessage message)
    {
        Scale();

    }
    private void Awake()
    {
        MessageDispatcher.AddListner(this);
    }
}
