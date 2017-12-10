using UnityEngine;

public class ItemScript : MonoBehaviour {
	public GameObject itemPrefab;
	public Inventory inventory;

	public void OnClick(){
		inventory.activeItem = itemPrefab;
	}
}
