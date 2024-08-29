using System.Generic;
using System.Generic.Collections;
using UnityEngine;


public class PipeIncreaseScore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == null)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                Score.instance.UpdateScore()
            }
        }
    }
}