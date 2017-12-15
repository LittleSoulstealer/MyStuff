using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Renderer))]


public class HighlightBehaviour : MonoBehaviour {
    private Renderer _Renderer;

	void Start () {
        StartCoroutine(Highlight(5));
	}

    private void Awake()
    {
        _Renderer = GetComponent<Renderer>();
    }
	
    private IEnumerator Highlight(float time)

    { 
        
            yield return new WaitForSeconds(1);
            var color = _Renderer.material.color;
            var startC = color * 5.0f;
            float t = 0.0f;
            while (t < 1.0f)
            {
                _Renderer.material.color = Color.Lerp(startC, color, t);
                t += Time.deltaTime/time;
                yield return null;
            }
        
        

        
       
    }
}

