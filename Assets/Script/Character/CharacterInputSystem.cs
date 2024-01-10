using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class CharacterInputSystem : MonoBehaviour
{
    [Header("Character Input Values")]
    public Vector2 move;
    public Vector2 look;
    public bool sprint;
    public bool aim;
    public bool shoot;
    public bool reload;

    [Header("Movement Settings")]
    public bool analogMovement;

    [Header("Mouse Cursor Settings")]
    public bool cursorLocked = true;
    public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
    public void OnMove(InputValue value)
    {
        MoveInput(value.Get<Vector2>());
    }

    public void OnLook(InputValue value)
    {
        if (cursorInputForLook)
        {
            LookInput(value.Get<Vector2>());
        }
    }


    public void OnSprint(InputValue value)
    {
        SprintInput(value.isPressed);
    }

    public void OnAim(InputValue value)
    {
        AimInput(value.isPressed);
    }

    public void OnShoot(InputValue value)
    {
        ShootInput(value.isPressed);
    }

    public void OnReload(InputValue value)
    {
        ReloadInput(value.isPressed);
    }

#endif


    public void MoveInput(Vector2 newMoveDirection)
    {
        move = newMoveDirection;
    }

    public void LookInput(Vector2 newLookDirection)
    {
        look = newLookDirection;
    }


    public void SprintInput(bool newSprintState)
    {
        sprint = newSprintState;
    }

    public void AimInput(bool newAimState)
    {
        aim = newAimState;
    }

    public void ShootInput(bool newShootState)
    {
        shoot = newShootState;
    }

    public void ReloadInput(bool newReloadState)
    {
        reload = newReloadState;
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        SetCursorState(cursorLocked);
    }

    private void SetCursorState(bool newState)
    {
        Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    }
}

