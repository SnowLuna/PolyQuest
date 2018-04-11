using UnityEngine;

public class EquipmentManager : MonoBehaviour {

    #region Singleton
    public static EquipmentManager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    Equipment[] currentEquipment;
    Inventory inventory;
    SkinnedMeshRenderer[] currentMeshes;

    public Equipment[] defaultItems;
    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;
    public SkinnedMeshRenderer targetMesh;

    void Start()
    {
        inventory = Inventory.instance;
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
        currentMeshes = new SkinnedMeshRenderer[numSlots];
        EquipDefaultItems();
    }

    //Equips the item to the character and transforms the mesh of the character to prevent clipping issue
    public void Equip(Equipment newItem)
    {
        int slotIndex = (int) newItem.equipSlot;
        Equipment oldItem = Unequip(slotIndex);

        if (onEquipmentChanged != null)
            onEquipmentChanged.Invoke(newItem, oldItem);

        SetEquipmentBlendShapes(newItem, 100);
        currentEquipment[slotIndex] = newItem;

        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);
        newMesh.transform.parent = targetMesh.transform;
        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;
        currentMeshes[slotIndex] = newMesh;
    }

    //Unequip item, returns it to the inventory, the opposite of equip
    public Equipment Unequip(int slotIndex)
    {
        if(currentEquipment[slotIndex] != null)
        {
            if (currentMeshes[slotIndex] != null)
                Destroy(currentMeshes[slotIndex].gameObject);

            Equipment oldItem = currentEquipment[slotIndex];
            SetEquipmentBlendShapes(oldItem, 0);
            inventory.Add(oldItem);
            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
                onEquipmentChanged.Invoke(null, oldItem);

            return oldItem;
        }
        return null;
    }

    //Unequip all items
    public void UnequipAll()
    {
        for(int i = 0; i < currentEquipment.Length; i++)
            Unequip(i);
        EquipDefaultItems();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            UnequipAll();
    }

    //Makes the character skinnier so body mesh doesn't appear over clothing/equipment
    //Returns to normal when unequipping item
    void SetEquipmentBlendShapes(Equipment item, int weight)
    {
        foreach(EquipmentMeshRegion blendShape in item.coveredMeshRegions)
            targetMesh.SetBlendShapeWeight((int)blendShape, weight);
    }

    //Default equipment like undergarnment or clothing. Appears when no equipment used.
    void EquipDefaultItems()
    {
        foreach(Equipment item in defaultItems)
            Equip(item);
    }
}
