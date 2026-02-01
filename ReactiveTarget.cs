using UnityEngine;

public class ReactiveTarget : MonoBehaviour , IReactiveTarget
{
   private RewindableObjects rewindable;
   private ReshapableObject reshapable;
   void Awake(){
       rewindable = GetComponent<RewindableObjects>();
       reshapable = GetComponent<ReshapableObject>();
    }

    public void OnRewindStart(){
        if (rewindable != null){
            rewindable.StartRewind();
        }
    }
    public void OnRewindStop(){
        if (rewindable != null){
            rewindable.StopRewind();
        }
    }
    public void OnReshape(float direction){
        if (reshapable != null){
             reshapable.StartReshape(direction);
        }
    }
    public void OnReshapeStop(){
        if (reshapable != null){
            reshapable.StopReshape();
        }
    }
}
