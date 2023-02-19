using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
   [SerializeField] GameObject PipePrefab;

   [SerializeField] float spawnRate = 1f;
   [SerializeField] float minHeight = -1f;
   [SerializeField] float maxHeight = 1f;
   [SerializeField] float minVarinace = 0.5f;

   private Vector3 previousPosition;
    private void OnEnable() 
   {
      InvokeRepeating(nameof(Spawn),spawnRate,spawnRate);
   }

private void OnDisable()
{
       CancelInvoke(nameof(Spawn));
}
   private void Spawn()
   {
         GameObject pipes = Instantiate(PipePrefab,transform.position,Quaternion.identity);
         if(previousPosition.y > 0f)
        {
          pipes.transform.position += Vector3.up *(Random.Range(minHeight,-minVarinace));
        }
        else
        {
         pipes.transform.position += Vector3.up * (Random.Range(minVarinace,maxHeight));
        }
        previousPosition = pipes.transform.position; 
   }
    
}
