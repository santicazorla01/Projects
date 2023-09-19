using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform target;
    public bool in_Combat = false;
    //----------------------------- animation change when attack
    public Animator animator;

    public int fireDelay;

    public bool gunshooting;
    public AudioSource gunfire;

    private void Update()
    {
        if (in_Combat)
        {
            if (!gunshooting)
            {
                gunshooting = true;
                StartCoroutine(GunFire());
            }
        }
        else
        {
            gunshooting = false;
        }
    }


    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Dummy"))
        {
            //Debug.Log("Attack stay");
            Vector3 Look = transform.InverseTransformPoint(target.transform.position);
            float Angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg - 90;
            transform.Rotate(0, 0, Angle);

            in_Combat = true;
            animator.SetBool("incombat", true);

        }
    }

    void OnTriggerExit2D()
    {
        in_Combat = false;
        animator.SetBool("incombat", false);

        gunfire.Stop();
    }

    IEnumerator GunFire()
    {
        while (gunshooting)
        {
            gunfire.Play();
            yield return new WaitForSeconds(gunfire.clip.length);
        }
    }
}
