/*
Alexander Barnes 101086806 Shrinking Platform Script, by Me
12/15/2020
Shrinks platform based off flag set by collision enter and exit, moves platform using lerp to go from point a - b, smooth step for smoother movement, and pingpong 
to move the platform back down and up again, also plays a sound when platform begins to shrink and begins to grow


*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingPlatform : MonoBehaviour
{
    [Header("Shrinking")]
    private bool playerOn;
    [Header("Bobbing")]
    public Transform dest;
    private Vector3 start;
    private Vector3 end;
    private float secondsForOneLength = 2f;
    [Header("Sounds")]
    public AudioSource shrink;
    public AudioSource grow;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        end = dest.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector3.Lerp(start, end,
        Mathf.SmoothStep(0f, 1f,
         Mathf.PingPong(Time.time / secondsForOneLength, 1f)
       ));
       
      

        if (playerOn)
        {
            Shrink();
        } else if (!playerOn)
        {
            Grow();
        }

    }

    public void Shrink()
    {
        if (transform.localScale.x > 0.0f)
        {
            transform.localScale -= new Vector3(0.001f, 0.001f, 0.0f);
           
        }
    }

    public void Grow()
    {
        if (transform.localScale.x < 1.0f)
        {
            transform.localScale += new Vector3(0.001f, 0.001f, 0.0f);
          
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
       if (other.gameObject.CompareTag("Player"))
        {
            playerOn = true;
            shrink.Play();
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            grow.Play();
            playerOn = false;
        }
    }
}
