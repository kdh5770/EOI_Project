using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public struct SkillData
{
    public float CurOxygen;
    public float MaxOxygen;
    public string SkillName;
}



public abstract class SkillTable : MonoBehaviour
{
    protected new Camera camera;
    public SkillData S_Data;
    [SerializeField]
    protected LayerMask layerMask;
    public bool CanSkill;

    public int AniHash { get; protected set; }

    private void Awake()
    {
        camera = Camera.main;
    }
    public abstract void Initsetting();

    public virtual void Using()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Ray ray = camera.ScreenPointToRay(mousePos);
    }
}
