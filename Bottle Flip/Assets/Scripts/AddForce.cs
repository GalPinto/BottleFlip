using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class AddForce : MonoBehaviour {

    public GameObject Bottle;
    public GameObject myCanvas;
    public GameObject BottleTop;
    public Camera MainCamera;
    Rigidbody rb;
    public Transform BottleTopTransform;
    float pow = 0.4f;
    public Transform t;
    public Transform tTop;
    public CanvasScaler scaler;
    private Vector3 start;
    private Vector3 end;
    private Vector3 force;
    private Vector3 bottlePos;
    private float ratio = 0.3f;

    void Awake()
    {
        rb = Bottle.GetComponent<Rigidbody>();
        t = Bottle.GetComponent<Transform>();
        BottleTopTransform = Bottle.transform.Find("Cylinder002");
        scaler = myCanvas.GetComponent<CanvasScaler>();
        tTop = BottleTop.GetComponent<Transform>();
    }
    public void Text_Changed(string newText)
    {
        pow = float.Parse(newText);
    }
    public void ThrowObjectWithForce()
    {
        Vector3 pos = new Vector3(0, 1, 0.3f);
        //rb.AddForce(pos * power);
        force.x = 0;
        force.y = (end.y - start.y);
        force.z = force.y*0.3f;
        Debug.Log(force);
        rb.AddForceAtPosition(force * pow, Vector3.forward * 5);
        //rb.AddForceAtPosition(Vector3.up * 50, t.position);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            start = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            end = Input.mousePosition;
            ThrowObjectWithForce();
        }
        if (Input.GetMouseButton(0))
        {
            HoldBottle();
            rb.useGravity = false;
        }
        else
            rb.useGravity = true;
        //Vector3 temp = new Vector3();
        //Debug.DrawLine(BottleTopTransform.position,temp);
    }

    public void HoldBottle()
    {
        
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, MainCamera , out pos);
        Vector3 position = myCanvas.transform.TransformPoint(pos);
        position.z += position.y * ratio;
        tTop.position = position;
        //tTop.position = myCanvas.transform.TransformPoint(pos);

        /*
        Vector3 mousePos = Input.mousePosition;
        Vector3 temp = new Vector3();
        Debug.DrawLine(mousePos, temp);
        //BottleTopTransform.position = mousePos;*/
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
