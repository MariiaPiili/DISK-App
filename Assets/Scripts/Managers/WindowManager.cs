using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    public List<GameObject> Screens;

    private int _indexCurrentScreen;

    private void Start()
    {
        for (int i = 0; i < Screens.Count; i++)
        {
            Screens[i].SetActive(false);
        }
        Screens[0].SetActive(true);

        _indexCurrentScreen = 0;
    }

    public void NextScreen()
    {
        Screens[_indexCurrentScreen].SetActive(false);
        _indexCurrentScreen++;
        Screens[_indexCurrentScreen].SetActive(true);
    }    

    public void PreviousScreen()
    {
        Screens[_indexCurrentScreen].SetActive(false);
        _indexCurrentScreen--;
        Screens[_indexCurrentScreen].SetActive(true);
    }
}
