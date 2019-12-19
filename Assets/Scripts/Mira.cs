using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mira : MonoBehaviour
{
    private Vector2 mousePos;
    public Camera cam;

    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = mousePos;
    }
}
