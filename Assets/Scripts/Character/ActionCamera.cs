using UnityEngine;

public class ActionCamera : MonoBehaviour
{
    [SerializeField] private Camera targetCamera;
    [SerializeField] private float defaultFov = 60f;

    private void Awake()
    {
        if (targetCamera == null)
        {
            targetCamera = GetComponent<Camera>();
        }

        if (targetCamera == null)
        {
            targetCamera = Camera.main;
        }

        if (targetCamera != null)
        {
            defaultFov = targetCamera.fieldOfView;
        }
    }

    public void Shake(float intensity, float duration, float frequency)
    {
        // Minimal implementation: keep API in place, can be replaced by Cinemachine impulse later.
    }

    public void Distortion(float strength, float duration)
    {
        // Placeholder for post-processing implementation.
    }

    public void PlayerJustHit()
    {
        if (targetCamera != null)
        {
            targetCamera.fieldOfView = Mathf.Max(defaultFov, targetCamera.fieldOfView);
        }
    }

    public void Zoom(float blendTime, float targetFov)
    {
        if (targetCamera != null)
        {
            targetCamera.fieldOfView = targetFov;
        }
    }
}
