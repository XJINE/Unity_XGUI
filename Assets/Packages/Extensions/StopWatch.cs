using System;
using System.Diagnostics;

public static class StopWatch
{
    #region Field

    private static Stopwatch stopWatch = new Stopwatch();

    #endregion Field

    #region Property

    public static TimeSpan Ellapsed
    {
        get
        {
            return StopWatch.stopWatch.Elapsed;
        }
    }

    public static bool IsRunning
    {
        get
        {
            return StopWatch.stopWatch.IsRunning;
        }
    }

    #endregion Property

    #region Method

    public static void Start()
    {
        StopWatch.stopWatch.Start();
    }

    public static void Stop()
    {
        StopWatch.stopWatch.Stop();
    }

    public static void Reset()
    {
        StopWatch.stopWatch.Reset();
    }

    public static void Restart()
    {
        Reset();
        Start();
    }

    public static TimeSpan MeasureAction(Action action, int loopCount = 1, bool average = false)
    {
        // NOTE:
        // You can also use MesureAction to mesure Action which has arguments and Function.
        // If you wan to do, pass 'delegate()=>{}' to 'action'.
        // Because of using 'delegate', the result is more slower than accurate way,
        // but it is enough for performance comparison.

        TimeSpan result = TimeSpan.Zero;

        if (StopWatch.stopWatch.IsRunning)
        {
            return result;
        }

        if (average)
        {
            StopWatch.stopWatch.Reset();

            TimeSpan total = TimeSpan.Zero;

            for (int i = 0; i < loopCount; i++)
            {
                StopWatch.stopWatch.Start();
                action();
                total += StopWatch.stopWatch.Elapsed;
                StopWatch.stopWatch.Reset();
            }

            result = new TimeSpan(total.Ticks / loopCount);
        }
        else
        {
            StopWatch.stopWatch.Reset();
            StopWatch.stopWatch.Start();

            for (int i = 0; i < loopCount; i++)
            {
                action();
            }

            result = StopWatch.stopWatch.Elapsed;
        }

        StopWatch.stopWatch.Stop();
        StopWatch.stopWatch.Reset();

        return result;
    }

    #endregion Method
}