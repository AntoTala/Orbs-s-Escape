using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float speed = 2f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(rb == null)
        {
            Debug.LogError("Rigidbody component not found on this GameObject.");
            enabled = false;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
           rb.linearVelocity = transform.forward * speed;
        }
    }
}
