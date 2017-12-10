using System.Collections.Generic;
using DefaultNamespace;
using UnityEditor;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Camera castCamera;
    public GameObject activeItem;
    public static Resolution currentResolution;
    public int widthResolution;
    public uint MaxSupportAgents = 5;

    private LinkedQueue<GameObject> supportAgents = new LinkedQueue<GameObject>();

    public void Start()
    {
        var rect = GetComponent<RectTransform>();
        widthResolution = Screen.width - (int)rect.rect.size.x;
    }

    public void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0) && activeItem != null && mousePos.x < widthResolution)
        {
            var worldpos = castCamera.ScreenToWorldPoint(
                new Vector3(mousePos.x, mousePos.y, castCamera.nearClipPlane));
            worldpos.y = 0;
            var item = Instantiate(activeItem);

            if (supportAgents.Count >= MaxSupportAgents)
            {
                GameObject oldestAgent = supportAgents.Dequeue();
                Destroy(oldestAgent);
            }
            supportAgents.Enqueue(item);
            
            item.transform.position = worldpos;
            activeItem = null;
        }
    }
}
