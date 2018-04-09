using UnityEngine;

[CreateAssetMenu(fileName = "Green Energy Drink (25 HP)", menuName = "Inventory/Item/Green Energy Drink (25 HP)")]
public class EnergyDrinkGreen : Item {

    [SerializeField]
    private int healthValue = 25;

    public override void Use()
    {
        base.Use();
        CharacterStats.instance.RecoverHealth(healthValue);
        RemoveFromInventory();
    }
}
