using System;
using System.Collections;
using UnityEngine;

public class ChaseManager : Resettable
{
    [SerializeField] float fireActivationDelay = 2;
    [SerializeField] float fireActivationInterval = 0.5f;
    [SerializeField] float height = 1;
    [SerializeField] Transform endPoint;
    FireController[] fires;
    ResetTrigger resetter;
    Vector3 startPos;
    bool startable = true;

    void Start()
    {
        resetter = gameObject.AddComponent<ResetTrigger>();
        resetter.enabled = false;
        startPos = transform.position;
        fires = FindObjectsOfType<FireController>();
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
            StartCoroutine(fires[i].MoveFire(i * fireActivationInterval, height, fireActivationInterval));
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
