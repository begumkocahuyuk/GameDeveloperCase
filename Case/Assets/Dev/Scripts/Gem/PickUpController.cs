using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    Grid grid;
    private Vector3 scaleGem,gem;

    private void Start()
    {
        gem = new Vector3(0.25f, 0.25f, 0.25f);
    }
    private void OnTriggerEnter(Collider other)
    {
        bool isALreadyColledted = false;
        scaleGem = transform.localScale;
        if (other.gameObject.tag == "Character")
        {
            if (isALreadyColledted) return;
            if (scaleGem.x>=gem.x)
            {
                CharacterPickUpItem characterController;
                GemController gemController;
                gemController= GetComponent<GemController>();

                int t = (int)transform.position.z - 1;
                if (other.TryGetComponent(out characterController))
                {
                    Debug.Log("X"+(int)transform.position.x +"Z:"+ t);

                    characterController.AddNewItem(this.transform,this.transform.localScale.x);
                    grid = FindObjectOfType<Grid>();
                    //Debug.Log((int)other.transform.position.x);
                    //Debug.Log((int)other.transform.position.z);

                    grid.newGem((int)transform.position.x, t);
                    gemController.isGrown = false;
                    isALreadyColledted = true;

                }

            }


        }
    }
}
