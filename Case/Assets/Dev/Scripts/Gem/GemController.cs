using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{
    public bool isGrown;
    void Start()
    {
        isGrown = true;
        InvokeRepeating("GrowGem", 0f, 0.1f);
    }

    public void GrowGem()
    {
        if(isGrown)
        {
            if (transform.localScale.x < 1f)
            {
                transform.localScale += new Vector3(0.02f, 0.02f, 0.02f);
            }
            else
            {
                CancelInvoke("GrowGem");
            }
        }

        
    }
}
