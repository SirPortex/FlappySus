using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
     public GameObjectPool pipePool;

    public float maxTime, heightRange, currentTime;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {

        if( currentTime >= maxTime )
        {
            SpawnPipe();
            currentTime = 0;
        }
        currentTime += Time.deltaTime;
    }
    
    public void SpawnPipe()
    {
        GameObject obj = pipePool.GimmeInactiveGameObject();
        if (obj)
        {
            obj.SetActive(true);
            obj.transform.position = transform.position; // La nueva posicion es la del generador 
            obj.transform.position += new Vector3(0, Random.Range(-heightRange, heightRange),0);
        }
    }
}
