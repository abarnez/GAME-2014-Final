using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingPlatform : MonoBehaviour
{
    private bool PlayerOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x,
         groundLevel.y + Mathf.PingPong(Time.time, 1), 0.0f);
        if (PlayerOn)
        {
            Shrink();
        } else if (!PlayerOn)
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
            PlayerOn = true;
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerOn = false;
        }
    }
}
