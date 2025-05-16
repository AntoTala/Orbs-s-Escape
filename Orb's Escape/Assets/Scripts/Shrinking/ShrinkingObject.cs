using UnityEngine;
using System.Collections;

public class ShrinkingObject : MonoBehaviour
{

    public float shrinkSpeed = 2.0f;
    private Vector3 targetScale;
    private Rigidbody rb;
    private float originalMass = 1.0f;
    void Start()
    {
       
        targetScale = transform.localScale;
        if (TryGetComponent<Rigidbody>(out rb))
          originalMass= rb.mass;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            Shrink();
        if (Input.GetKeyDown(KeyCode.T))
            Grow();
        if (Input.GetKeyDown(KeyCode.R))
            ResetScale();

        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * shrinkSpeed);
        if (rb != null)
            rb.mass = originalMass * transform.localScale.x * transform.localScale.y * transform.localScale.z;
       
    }

    void Shrink()
    {
        targetScale = new Vector3(0.1f, 0.1f, 0.1f);
    }
    void Grow()
    {
        targetScale = new Vector3(2.0f, 2.0f, 2.0f);
    }

    public void ResetScale()
    {
        targetScale = Vector3.one;
    }
    public void SetScale(Vector3 newScale)
    {
        targetScale = newScale;
    }
}
