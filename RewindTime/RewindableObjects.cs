using UnityEngine;
using System.Collections.Generic;
[RequireComponent(typeof(Rigidbody))]
public abstract class RewindableObjects : MonoBehaviour
{
    protected bool rewinding ;
    public bool IsRewinding => rewinding;
    public virtual void StartRewind()
    {
        rewinding = true;
    }
    public virtual void StopRewind()
    {
        rewinding = false;
    }
    protected abstract void RecordState();
    protected abstract  void RestoreState();

    protected virtual void FixedUpdate()
    {
        if(rewinding)
        {
            RestoreState();
        }
        else
        {
            RecordState();
        }
    }
     protected virtual void OnEnable()
    {
        TimeManager.Instance?.Register(this);
    }
    protected  virtual void OnDisable()
    {
        TimeManager.Instance?.Unregister(this);
    }

}
