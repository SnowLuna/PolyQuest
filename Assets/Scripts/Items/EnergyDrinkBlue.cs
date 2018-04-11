using UnityEngine;

[CreateAssetMenu(fileName = "Blue Energy Drink (25 MP)", menuName = "Inventory/Item/Blue Energy Drink (25 MP)")]
public class EnergyDrinkBlue : Item {

    [SerializeField]
    private int manaValue = 25; //Couldve just made the field public but wanted to utilise the SerializeField at least once

    //Calls the recovery method in the character and removes the item from the inventory
    public override void Use()
    {
        base.Use(); //Derives from the Use method in Item 
        CharacterStats.instance.RecoverMana(manaValue);
        RemoveFromInventory();
    }
}