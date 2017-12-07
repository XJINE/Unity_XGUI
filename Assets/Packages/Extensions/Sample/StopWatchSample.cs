using UnityEngine;

public class StopWatchSample : MonoBehaviour
{
    public int loopCount = 1000;

    void Awake()
    {
        Debug.Log(StopWatch.MeasureAction(delegate ()
        {
            Transform transform = base.transform;
        },
        this.loopCount).TotalMilliseconds);

        Debug.Log(StopWatch.MeasureAction(delegate ()
        {
            GameObject gameObject = base.gameObject;
        },
        this.loopCount).TotalMilliseconds);

        // If you need accuracy.

        StopWatch.Restart();

        for (int i = 0; i < this.loopCount; i++)
        {
            Transform transform = base.transform;
        }

        StopWatch.Stop();

        Debug.Log(StopWatch.Ellapsed.TotalMilliseconds);

        StopWatch.Restart();

        for (int i = 0; i < this.loopCount; i++)
        {
            GameObject gameObject = base.gameObject;
        }

        StopWatch.Stop();

        Debug.Log(StopWatch.Ellapsed.TotalMilliseconds);
    }
}