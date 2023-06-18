using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{

    [System.Serializable]
    public struct PiecePrefab
    {
        public string gemName;
        public int gemPrice;
        public Sprite gemIcon;
        public GameObject gemModel;
    };
    public int xDim;
    public int yDim;

    public PiecePrefab[] piecePrefabs;
    public GameObject backgroundPrefab;


    private GameObject[,] pieces;

    [SerializeField] private Transform m_ContentContainer;
    [SerializeField] private GameObject m_ItemPrefab;
    void Start()
    {
        for(int x=0;x<xDim;x++)
        {
            for(int y=0;y<yDim;y++)
            {
                GameObject background=(GameObject)Instantiate(backgroundPrefab,new Vector3(transform.position.x+x,0.10f, transform.position.z+y),Quaternion.identity);
                background.transform.parent = transform;
            }
        }

        pieces = new GameObject[xDim, yDim];
        for(int x=0;x<xDim;x++)
        {
            for(int y=0;y<yDim;y++)
            {
                int randomNumber = Random.Range(0, piecePrefabs.Length);
                pieces[x, y] = (GameObject)Instantiate(piecePrefabs[randomNumber].gemModel, new Vector3(transform.position.x + x, 0.20f, transform.position.z + y), Quaternion.identity);
                pieces[x, y].name = piecePrefabs[randomNumber].gemName;
                pieces[x,y].transform.parent = transform;
                pieces[x, y].transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
            }
        }

        for (int i = 0; i < piecePrefabs.Length; i++)
        {
            GameObject item_go = Instantiate(m_ItemPrefab);
            item_go.transform.SetParent(m_ContentContainer.transform, false);

            item_go.transform.Find("GemName").GetComponentInChildren<Text>().text= piecePrefabs[i].gemName;
            item_go.transform.Find("GemPrice").GetComponentInChildren<Text>().text = piecePrefabs[i].gemPrice.ToString();
            item_go.transform.Find("GemImage").GetComponentInChildren<Image>().sprite = piecePrefabs[i].gemIcon;
        }
    }

    public void newGem(int x,int y)
    {
        int randomNumber = Random.Range(0, piecePrefabs.Length);

        pieces[x, y] = (GameObject)Instantiate(piecePrefabs[randomNumber].gemModel, new Vector3(transform.position.x + x, 0.20f, transform.position.z + y), Quaternion.identity);
        pieces[x, y].name = piecePrefabs[randomNumber].gemName;
        pieces[x, y].transform.parent = transform;
        pieces[x, y].transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
    }
}
