using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set;}
    [SerializeField ]private float timer = 10;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
            Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        timer -= Time.deltaTime * .0166f;
    }
    public void AddTime(float time)
    {
        timer += time;
    }
    public void SubtractTime(float time)
    {
        timer -= time;
    }
}
