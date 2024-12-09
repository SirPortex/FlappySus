using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float pipeSpeed, currentTime, maxTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * pipeSpeed * Time.deltaTime; //Movemos la tuberia hacia la izquierda a una velocidad constante

        currentTime += Time.deltaTime; // iniciamos el contador
        if (currentTime >= maxTime) // si el tiempo actual supera el max time
        {
            currentTime = 0; // igualamos a 0 el contador
            gameObject.SetActive(false); //Se "devuelve" a la pool
        }
    }
}
