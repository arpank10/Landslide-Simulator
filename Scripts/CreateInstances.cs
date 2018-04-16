using UnityEngine;
using System.Collections;

public class CreateInstances : MonoBehaviour
{

    public GameObject stones;
    public float duration = 3.0f;
    public bool shouldCreateMoreStones = true;
    public Vector3 initialPositionOfStones;

    float initialDuration;

    void Start()
    {
        initialPositionOfStones = stones.transform.position;
        initialDuration = duration;
        StartCoroutine(MyCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldCreateMoreStones)
        {
            if (duration > 0)
            {
                duration -= Time.deltaTime * 0.1f;
            }
            else
            {
                shouldCreateMoreStones = false;
                duration = initialDuration;
            }
        }
    }
    public void RepeatMyCoroutine()
    {
        if(shouldCreateMoreStones)
            StartCoroutine(MyCoroutine());
    }


    private IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(3f);
        Instantiate(stones, initialPositionOfStones, Quaternion.identity);
        if(shouldCreateMoreStones)
            RepeatMyCoroutine();
        yield return null;
    }
}