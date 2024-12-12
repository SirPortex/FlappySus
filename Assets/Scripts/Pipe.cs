using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pipe : MonoBehaviour
{
    public float pipeSpeed, currentTime, maxTime, deathTime, resetTime;

    public Material pipeMaterial;

    public AudioClip fallingSound;


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
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<FlappyController>())
        {
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(0.5f);
        AudioManager.instance.PlayAudio(fallingSound, "FallingSound", false, 0.12f);
        yield return new WaitForSeconds(2);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.instance.LoadScene("Game");
        AudioManager.instance.ClearAudio();
        
    }

}
