using UnityEngine;

[CreateAssetMenu(fileName = "HeroMovementConfig", menuName = "Character/Hero Movement Config")]
public class HeroMovementConfig : ScriptableObject
{
    [Header("Movement")]
    public float walkSpeed = 15.0f;
    public float rotationSpeed = 15.0f;
    public float tiltSpeed = 15.0f;
    public float runMultiplier = 3.0f;
    public float airResistance = 10f;
    public float groundFriction = 40f;
    public float easeFactor = 0.2f;

    [Header("Jump")]
    public float maxJumpHeight = 15.0f;
    public float maxJumpTime = 2f;
    public float gravity = -9.8f;
    public float groundedGravity = -0.05f;
    public DashSetting doubleJumpDash = new DashSetting();

    [Header("Dash")]
    public DashSetting sprintDash = new DashSetting();

    [Header("Wall Run")]
    public float wallRunSpeedMultiplier = 1.3f;
    public float wallRunMinDistance = 10f;
    public float wallRunGravityMultiplier = 0.04f;
    public float wallRunCooldown = 0.6f;
}
