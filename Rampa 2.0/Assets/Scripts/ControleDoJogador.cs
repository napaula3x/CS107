using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class ControleDoJogador : MonoBehaviour
{
    public float velocidade = 2;
    Vector3 direção;

    //cor 0 = base
    //cor 1 = verde
    //cor 2 = vermelho
    public Material[] Cores;

    float tempo = 0;
    public float tempoLimite = 3f;

    Renderer renderizador;

    // Start is called before the first frame update
    void Start()
    {
        renderizador = this.gameObject.GetComponent<Renderer>();  
    }

    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime;
        Movimentação();
        ResetaCor();
    }

    private void ResetaCor()
    {
        if (tempo > tempoLimite)
        {
            renderizador.material = Cores[0];
        }
    }

    private void Movimentação()
    {
        direção = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(direção * velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Colidi com " + other.gameObject.name);
        if (other.GetComponent<Vermelho>() != null)
        {
            Morre();
        }
        else if (other.GetComponent<Verde>() != null)
        {
            if (renderizador.material = Cores[1])
            {
                Morre();
            }
            else
            {
                renderizador.material = Cores[1];
                tempo = 0;
            }
        }
    }

    private void Morre()
    {
        Destroy(this.gameObject);
    }
}
