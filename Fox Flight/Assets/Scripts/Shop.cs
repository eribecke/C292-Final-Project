using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] Button nextRun;
    // Start is called before the first frame update
    void Start()
    {
        nextRun.onClick.AddListener(() => nextRunClicked());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void nextRunClicked()
    {
        SceneManager.LoadScene(0);
    }
}
