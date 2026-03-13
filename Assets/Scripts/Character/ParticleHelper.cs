using UnityEngine;

[System.Serializable]
public struct ParticleFX
{
    public Transform prefab;
    public Vector3 pos;
    public Vector3 rot;

    public ParticleFX(Transform prefab, Vector3 pos, Vector3 rot)
    {
        this.prefab = prefab;
        this.pos = pos;
        this.rot = rot;
    }
}

[System.Serializable]
public struct ParticlePosition
{
    public Vector3 pos;
    public Vector3 rot;
}

public class ParticleHelper : MonoBehaviour
{
    public void GenerateFX(ParticleFX fx, float destroyAfterSeconds)
    {
        if (fx.prefab == null)
        {
            return;
        }

        var instance = Instantiate(fx.prefab, transform);
        instance.localPosition = fx.pos;
        instance.localRotation = Quaternion.Euler(fx.rot);

        if (destroyAfterSeconds > 0)
        {
            Destroy(instance.gameObject, destroyAfterSeconds);
        }
    }
}
