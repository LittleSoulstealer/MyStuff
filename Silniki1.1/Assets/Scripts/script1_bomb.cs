using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script1_bomb : MonoBehaviour {

    #region Inspected Variables
    [SerializeField]private float _Radius=10.0f;
    [SerializeField]private float _Time=3.0f;
    [SerializeField]private float _Force=400.0f;
    [SerializeField] private AudioSource _AudioSrc;
    private float acc;

    #endregion


    #region Unity Methods


	void Update () {

    
	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,_Radius);

    }

    #endregion

    #region PrivateMethods
    public void Activate()
    {
        _AudioSrc.Play();
        Destroy(gameObject,0.5f);
        var colliders = Physics2D.OverlapCircleAll(transform.position, _Radius);
  

        foreach(var collider in colliders)
        {
            var rb = collider.GetComponent<Rigidbody2D>();
            if (rb == null)
            {
                continue;
            }

            
            var vector = collider.transform.position - transform.position;
            var direction = vector.normalized;
            var lenght = vector.magnitude;

       
            var force = direction *Mathf.Pow(1.0f/(lenght+1.0f), 2.0f)* _Force;

            rb.AddForce(force, ForceMode2D.Impulse);
        }
    }
#endregion
}
