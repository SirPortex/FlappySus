using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int points;
    public AudioClip pointSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.PlayAudio(pointSound, "PointSound", false, 0.08f);
            GameManager.instance.SetPoints(GameManager.instance.GetPoints() + points);
        }
    }
}
