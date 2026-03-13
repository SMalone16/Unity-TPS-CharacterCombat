using UnityEngine;

[CreateAssetMenu(fileName = "HeroCombatConfig", menuName = "Character/Hero Combat Config")]
public class HeroCombatConfig : ScriptableObject
{
    [Header("Combos")]
    public int comboMax = 3;
    public int airComboMax = 2;
    public DashSetting[] comboDashes;
    public DashSetting[] airComboDashes;

    [Header("Targeting")]
    public float enemyBoundsOffset;
    public Vector3 enemyTargetBoxExtents;
    public float airHitBoxVerticalValue = 4f;
    public float enemyTargetOffset = 2f;
    public float longAttackDistance = 1f;

    [Header("Damage")]
    public DashSetting kncockbackDash = new DashSetting();

    [Header("Signature Power")]
    public float signaturePowerRadius = 4f;
    public int signaturePowerDamage = 2;
    public float signaturePowerRecovery = 0.35f;
}
