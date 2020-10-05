using UnityEngine;

public class RotationButtonsController : MonoBehaviour
{    
    private RotateObject rotationController;
    private bool pressed = false;
    private string rotationDirectionSelected;

    private void Start() => SetCurrentRotationController();

    public void SetCurrentRotationController() => rotationController = FindObjectOfType(typeof(RotateObject)) as RotateObject;

    private void Update()
    {
        if (pressed) RotateToSelectedDirection();
    }

    private void RotateToSelectedDirection()
    {
        switch(rotationDirectionSelected)
        {
            case "Up":
                rotationController.GetComponent<RotateObject>().PerformUpwardRotation();
                break;

            case "Down":
                rotationController.GetComponent<RotateObject>().PerformDownwardRotation();
                break;

            case "Left":
                rotationController.GetComponent<RotateObject>().PerformLeftwardRotation();
                break;

            case "Right":
                rotationController.GetComponent<RotateObject>().PerformRightwardRotation();
                break;
        }
    }
    
    public void ClickStarted(string rotationDirection)
    {
        rotationDirectionSelected = rotationDirection;
        pressed = true;
    }
    
    public void ClickFinished()
    {
        pressed = false;
        rotationDirectionSelected = "";
    }

    public void ResetRotation() => rotationController.GetComponent<RotateObject>().ResetRotation();
}