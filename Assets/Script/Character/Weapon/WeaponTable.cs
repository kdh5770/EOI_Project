using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public struct WeaponData
{
    public int Damage;
    public int MaxBullet;
    public int CurBullet;
    public float ShotDelay;
    public string triggerName;
    //public GameObject WeaponFireFlash; // �� �� �� �ѱ����� ������ ��? ��ȭ���� �߰��ؾ���. ��ȭ�� ��ġ�� �߰��ؾ���.
}

public abstract class WeaponTable: MonoBehaviour
{
    protected new Camera camera;
    public WeaponData Data;

    private void Awake()
    {
        camera = Camera.main;
    }

    public abstract void Initsetting();

    public virtual void Using()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Ray ray = camera.ScreenPointToRay(mousePos);
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 3f);
        Debug.Log("shoot");
    }
}