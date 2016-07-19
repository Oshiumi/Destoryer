using UnityEngine;
using System.Collections;



public class dummy : MonoBehaviour
{
    public GameObject pointManager;
    private PointGet pt;
    public GameObject gameManager;
    private GameManager gm;
    private int a = 0;
    // Use this for initialization
    void Start()
    {
        pt = pointManager.GetComponent<PointGet>();
        gm = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        a++;
        if (a > 100)
        {
            get();
            a = 0;
            gm.score += 150;
        }
    }
    void get()
    {
        pt.getflag = true;
    }
}
