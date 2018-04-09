using UnityEngine;

[CreateAssetMenu(fileName = "Blue Energy Drink (25 MP)", menuName = "Inventory/Item/Blue Energy Drink (25 MP)")]
public class EnergyDrinkBlue : Item {

    [SerializeField]
    private int manaValue = 25;

    public override void Use()
    {
        base.Use();
        CharacterStats.instance.RecoverMana(manaValue);
        RemoveFromInventory();
    }
}