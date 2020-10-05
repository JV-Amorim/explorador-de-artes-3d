using System.Collections;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 50;
    private Quaternion originalRotationValue;

    private bool resetting = false;

    private void Start()
    {
        originalRotationValue = transform.rotation;
    }

    private void Update()
    {
        if (!resetting)
            return;

        StartCoroutine(SetResettingFalseWithDelay(2f));

        transform.rotation = Quaternion.Slerp(transform.rotation, originalRotationValue, Time.deltaTime * 3);
    }

    public void PerformUpwardRotation()
    {
        float rotationValue = rotationSpeed * Mathf.Deg2Rad;

        transform.Rotate(Vector3.right, rotationValue);
    }

    public void PerformDownwardRotation()
    {
        float rotationValue = (rotationSpeed / 2) * Mathf.Deg2Rad;

        transform.Rotate(Vector3.left, rotationValue);
    }

    public void PerformLeftwardRotation()
    {
        float rotationValue = (rotationSpeed / 2) * Mathf.Deg2Rad;

        transform.Rotate(Vector3.up, rotationValue);
    }

    public void PerformRightwardRotation()
    {
        float rotationValue = (rotationSpeed / 2) * Mathf.Deg2Rad;

        transform.Rotate(Vector3.down, rotationValue);
    }

    public void ResetRotation()
    {
        resetting = true;
    }

    IEnumerator SetResettingFalseWithDelay(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);

        resetting = false;
    }
}
