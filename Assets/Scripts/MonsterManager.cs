using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour {

    private Animation anim;

    public AnimationClip idleClip;
    public AnimationClip dieClip;

    public int monsterType;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animation>();
        anim.clip = idleClip;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            Destroy(collision.collider.gameObject);
            anim.clip = dieClip;
            anim.Play();
            gameObject.GetComponent<BoxCollider>().enabled = false;
            //print("Attacked");
            UIManager._instance.AddSorce();
        }
    }

    private void OnDisable()
    {
        anim.clip = idleClip;
    }

    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(0.5f);
        //单例模式
        gameObject.GetComponentInParent<TargetManager>().UpdateMonsters();
    }

    //private void OnEnable()
    //{
    //    gameObject.GetComponent<BoxCollider>().enabled = true;
    //}

}
