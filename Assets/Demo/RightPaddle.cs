using UnityEngine;

public class RightPaddle : MonoBehaviour
{
    public float maxPaddleSpeed = 5f;
    public float paddleForce = 1f;
    public string inputAxis;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BoxCollider c = GetComponent<BoxCollider>();
        float max = c.bounds.max.z;
        float min = c.bounds.min.z;
        Debug.Log($"Max: {max}, Min: {min}");
    }

    // Update is called once per frame
    void Update()
    {
        float movementAxis = Input.GetAxis("RightPaddle");
        
        Transform paddleTransform = GetComponent<Transform>();
        
        Vector3 newPosition = paddleTransform.position += new Vector3(0f, 0f, movementAxis * maxPaddleSpeed * Time.deltaTime);
        //newPosition.z = Math.Clamp(newPosition.z, -2.2f, 2.2f);
        paddleTransform.position = newPosition;
    }
}
