﻿// Decompiled with JetBrains decompiler
// Type: ParticleScaler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[RequireComponent(typeof (ParticleSystem))]
[ExecuteInEditMode]
public class ParticleScaler : MonoBehaviour
{
  private ParticleSystem m_System;
  private ParticleSystem.Particle[] m_Particles;
  public float m_StartSpeed;
  public float m_StartSize;
  [SerializeField]
  private Transform basePoint;

  public Transform BasePoint
  {
    get => this.basePoint;
    set => this.basePoint = value;
  }

  private void LateUpdate()
  {
    this.InitializeIfNeeded();
    int particles = this.m_System.GetParticles(this.m_Particles);
    float num = !((Object) this.basePoint == (Object) null) ? (float) (((double) this.basePoint.localScale.x + (double) this.basePoint.localScale.y) / 2.0 * ((double) this.transform.localScale.x + (double) this.transform.localScale.y) / 2.0) : (float) (((double) this.transform.localScale.x + (double) this.transform.localScale.y) / 2.0);
    this.m_System.startSpeed = this.m_StartSpeed * num;
    this.m_System.startSize = this.m_StartSize * num;
    for (int index = 0; index < particles; ++index)
      this.m_Particles[index].startSize = this.m_StartSize * num;
    this.m_System.SetParticles(this.m_Particles, particles);
  }

  private void InitializeIfNeeded()
  {
    if ((Object) this.m_System == (Object) null)
      this.m_System = this.GetComponent<ParticleSystem>();
    if (this.m_Particles != null && this.m_Particles.Length >= this.m_System.maxParticles)
      return;
    this.m_Particles = new ParticleSystem.Particle[this.m_System.maxParticles];
  }
}
