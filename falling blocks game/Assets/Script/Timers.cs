using UnityEngine;
using System.Collections;

public class Timers : MonoBehaviour
{
    public float Seconds { get; private set; }
    private Spawner spawner;
    private static Timers instance;

    public static Timers GetTimers()
    {
        if (null == instance)
            instance = FindObjectOfType<Timers>();
        return instance;
    }
    public void Start()
    {
        spawner = FindObjectOfType<Spawner>();
    }


    public void Update()
    {
        if (!spawner.isStartGame) return;
        Seconds += Time.deltaTime;
    }
}
