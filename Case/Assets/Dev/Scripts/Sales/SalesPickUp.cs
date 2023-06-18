using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalesPickUp : MonoBehaviour
{
    public Transform ItemHolderTransform;
    public Transform BagHolderTransform;

    public SalesGoldCount salesGoldCount;

    int NumOfItemsBank = 0;

    [SerializeField]
    CharacterPickUpItem characterPickUpItem;


    public void RemoveItem(Transform _itemToRemove)
    {
        _itemToRemove.DOJump(BagHolderTransform.position + new Vector3(0, 0.33f * NumOfItemsBank, 0), 1.5f, 1, .25f).OnComplete(
            () => {
                _itemToRemove.SetParent(BagHolderTransform, true);
                _itemToRemove.localPosition = new Vector3(0, .33f * NumOfItemsBank, 0);
                _itemToRemove.localRotation = Quaternion.identity;

                salesGoldCount.salesGem(_itemToRemove.localScale.x, _itemToRemove.name);
                characterPickUpItem.NumOfItemsHolding--;

                Debug.Log(_itemToRemove.name);

            }
            );

    }
}
