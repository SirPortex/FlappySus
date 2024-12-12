using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public float speed, currentTime, maxTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        transform.position += Vector3.down * speed * Time.deltaTime;

        if(currentTime >= maxTime)
        {
            speed = 0;
            currentTime = 0;
        }

    }



}
