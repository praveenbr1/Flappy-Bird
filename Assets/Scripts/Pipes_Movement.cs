using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes_Movement : MonoBehaviour
{ 
   [SerializeField] float speed = 5f;  
    private float screenBounds;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
        
    }

    private void Update() 
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if(transform.position.x < screenBounds - 2f)
        {
            Destroy(gameObject);
        }
    }
}
