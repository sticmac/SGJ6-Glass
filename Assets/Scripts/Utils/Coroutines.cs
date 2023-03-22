using System;
using System.Collections;

public static class Coroutines
{
    public static IEnumerator DelayOneFrame(Action callback)
    {
        yield return null;
        callback?.Invoke();
    }
}
