using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeUp : MonoBehaviour
{

    public AudioClip fallingSound;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FlappyController>())
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
