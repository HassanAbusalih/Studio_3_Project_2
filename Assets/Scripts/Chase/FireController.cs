using System;
using System.Collections;
using UnityEngine;

public class FireController : Resettable, IComparable
{
    public float distanceFromStart { get; private set; }
    Vector3 startPos;
    ParticleSystem particleSys;
    ParticleSystem.EmissionModule emissionModule;

    void Start()
    {
        startPos = transform.position;
        particleSys = GetComponent<ParticleSystem>();
        if (particleSys != null)
        {
            emissionModule = particleSys.emission;
            emissionModule.rateOverTime = 0;
        }
    }

    public IEnumerator MoveFire(float delay, float height, float timeToMove, float particles)
    {
        yield return new WaitForSeconds(delay);
        float time = 0;
        Vector3 targetPos = new Vector3(startPos.x, startPos.y + height, startPos.z);
        while (time < timeToMove)
        {
            float rate = particles * (time / timeToMove);
            if (particleSys != null)
            {
                emissionModule.rateOverTime = rate;
            }
            transform.position = Vector3.Lerp(startPos, targetPos, time/timeToMove);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;
    }

    public void GetDistance(GameObject gameObject)
    {
        distanceFromStart = Vector3.Distance(transform.position, gameObject.transform.position);
    }

    public int CompareTo(object obj)
    {
        FireController fireController = obj as FireController;
        if (fireController.distanceFromStart < distanceFromStart)
        {
            return 1;
        }
        else if (fireController.distanceFromStart > distanceFromStart)
        {
            return -1;
        }
        return 0;
    }

    public override void ResetObject()
    {
        StopAllCoroutines();
        transform.position = startPos;
        if (particleSys != null)
        {
            emissionModule.rateOverTime = 0;
        }
    }
}

