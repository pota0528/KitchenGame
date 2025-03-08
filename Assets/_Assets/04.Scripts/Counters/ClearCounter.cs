using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // 아무 부엌 오브젝트 없음.
            if (player.HasKitchenObject())
            {
                // 플레이어가 무언가 옮김.
                player.GetkitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                // 플레이어가 아무것도 옮기고 있지 않음.
            }
        }
        else
        {
            // 부엌 오브젝트 있음.
            if (player.HasKitchenObject())
            {
                // 플레이어가 뭔가 옮기는중.
                if (player.GetkitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    // 플레이어가 접시를 잡고 있음.
                    if (plateKitchenObject.TryAddIngredient(GetkitchenObject().GetKitchenObjectSO()))
                    {
                        GetkitchenObject().DestroySelf();
                    }
                }
                else
                {
                    // 플레이어가 접시가 아닌 다른걸 옮기는 중.
                    if (GetkitchenObject().TryGetPlate(out plateKitchenObject))
                    {
                        // 카운터에 접시가 놓여있음.
                        if (plateKitchenObject.TryAddIngredient(player.GetkitchenObject().GetKitchenObjectSO()))
                        {
                            player.GetkitchenObject().DestroySelf();
                        }
                    }
                }
            }
            else
            {
                // 플레이어가 아무것도 옮기고 있지 않음.
                GetkitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
