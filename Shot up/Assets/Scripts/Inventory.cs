using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	public GameObject activeItem;
	public static Resolution currentResolution;
	public int widthResolution;
	

		
	public void Start()
	{
		 //currentResolution= Screen.currentResolution;
		var rect = GetComponent<RectTransform>();
		 widthResolution= Screen.width - (int)rect.rect.size.x;
	}
	public void Update(){
		Vector2 mousePos = Input.mousePosition;
		if(Input.GetMouseButtonDown(0) && (activeItem != null) && (mousePos.x < widthResolution)){
			
			var worldpos = Camera.main.ScreenToWorldPoint(
				new Vector3(mousePos.x,mousePos.y, Camera.main.nearClipPlane));
			worldpos.y = 0;
			var item = Instantiate<GameObject>(activeItem);
			item.transform.position = worldpos;


			activeItem = null;
			Debug.Log(worldpos);
		}
	}
}
