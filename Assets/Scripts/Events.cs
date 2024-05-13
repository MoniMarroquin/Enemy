using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    Gun myPlayer;
    [SerializeField] ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        myPlayer = FindAnyObjectByType <Gun>();
        if (myPlayer == null )
        {
            myPlayer.Effect.AddListener(Emit);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Emit()
    {
        ps.Play();
    }
}
