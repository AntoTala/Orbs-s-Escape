using UnityEngine;

public class ReshapableObject : MonoBehaviour
{
    [Header ("Reshape Settings")]
    protected RewindableObjects rewindable;
    protected bool canBeReshaped = true;
    public float minScale = 0.3f;
    public float maxScale = 3.0f;
    public float scaleSpeed = 2.0f;
    protected bool isReshaping;
    protected float reshapeDirection = 0f;
    public void Awake(){
        rewindable = GetComponent<RewindableObjects>();
    } 
    public void StartReshape(float direction){
        if (!canBeReshaped)
            return;
        if (rewindable != null && rewindable.IsRewinding)
             return;
        reshapeDirection = Mathf.Sign(direction);
    }
    public void StopReshape(){
        reshapeDirection = 0f;
    }
    protected virtual void Update(){
        if (reshapeDirection != 0f)
         ApplyReshape(reshapeDirection);
    }
    public  void ApplyReshape(float direction){
        Vector3 newScale = transform.localScale;
        newScale += Vector3.one * direction * scaleSpeed * Time.deltaTime;
        newScale = ClampScale(newScale);
        transform.localScale = newScale;
        if (!ReshapeManager.Instance.canReshape())
            return;

        ReshapeManager.Instance.drainEnergy(1f);
    }
    protected virtual Vector3 ClampScale(Vector3 newScale){
      float clamped = Mathf.Clamp(newScale.x,minScale,maxScale);
      return new Vector3(clamped,clamped,clamped);

    }
}
