using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private int lives = 5;

    public static GameManager instance = null;



    void Awake ()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
