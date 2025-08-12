using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadindApp : MonoBehaviour
{    
    public float EndLoadingTime;

    private WindowManager _windowManager;

    private void Awake()
    {
        _windowManager = FindObjectOfType<WindowManager>();
    }

    private void Start()
    {
        Invoke("EndLoading", EndLoadingTime);
    }    

    private void EndLoading()
    {
        _windowManager.NextScreen();
    }
}
