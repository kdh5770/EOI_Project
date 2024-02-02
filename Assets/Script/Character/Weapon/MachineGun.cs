using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MachineGun : WeaponTable
{
    public Transform shotPos;
    public GameObject shotFlash;
    public TrailRenderer shotTrail;
    public GameObject impactEft;

    private void Start()
    {
        Initsetting();
    }
    public override void Initsetting()
    {
        Data.ShotDelay = 0.5f;
        Data.MaxBullet = 30;
        Data.CurBullet = 30;
        Data.Damage = 10;
        Data.triggerName = "IsMachineGun";
    }

    public override void Using()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Ray ray = camera.ScreenPointToRay(mousePos);
        TrailRenderer trail = Instantiate(shotTrail, shotPos.position, Quaternion.identity);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            StartCoroutine(SpawnTrail(trail, hit));
            if(hit.collider.CompareTag("Monster"))
            {
                hit.collider.GetComponent<Weakness>().AttackDamage(10f, hit.point);
            }
        }
    }

    private IEnumerator SpawnTrail(TrailRenderer Trail, RaycastHit hit)
    {
        float time = 0f;
        Vector3 startPosition = Trail.transform.position;
        while (time < 1f)
        {
            Trail.transform.position = Vector3.Lerp(startPosition, hit.point, time);
            yield return null;
            time += Trail.time / Time.deltaTime;
        }

        Trail.transform.position = hit.point;

        Destroy(Trail.gameObject, Trail.time);

    }
}
