using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInputHandler : MonoBehaviour, ICharacterInputProvider
{
    public static CharacterInputHandler instance;

    public CharacterInputActions input;
    private UnityCharacterInputSource inputSource;

    public ICharacterInputSource InputSource => inputSource;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        input ??= new CharacterInputActions();
        inputSource = new UnityCharacterInputSource(input.CharacterControls);
        inputSource.Enable();
    }

    private void OnEnable()
    {
        input ??= new CharacterInputActions();
        inputSource ??= new UnityCharacterInputSource(input.CharacterControls);
        inputSource.Enable();
    }

    private void OnDisable()
    {
        inputSource?.Disable();
    }
}

public class CharacterInputActions
{
    public CharacterControlsActions CharacterControls { get; }

    public CharacterInputActions()
    {
        CharacterControlsActions controls = new CharacterControlsActions();
        CharacterControls = controls;
    }

    public void Enable() => CharacterControls.Enable();
    public void Disable() => CharacterControls.Disable();

    public class CharacterControlsActions
    {
        public InputAction Move { get; } = new InputAction("Move", InputActionType.Value);
        public InputAction Run { get; } = new InputAction("Run", InputActionType.Button);
        public InputAction Roll { get; } = new InputAction("Roll", InputActionType.Button);
        public InputAction Jump { get; } = new InputAction("Jump", InputActionType.Button);
        public InputAction Attack { get; } = new InputAction("Attack", InputActionType.Button);
        public InputAction Skill { get; } = new InputAction("Skill", InputActionType.Button);

        public CharacterControlsActions()
        {
            Move.AddCompositeBinding("2DVector")
                .With("Up", "<Keyboard>/w")
                .With("Down", "<Keyboard>/s")
                .With("Left", "<Keyboard>/a")
                .With("Right", "<Keyboard>/d");
            Move.AddBinding("<Gamepad>/leftStick");

            Run.AddBinding("<Keyboard>/leftShift");
            Run.AddBinding("<Gamepad>/leftStickPress");

            Roll.AddBinding("<Keyboard>/leftCtrl");
            Roll.AddBinding("<Gamepad>/buttonEast");

            Jump.AddBinding("<Keyboard>/space");
            Jump.AddBinding("<Gamepad>/buttonSouth");

            Attack.AddBinding("<Mouse>/leftButton");
            Attack.AddBinding("<Gamepad>/rightShoulder");

            Skill.AddBinding("<Keyboard>/q");
            Skill.AddBinding("<Gamepad>/leftShoulder");
        }

        public void Enable()
        {
            Move.Enable();
            Run.Enable();
            Roll.Enable();
            Jump.Enable();
            Attack.Enable();
            Skill.Enable();
        }

        public void Disable()
        {
            Move.Disable();
            Run.Disable();
            Roll.Disable();
            Jump.Disable();
            Attack.Disable();
            Skill.Disable();
        }
    }
}
