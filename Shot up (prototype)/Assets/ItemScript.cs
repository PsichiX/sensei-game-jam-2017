using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour {
	public GameObject itemPrefab;
	public Inventory inventory;

	public void OnClick(){
		Debug.Log("dupa");
		inventory.activeItem = itemPrefab;
	}
}
