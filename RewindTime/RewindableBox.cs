using UnityEngine;
using System.Collections.Generic;
[RequireComponent(typeof(Rigidbody))]
public class RewindableBox : RewindableObjects
{
   private struct BoxState
    {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;

    }
    private List<BoxState> states = new List<BoxState>();
    private Rigidbody rb;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    protected override void RecordState()
    {
       states.Insert(0, new BoxState
        {
            position = transform.position,
            rotation = transform.rotation,
            scale = transform.localScale
        });
    }
    protected override void RestoreState()
    {
        if(states.Count == 0 )
        {
            StopRewind();
            return;
        }
        transform.position = states[0].position;
        transform.rotation = states[0].rotation;
        transform.localScale = states[0].scale;
        states.RemoveAt(0);
    }
    public override void StartRewind()
    {
        base.StartRewind();
        rb.isKinematic = true;

    }
    public override void StopRewind()
    {
        base.StopRewind();
        rb.isKinematic = false;
    }

}
