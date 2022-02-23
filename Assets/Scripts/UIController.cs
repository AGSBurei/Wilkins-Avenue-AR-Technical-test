using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text AxisDisplay;
    [SerializeField] private Text ObjectDisplay;
    [SerializeField] private ObjectMovementController _objectMovementController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetAxisDisplay();
        SetObjectDisplay();
    }

    public void SetAxisDisplay()
    {
        AxisDisplay.text = _objectMovementController.currentAxis + " axis is selected";
    }

    public void SetObjectDisplay()
    {
        ObjectDisplay.text = _objectMovementController.currentObject.name + " object is selected";
    }
}
