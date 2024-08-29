using System.Generic;
using System.Generic.Collections;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;


public class BirdAgent : Agent
{
    //Velocidade e Rotação
    [SerializeField] private float _velocidade = 1.0f;
    [SerializeField] private float _rotationSpeed = 10f;
    //Random de Spawn de valores possíveis no eixo X
    [SerializeField] private float _initialPositionX = 10f;
    //Random para Spawn de valores possíveis no eixo Y
    [SerializeField] private float _initialPositionY = 2f;
    [SerializeField] private float _finalPositionY = 10f;
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
        transform.position = Vector2( _initialPositionX, Random.Range(_initialPositionY, _finalPositionY));
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetKeyDown(Keycode.Space)
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
        sensor.AddObservation(transform.position);
        sensor.AddObservation(transform.rotation);
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
            SetReward(-0.5f);
            EndEpisode();
        }

    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0,0, _rotationSpeed * _rb.velocity.y);
    }

}