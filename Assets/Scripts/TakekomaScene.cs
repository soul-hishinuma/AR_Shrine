using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakekomaScene : MonoBehaviour
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
        UnityEngine.SceneManagement.SceneManager.LoadScene("TakekomaARScene");
    }
}
