using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
    public GUIText scoreGUI;
    public GUIText point;
    public GUIText subpoint;
    public GUIText subpoint2;
    public GameObject gameManager;
    private GameManager gm;
    public GameObject pointManager;
    private PointGet pt;
    private bool animeflag = false;
    private int animecount = 0;

    void Start()
    {
        gm = gameManager.GetComponent<GameManager>();
        pt = pointManager.GetComponent<PointGet>();
    }

    void Update()
    {
        scoreGUI.text = "Score: ";
        point.text = "" + gm.score;
        subpoint.text = "" + gm.score;
        subpoint2.text = "" + gm.score;

        if (pt.getflag)
        {
            pt.getflag = false;
            animeini();
        }
        if (animeflag) anime();
    }
    void anime()
    {
        if (animecount >= 15)
        {
            animeflag = false;
            subpoint.enabled = false;
            subpoint2.enabled = false;
        }
        else
        {
            Vector3 sub1, sub2;
            sub1 = subpoint.transform.position;
            sub2 = subpoint2.transform.position;
            sub1.y -= 0.0015f;
            sub2.y += 0.0015f;
            subpoint.transform.position = sub1;
            subpoint2.transform.position = sub2;
            animecount++;
        }
    }
    void animeini()
    {
        subpoint.enabled = true;
        subpoint2.enabled = true;
        animecount = 0;
        Vector3 sub1, sub2;
        sub1 = subpoint.transform.position;
        sub2 = subpoint2.transform.position;
        sub1.y = 0.98f;
        sub2.y = 0.92f;
        subpoint.transform.position = sub1;
        subpoint2.transform.position = sub2;
        animeflag = true;
    }
}
