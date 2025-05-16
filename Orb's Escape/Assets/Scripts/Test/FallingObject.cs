using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float fallSpeed = 5f;
    public float groundCheckDistance = 0.1f;
    private bool isFalling = true;

    void Update()
    {
        if (isFalling)
        {
            // Controlla se c'è terreno sotto
            if (Physics.Raycast(transform.position, Vector3.down, groundCheckDistance))
            {
                isFalling = false; // ferma la caduta
                return;
            }

            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        }
    }
}