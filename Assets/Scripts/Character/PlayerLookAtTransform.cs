using System.Collections;
using UnityEngine;

public class PlayerLookAtTransform : MonoBehaviour
{
    private Coroutine freezeRoutine;

    public void Freeze(float duration)
    {
        if (freezeRoutine != null)
        {
            StopCoroutine(freezeRoutine);
        }

        freezeRoutine = StartCoroutine(FreezeRoutine(duration));
    }

    private IEnumerator FreezeRoutine(float duration)
    {
        enabled = false;
        yield return new WaitForSeconds(duration);
        enabled = true;
        freezeRoutine = null;
    }
}
