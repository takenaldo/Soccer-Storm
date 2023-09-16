using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    public GameObject prefabSpikes;
    public Transform prefabSpikesParent;

    private GameObject lastSpike;
    private void Start()
    {
        lastSpike = GameObject.Instantiate(prefabSpikes, prefabSpikesParent);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("spikes_end"))
            if (CompareTag("end_checker"))
                GameObject.Instantiate(prefabSpikes, prefabSpikesParent);
    }
}
