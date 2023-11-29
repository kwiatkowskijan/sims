using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    public int score = 0;
    [SerializeField] [Range(-1, 7)] private float _float;
    public int[] ints;
    public List<int> list;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        score++;
        Debug.Log(score);
    }
}
