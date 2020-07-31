﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindElementalEnemy : EnemyBase
{
    private bool m_isPlayerInDetonationRange;

    private float m_detonationTime;

    public float DetonationTimer;

    public override void EnemyDamaged(float damage, int projectileType)
    {
        base.EnemyDamaged(damage, projectileType);
        switch (projectileType)
        {
            case 1:


            case 2:
                CurrentHealth -= damage * 2;
                m_isEnemyBurning = true;
                break;
        }
    }

    protected override void EnemyBehaviour()
    {
        base.EnemyBehaviour();
        EnemyDetonation();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_isPlayerInDetonationRange = true;
            Debug.Log("Start Detonation");
        }
    }

    private void EnemyDetonation()
    {
        if (m_isPlayerInDetonationRange == true)
        {
            isPlayerInRange = true;
            m_detonationTime += Time.deltaTime;

            if (m_detonationTime > DetonationTimer)
            {
                CurrentHealth = 0;
                Debug.Log("Enemy Detonated");
            }
        }
    }
}
