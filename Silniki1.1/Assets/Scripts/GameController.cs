using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameController : MonoBehaviour
{


    [SerializeField] private GameObject _Template;
    [SerializeField] private int _BombCount = 3;
    [SerializeField] private List<script1_bomb> _Bombs;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {
        CreatingBomb();
        if (_BombCount == _Bombs.Count)
        {
            foreach (var b in _Bombs)
            {
                b.Activate();
                
            }
            Destroy(gameObject);
          
        }
        
    }


    void CreatingBomb()
    {
        if (_BombCount > _Bombs.Count)
        {
            if (Input.GetMouseButtonDown(0))

            {
                var point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                point.z = -5;
                Debug.Log("Clicked");
                GameObject bomb = Instantiate(_Template, point, Quaternion.identity)as GameObject;

                var bombScript = bomb.GetComponent<script1_bomb>();

                _Bombs.Add(bombScript);
            }
        }
    }
}
