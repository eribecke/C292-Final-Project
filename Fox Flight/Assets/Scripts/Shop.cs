using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] Button nextRun;
    [SerializeField] Button buy;
    [SerializeField] TextMeshProUGUI buyTxt;
   
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

    void buyClicked()
    {
  
    
        
    }

}
