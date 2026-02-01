using UnityEngine;

public interface  ITimeRewindable
{
  void RecordState();
  void RewindState();
  void StartRewind();
  void StopRewind(); 
}
