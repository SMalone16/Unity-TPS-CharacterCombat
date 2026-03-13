using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private int health = 3;

    public virtual void playerTarget()
    {
        // Hook for enemy aggro/targeting logic.
    }

    public virtual void OnHit(int damage, Vector3 sourcePosition, bool launchUp)
    {
        health -= Mathf.Max(1, damage);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public virtual void KnockBack(Vector3 sourcePosition)
    {
        // Minimal placeholder for physics/animation reaction.
    }
}
