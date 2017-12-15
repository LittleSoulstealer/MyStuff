using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class CameraFollow : MonoBehaviour {

    #region Inspector Variables
    [SerializeField] private Transform _Transform;
    #endregion Inspector Variables

    #region Private Variables
    private Vector3 _Offset;
#endregion

    #region Unity Methods
    private void Awake()
    {
        _Offset = transform.position - _Transform.position;
    

    }

    private void LateUpdate()
    {
        transform.position = _Transform.position + _Offset;
        
    }
    #endregion 




}
