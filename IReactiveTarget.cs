using UnityEngine;

public interface IReactiveTarget{
	void OnRewindStart();
	void OnRewindStop();
	void OnReshape(float direction);
	void OnReshapeStop();
}
