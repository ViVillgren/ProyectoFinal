using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WinOnKill : MonoBehaviour
{

    public GameObject killScore;
    public int Score;

    public void KillEnemyCount()
    {
        Score++;
    }
}
