using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : NetworkBehaviour
{
    [Networked] private TickTimer life { get; set; }
    public override void FixedUpdateNetwork()
    {
        transform.position += 5 * transform.forward * Runner.DeltaTime;
        if (life.Expired(Runner))
            Runner.Despawn(Object);
    }

    public void Init()
    {
        life = TickTimer.CreateFromSeconds(Runner, 5.0f);
    }
}
