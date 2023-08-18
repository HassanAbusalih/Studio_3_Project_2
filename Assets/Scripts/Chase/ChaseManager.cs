using System;
using System.Collections;
using UnityEngine;

public class ChaseManager : Resettable
{
    [SerializeField] float fireActivationDelay = 2;
    [SerializeField] float fireActivationInterval = 0.5f;
    [SerializeField] float height = 1;
    [SerializeField] Transform endPoint;
    [SerializeField] float fireParticles = 100;
    [SerializeField] FireController[] fires;
    BoxCollider chaseCollider;
    BoxCollider endCollider;
    ResetTrigger resetter;
    Vector3 startPos;
    bool startable = true;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 0.5f, 0.2f);
        BoxCollider chaseCollider = GetComponent<BoxCollider>();
        BoxCollider endCollider = endPoint.GetComponent<BoxCollider>();
        Gizmos.DrawCube(transform.position, chaseCollider.size);
        if (endCollider != null)
        {
            Gizmos.DrawCube(endPoint.position, endCollider.size);
        }
        else
        {
            Gizmos.DrawCube(endPoint.position, chaseCollider.size);
        }
    }

    void Start()
    {
        chaseCollider = GetComponent<BoxCollider>();
        endPoint.TryGetComponent<BoxCollider>(out endCollider);
        resetter = gameObject.AddComponent<ResetTrigger>();
        resetter.enabled = false;
        startPos = transform.position;
        foreach (FireController fire in fires)
        {
            fire.GetDistance(gameObject);
        }
        Array.Sort(fires);
    }

    IEnumerator StartChase()
    {
        yield return new WaitForSeconds(fireActivationDelay);
        for (int i = 0; i < fires.Length; i++)
        {
            StartCoroutine(fires[i].MoveFire(i * fireActivationInterval, height, fireActivationInterval, fireParticles));
        }
        resetter.enabled = true;
        float totalTime = fires.Length * fireActivationInterval;
        float currentTime = 0;
        while (currentTime < totalTime)
        {
            transform.position = Vector3.Lerp(startPos, endPoint.position, currentTime/totalTime);
            currentTime += Time.deltaTime;
            yield return null;
        }
        transform.position = endPoint.position;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null && !resetter.enabled && startable)
        {
            startable = false;
            StartCoroutine(StartChase());
        }
    }

    public override void ResetObject()
    {
        StopAllCoroutines();
        transform.position = startPos;
        resetter.enabled = false;
        Invoke("AllowStart", 0.1f);
    }

    void AllowStart()
    {
        startable = true;
    }
}
