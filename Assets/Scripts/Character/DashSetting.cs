using UnityEngine;

[System.Serializable]
public class DashSetting
{
    public float dashTime = 0.15f;
    public float dashForce = 14f;
    public float upForce = 7f;
    public float recoverTime = 0.18f;
    public AnimationCurve dashCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
}
