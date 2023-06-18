using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPickUpItem : MonoBehaviour
{
    public Transform ItemHolderTransform;
    public int NumOfItemsHolding = 0;
    public void AddNewItem(Transform _itemToAdd,float _itemscale)
    {
        _itemToAdd.DOJump(ItemHolderTransform.position + new Vector3(0, 0.33f * NumOfItemsHolding, 0), 1.5f, 1, .25f).OnComplete(
        () => {
            _itemToAdd.SetParent(ItemHolderTransform, true);
            _itemToAdd.localPosition = new Vector3(0, .33f * NumOfItemsHolding, 0);
            _itemToAdd.localRotation = Quaternion.identity;
            _itemToAdd.localScale =new Vector3(_itemscale, _itemscale, _itemscale);
            NumOfItemsHolding++;
        }

        );
    }
}
