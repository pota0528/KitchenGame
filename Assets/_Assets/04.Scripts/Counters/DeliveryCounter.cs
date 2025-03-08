using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public static DeliveryCounter Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
        {
            if (player.GetkitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
            {
                // 접시들만 낼 수 있음.
                
                DeliveryManager.Instance.DeliverRecipe(plateKitchenObject);
                
                player.GetkitchenObject().DestroySelf();
            }
        }
    }
}
