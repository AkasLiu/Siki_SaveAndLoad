using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour {

    //public static TargetManager _intance;

    public GameObject[] monsters;
    public GameObject currentMonster=null;

    public int targetPosition;

    private void Awake()
    {
        //_intance = this;
    }

    // Use this for initialization
    void Start () {
		foreach(GameObject monster in monsters)
        {
            monster.GetComponent<BoxCollider>().enabled = false;
            monster.SetActive(false);
        }
        StartCoroutine("AliveTimer");
	}
	
    private void ActivateMonster()
    {
        int index = Random.Range(0, monsters.Length);
        currentMonster = monsters[index];
        currentMonster.GetComponent<BoxCollider>().enabled = true;
        currentMonster.SetActive(true);
    }

    IEnumerator AliveTimer()
    {
        yield return new WaitForSeconds(Random.Range(1, 3));
        ActivateMonster();
        StartCoroutine("DeathTimer");
    }

    private void DeActivateMonster()
    {
        if (currentMonster != null)
        {
            currentMonster.GetComponent<BoxCollider>().enabled = false;
            currentMonster.SetActive(false);
            currentMonster = null;
        }
    }

    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(Random.Range(4, 9));
        DeActivateMonster();
        StartCoroutine("AliveTimer");
    }

    public void UpdateMonsters()
    {
        StopAllCoroutines();
        if (currentMonster != null)
        {
            currentMonster.GetComponent<BoxCollider>().enabled = false;
            currentMonster.SetActive(false);
            currentMonster = null;
        }
        StartCoroutine("AliveTimer");
    }

    public void ActivateMonsterByType(int type)
    {
        StopAllCoroutines();
        if (currentMonster != null)
        {
            currentMonster.GetComponent<BoxCollider>().enabled = false;
            currentMonster.SetActive(false);
            currentMonster = null;
        }
        currentMonster = monsters[type];
        currentMonster.SetActive(true);
        currentMonster.GetComponent<BoxCollider>().enabled = true;
        StartCoroutine("DeathTimer");
    }

}
