using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Replaces MonoBehaviour.Invoke and MonoBehaviour.InvokeRepeating
/// with a more sophisticated attempt. Namely: No strings involved.
/// Use like this:
/// StartCoroutine(Invoker.Invoke(MyMethod, 2));
/// 
/// From: https://gist.github.com/FlaShG/09b80bbc02a4bb6f9e2dda23ff9c5f8d
/// </summary>
public static class Invoker {
    private static readonly WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
    private static readonly WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

    public static IEnumerator Invoke(Action action, float delay) {
        return Invoke(action, delay, () => Time.deltaTime);
    }

    public static IEnumerator InvokeInRealtime(Action action, float delay) {
        return Invoke(action, delay, () => Time.unscaledDeltaTime);
    }

    private static IEnumerator Invoke(Action action, float delay, Func<float> deltaTime) {
        if (delay <= 0) {
            action();
            yield break;
        }

        var countdown = delay;

        while (countdown > 0) {
            yield return null;
            countdown -= deltaTime();
        }

        action();
    }

    public static IEnumerator InvokeRepeating(Action action, float initialDelay, float delay) {
        return InvokeRepeating(action, initialDelay, delay, () => Time.deltaTime);
    }

    public static IEnumerator InvokeRepeatingInRealtime(Action action, float initialDelay, float delay) {
        return InvokeRepeating(action, initialDelay, delay, () => Time.unscaledDeltaTime);
    }

    private static IEnumerator InvokeRepeating(Action action, float initialDelay, float delay, Func<float> deltaTime) {
        if (initialDelay < 0 || delay <= 0) yield break;

        var countdown = initialDelay;

        if (countdown == 0) {
            countdown = delay;
            action();
        }

        while (true) {
            yield return null;
            countdown -= deltaTime();
            while (countdown <= 0) {
                countdown += delay;
                action();
            }
        }
    }

    public static IEnumerator InvokeNextFrame(Action action) {
        yield return null;
        action();
    }

    public static IEnumerator InvokeNextFixedUpdate(Action action) {
        yield return waitForFixedUpdate;
        action();
    }

    public static IEnumerator InvokeAtEndOfFrame(Action action) {
        yield return waitForEndOfFrame;
        action();
    }
}