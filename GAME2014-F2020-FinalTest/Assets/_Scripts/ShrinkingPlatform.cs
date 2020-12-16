using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingPlatform : MonoBehaviour
{
    private bool playerOn;
    public Transform dest;
    private Vector3 start;
    private Vector3 end;
    private float secondsForOneLength = 2f;
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
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOn = false;
        }
    }
}
