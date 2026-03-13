using UnityEngine;

public class IntegrationSceneBootstrap : MonoBehaviour
{
    [SerializeField] private PlayerStateMachine player;
    [SerializeField] private Transform playerModel;

    private void Awake()
    {
        EnsureInput();
        EnsurePlayerRefs();
        EnsureCameraRig();
    }

    private void EnsureInput()
    {
        if (CharacterInputHandler.instance != null)
        {
            return;
        }

        var inputGo = new GameObject("CharacterInputHandler");
        inputGo.AddComponent<CharacterInputHandler>();
    }

    private void EnsurePlayerRefs()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerStateMachine>();
        }

        if (player == null)
        {
            return;
        }

        player.playerModel = playerModel != null ? playerModel : player.transform;

        if (player.GetComponent<ParticleHelper>() == null)
        {
            player.gameObject.AddComponent<ParticleHelper>();
        }

        if (player.lookTarget == null)
        {
            player.lookTarget = player.gameObject.GetComponent<PlayerLookAtTransform>();
            if (player.lookTarget == null)
            {
                player.lookTarget = player.gameObject.AddComponent<PlayerLookAtTransform>();
            }
        }

        if (player.comboDashes == null || player.comboDashes.Length < player.comboMax)
        {
            player.comboDashes = CreateDefaultDashes(player.comboMax);
        }

        if (player.airComboDashes == null || player.airComboDashes.Length < player.airComboMax)
        {
            player.airComboDashes = CreateDefaultDashes(player.airComboMax);
        }
    }

    private DashSetting[] CreateDefaultDashes(int count)
    {
        DashSetting[] values = new DashSetting[Mathf.Max(1, count)];
        for (int i = 0; i < values.Length; i++)
        {
            values[i] = new DashSetting();
        }

        return values;
    }

    private void EnsureCameraRig()
    {
        Camera cam = Camera.main;
        if (cam == null)
        {
            var camGo = new GameObject("Main Camera");
            cam = camGo.AddComponent<Camera>();
            cam.tag = "MainCamera";
            cam.transform.position = new Vector3(0, 6, -8);
            cam.transform.rotation = Quaternion.Euler(18, 0, 0);
        }

        if (cam.GetComponent<ActionCamera>() == null)
        {
            cam.gameObject.AddComponent<ActionCamera>();
        }

        if (player != null && player.thirdPersonCamera == null)
        {
            player.thirdPersonCamera = cam.transform;
        }
    }
}
