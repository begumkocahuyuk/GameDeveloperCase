using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CharacterGiveItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

       if (other.CompareTag("Sales"))
       {
            SalesPickUp salesPickUp;
            if (other.TryGetComponent(out salesPickUp))
            {
                salesPickUp.RemoveItem(this.transform);

            }
       }

    }
}
