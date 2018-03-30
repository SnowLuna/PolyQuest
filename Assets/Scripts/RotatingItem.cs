using UnityEngine;

public class RotatingItem : MonoBehaviour {

    Inventory inventory;

	// Use this for initialization
	void Start() {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;
	}
	
	// Update is called once per frame
	void Update() {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * 50f));
	}

    void UpdateUI() {
        Debug.Log("UPDATING UI");
    }
}
