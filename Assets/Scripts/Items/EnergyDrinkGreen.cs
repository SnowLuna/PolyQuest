using UnityEngine;

[CreateAssetMenu(fileName = "Green Energy Drink (25 HP)", menuName = "Inventory/Item/Green Energy Drink (25 HP)")]
public class EnergyDrinkGreen : Item {

    [SerializeField]
    private int healthValue = 25;   //Couldve just made the field public but wanted to utilise the SerializeField at least once

    //Calls the recovery method in the character and removes the item from the inventory
    public override void Use()
    {
        base.Use(); //Derives from the Use method in Item 
        CharacterStats.instance.RecoverHealth(healthValue);
        RemoveFromInventory();
    }
}
