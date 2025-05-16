using UnityEngine;

public class TransformState
{
    public Vector3 position;
    public Quaternion rotation;
    

    public TransformState(Vector3 pos, Quaternion rot)
    {
        position = pos;
        rotation = rot;
        
    }
}