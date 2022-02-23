using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovementController : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsList;
    private List<string> _axisList = new List<string>();
    public GameObject currentObject;
    public string currentAxis;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _axisList.Add("x");
        _axisList.Add("y");
        _axisList.Add("z");
        SetDefaultSelectedObject();
        SelectDefaultAxis();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SelectNextObject();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SelectNextAxis();
        }
        if (Input.GetKey(KeyCode.Z))
        {
            PositiveMovement();
        }
        if(Input.GetKey(KeyCode.S))
        {
            NegativeMovement();
        }
        if (Input.GetKey(KeyCode.E))
        {
            SelfRotation();
        }
    }
    private void SetDefaultSelectedObject()
    {
        if (objectsList.Count > 0)
        {
            currentObject = objectsList[0];
        }
    }
    private void SelectNextObject()
    {
        var currentIndex = objectsList.IndexOf(currentObject);
        if (currentIndex+1 >= objectsList.Count)
        {
            currentObject = objectsList[0];
        }
        else
        {
            currentObject = objectsList[currentIndex+1];
        }
        Debug.Log(currentObject.name + " is selected");
    }
    private void SelectDefaultAxis()
    {
        currentAxis = _axisList[0];
    }
    private void SelectNextAxis()
    {
        var currentIndex = _axisList.IndexOf(currentAxis);
        if (currentIndex+1 >= _axisList.Count)
        {
            currentAxis= _axisList[0];
        }
        else
        {
            currentAxis = _axisList[currentIndex+1];
        }
        Debug.Log(currentAxis+ " axis is selected");
    }
    private void SelfRotation()
    {
        currentObject.transform.Rotate(0,1,0, Space.World);
    }
    private void PositiveMovement()
    {
        switch (currentAxis)
        {
            case "x":
                currentObject.transform.Translate(Time.deltaTime,0,0,Space.World);
                break;
            case "y":
                currentObject.transform.Translate(0,Time.deltaTime,0,Space.World);
                break;
            case "z":
                currentObject.transform.Translate(0,0,Time.deltaTime,Space.World);
                break;
        }
    }
    private void NegativeMovement()
    {
        switch (currentAxis)
        {
            case "x":
                currentObject.transform.Translate(-Time.deltaTime,0,0,Space.World);
                break;
            case "y":
                currentObject.transform.Translate(0,-Time.deltaTime,0,Space.World);
                break;
            case "z":
                currentObject.transform.Translate(0,0,-Time.deltaTime,Space.World);
                break;
        }
    }
}
