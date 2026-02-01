using UnityEngine;

public class MovingObjects: MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;
    public float speed = 2f;

    private bool goingToB = true;
    private RewindableObjects rewindable;

    void Awake()
    {
        rewindable = GetComponent<RewindableObjects>();
    }

    void FixedUpdate()
    {
        if (rewindable != null && rewindable.IsRewinding)
            return;

        Vector3 target = goingToB ? pointB : pointA;
        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            speed * Time.fixedDeltaTime
        );

        if (Vector3.Distance(transform.position, target) < 0.05f)
            goingToB = !goingToB;
    }
}