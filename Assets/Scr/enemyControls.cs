using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyControls : MonoBehaviour
{
    private GameObject oyuncu;
    private int zombiHealth = 3;
    private float mesafe;
    public GameObject kalp;
    private int zombidenGelenPuan = 10;
    private oyunKontrol oKontrol;
    private AudioSource aSource;
    private bool zombiOluyor = false;
    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();
        oyuncu = GameObject.Find("FPSController");
        oKontrol = GameObject.Find("_Scripts").GetComponent<oyunKontrol>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = oyuncu.transform.position;
        mesafe = Vector3.Distance(transform.position, oyuncu.transform.position);
        if (mesafe < 10f)
        {
            if(!aSource.isPlaying)
            aSource.Play();
            if(!zombiOluyor)
            GetComponentInChildren<Animation>().Play("Zombie_Attack_01");
        }
        else
        {
            if (aSource.isPlaying)
                aSource.Stop();
        }

    }
      private void OnCollisionEnter(Collision c)
    {
        if (c.collider.gameObject.tag.Equals("mermi"))
        {
            zombiHealth--;
            if(zombiHealth == 0)
            {
                zombiOluyor = true;
                oKontrol.PuanArttır(zombidenGelenPuan);
                Instantiate(kalp, transform.position, Quaternion.identity);
                GetComponentInChildren<Animation>().Play("Zombie_Death_01");
                Destroy(this.gameObject, 1.667f);
            }
        }
    }
}
