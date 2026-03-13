using System;
using UnityEngine.InputSystem;

public interface ICharacterInputSource
{
    InputAction Move { get; }
    InputAction Run { get; }
    InputAction Roll { get; }
    InputAction Jump { get; }
    InputAction Attack { get; }
    InputAction Skill { get; }

    void Enable();
    void Disable();
}

public interface ICharacterInputProvider
{
    ICharacterInputSource InputSource { get; }
}

public class UnityCharacterInputSource : ICharacterInputSource
{
    private readonly CharacterInputActions.CharacterControlsActions controls;

    public UnityCharacterInputSource(CharacterInputActions.CharacterControlsActions controls)
    {
        this.controls = controls;
    }

    public InputAction Move => controls.Move;
    public InputAction Run => controls.Run;
    public InputAction Roll => controls.Roll;
    public InputAction Jump => controls.Jump;
    public InputAction Attack => controls.Attack;
    public InputAction Skill => controls.Skill;

    public void Enable() => controls.Enable();
    public void Disable() => controls.Disable();
}
