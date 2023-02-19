using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side_Scrolling : MonoBehaviour
{
    
    MeshRenderer mesh;
    [SerializeField] float scrollSpedd = 1f;
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mesh.material.mainTextureOffset += new Vector2(scrollSpedd * Time.deltaTime,0);
    }
}
