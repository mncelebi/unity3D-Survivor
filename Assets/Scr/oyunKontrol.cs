using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class oyunKontrol : MonoBehaviour
{
    public GameObject zombi;
    private float zamanSayaci;
    private float olusumSureci = 10f;
    public Text puanText;
    private int puan;
    // Start is called before the first frame update
    void Start()
    {
        zamanSayaci = olusumSureci;
    }

    // Update is called once per frame
    void Update()
    {
        zamanSayaci -= Time.deltaTime;
        if(zamanSayaci < 0)
        {
            Vector3 pos = new Vector3(Random.Range(139f, 179f), 28.05f, Random.Range(248f, 317f));
            Instantiate(zombi, pos, Quaternion.identity);
            zamanSayaci = olusumSureci;
        }
    }
    public void PuanArttır(int p)
    {
        puan += p;
        puanText.text = "Puan: " + puan;
    }

    public void OyunBitti()
    {
        PlayerPrefs.SetInt("puan", puan);
        SceneManager.LoadScene("OyunBitti");
    }
}
