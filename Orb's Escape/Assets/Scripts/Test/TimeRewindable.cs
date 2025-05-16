using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeRewindable : MonoBehaviour
{
    private bool isRewinding = false;
    private List<TransformState> transformInTime;
    private float recordTime = 5.0f;

    Rigidbody rb;


    void Start()
    {
        transformInTime = new List<TransformState>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            StartRewind();

        if (Input.GetMouseButtonUp(0))
            StopRewind();
    }

    void FixedUpdate()
    {
        if (isRewinding)
            Rewind();
        else
            Record();
    }

    private void Rewind()
    {
        if (transformInTime.Count > 0)
        {
            TransformState transformState = transformInTime[0];
            transform.position = transformState.position;
            transform.rotation = transformState.rotation;
            transformInTime.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
    }

    private void Record()
    {
        if(transformInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
        {
            transformInTime.RemoveAt(transformInTime.Count - 1);
        }
       
        transformInTime.Insert(0,new TransformState(transform.position,transform.rotation));
    }

    public void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
    }
}
