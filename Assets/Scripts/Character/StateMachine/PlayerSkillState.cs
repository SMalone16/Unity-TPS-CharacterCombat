using System.Collections;
using UnityEngine;

public class PlayerSkillState : PlayerBaseState
{
    private Coroutine recoveryCoroutine;

    public PlayerSkillState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory)
    {
        _isRootState = true;
    }

    public override void EnterState()
    {
        _ctx.targetSpeed = 0f;
        _ctx.currentMovement = Vector3.zero;
        _ctx.canAttack = false;

        _ctx.animator.SetTrigger("skill");
        DoSignaturePowerDamage();

        recoveryCoroutine = _ctx.StartCoroutine(RecoverAndReturn());
    }

    public override void UpdateState() { }

    public override void ExitState()
    {
        if (recoveryCoroutine != null)
        {
            _ctx.StopCoroutine(recoveryCoroutine);
            recoveryCoroutine = null;
        }

        _ctx.canAttack = true;
    }

    public override void CheckSwitchStates() { }

    public override void InitializeSubState() { }

    public override void Trigger(string trigger)
    {
        if (trigger == "damage")
        {
            SwitchState(_factory.Damage(1, _ctx.transform.position));
        }
    }

    public override void Trigger(int damage, Vector3 position)
    {
        SwitchState(_factory.Damage(damage, position));
    }

    private void DoSignaturePowerDamage()
    {
        var enemies = Physics.OverlapSphere(_ctx.transform.position, _ctx.signaturePowerRadius, _ctx.enemyLayerMask);
        foreach (var enemyCollider in enemies)
        {
            var enemy = enemyCollider.GetComponent<EnemyBase>();
            if (enemy == null)
            {
                continue;
            }

            enemy.playerTarget();
            enemy.OnHit(_ctx.signaturePowerDamage, _ctx.transform.position, true);
        }

        if (_ctx.particleHelper != null && _ctx.hitFX != null)
        {
            _ctx.particleHelper.GenerateFX(_ctx.hitFX, 1f);
        }
    }

    private IEnumerator RecoverAndReturn()
    {
        yield return new WaitForSeconds(_ctx.signaturePowerRecovery);
        SwitchState(_factory.Grounded());
    }
}
