using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Rewards : MonoBehaviour
{
    [SerializeField] Button toShop;
    // Start is called before the first frame update
    void Start()
    {
        toShop.onClick.AddListener(() => toShopClicked());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void toShopClicked()
    {
        SceneManager.LoadScene(2);
    }
}
