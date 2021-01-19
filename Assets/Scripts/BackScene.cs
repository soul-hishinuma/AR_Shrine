﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        Invoke("ChangeScene", 0.5f);
    }

    void ChangeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");
    }
}