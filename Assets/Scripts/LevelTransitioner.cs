using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Timothy Garcia 300898955
 */
public class LevelTransitioner : MonoBehaviour
{

    [SerializeField] public string nextlevel;
       // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Loads a scene based on string input in the inspector
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(nextlevel);
    }
}
