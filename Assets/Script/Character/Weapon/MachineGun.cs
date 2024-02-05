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

    private WaitForSeconds shotDelay;
    private IEnumerator usingCor;

    private void Start()
    {
        Initsetting();
        shotDelay = new WaitForSeconds(Data.ShotDelay);
    }
    public override void Initsetting()
    {
        Data.ShotDelay = 1f;
        Data.MaxBullet = 30;
        Data.CurBullet = 30;
        Data.Damage = 10;
        Data.triggerName = "IsMachineGun";
    }

    public override void Using()
    {
        if (usingCor != null)
        {
            usingCor = UsingCor();
            StartCoroutine(usingCor);
        }
    }

    IEnumerator UsingCor()
    {
        while (canShooting)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            Ray ray = camera.ScreenPointToRay(mousePos);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.DrawRay(ray.origin, ray.direction, Color.red, 1f);
                StartCoroutine(SpawnTrail(hit));

                if (hit.collider.CompareTag("Monster"))
                {
                    hit.collider.GetComponent<Weakness>().AttackDamage(10f, hit.point);
                }
            }
            yield return shotDelay;
        }
        usingCor = null;
    }

    private IEnumerator SpawnTrail(RaycastHit hit)
    {
        TrailRenderer trail = Instantiate(shotTrail, shotPos.position, Quaternion.identity);

        yield return null;

        trail.transform.position = hit.point;

        Destroy(trail.gameObject, trail.time);
    }
}
