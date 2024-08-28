using System.Generic;
using System.Generic.Collections;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;


public class BirdAgent : Agent
{
    [SerializeField] private float _velocidade = 1.0f;
    [SerializeField] private float _rotationSpeed = 10f;
    private Rigidbody2D _rb;
    private bool is_colliding = false;

    public int score = 0;

    //Instância o Componente Rigidbody no Script;
    void Start()
    {
        _rb = GetComponent<RigidBody2D>();
    }

    //Sempre que o Episódio Começa
    public override void OnEpisodeBegin()
    {
        //transform.position = Vector2();
    }

    void OnCollisionEnter2D(Collider collider)
    {
        if(collider.CompareTag("Pipe") || collider.CompareTag("Ground"))
        {
            is_colliding = true;
        }
        else:
            is_colliding = false;

        if(collider.CompareTag("Cbox"))
        {
            score++;
            AddReward(1.0f);
        }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        if()
        {
            sensor.AddObservation(_rb.position);
        }
        if()
        {
            sensor.AddObservation(_rb.position);
        }
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        Vector2 controlSignal = Vector2.up;
        controlSignal.y = vectorAction[0];
        _rb.velocity = (controlSignal * _velocidade)
        
        AddReward(-0.0001f);

        if(score > 30)
        {
            EndEpisode();
        }

        if(is_colliding)
        {
            AddReward(-0.5f);
            EndEpisode();
        }

    }

}