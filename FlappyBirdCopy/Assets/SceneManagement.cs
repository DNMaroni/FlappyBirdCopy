using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Start is called before the first frame update
    public void moveToScene(int sceneID){
        SceneManager.LoadScene(sceneID);
    }
}
