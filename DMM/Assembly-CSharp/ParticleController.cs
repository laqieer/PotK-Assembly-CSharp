// Decompiled with JetBrains decompiler
// Type: ParticleController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
  [Header("パーティクル終了時に自動で削除するか")]
  [SerializeField]
  private bool isAutoErase;
  [Header("エフェクトのスピード倍率(0ならなにもしない)")]
  [SerializeField]
  public float speedMagnification;
  private List<ParticleSystem> particleList = new List<ParticleSystem>();
  private bool oldActive;
  private List<float> particleBaseSpeedList = new List<float>();

  private void Awake()
  {
    this.InitializeParticleList();
    foreach (ParticleSystem particle in this.particleList)
    {
      if ((double) this.speedMagnification > 0.0)
        particle.main.simulationSpeed *= this.speedMagnification;
    }
    this.gameObject.SetActive(false);
  }

  private void Update()
  {
    this.AutoErase();
    this.oldActive = this.IsActive();
  }

  public bool IsActive()
  {
    bool flag = true;
    foreach (ParticleSystem particle in this.particleList)
    {
      if (!particle.isPlaying)
        flag = false;
    }
    return flag;
  }

  public bool IsPausing()
  {
    bool flag = true;
    foreach (ParticleSystem particle in this.particleList)
    {
      if (!particle.isPaused)
        flag = false;
    }
    return flag;
  }

  public void Erase() => Object.Destroy((Object) this.gameObject);

  public void Play()
  {
    this.gameObject.SetActive(true);
    for (int index = 0; index < this.particleList.Count; ++index)
    {
      if ((double) this.speedMagnification > 0.0)
      {
        ParticleSystem.MainModule main = this.particleList[index].main;
        main.simulationSpeed = this.particleBaseSpeedList[index];
        main.simulationSpeed *= this.speedMagnification;
      }
      this.particleList[index].Play();
    }
  }

  public void Pause()
  {
    foreach (ParticleSystem particle in this.particleList)
      particle.Pause();
  }

  public void Stop()
  {
    foreach (ParticleSystem particle in this.particleList)
      particle.Stop();
  }

  public void Restart()
  {
    bool flag = true;
    foreach (ParticleSystem particle in this.particleList)
    {
      if (!particle.isPaused)
        flag = false;
    }
    if (!flag)
      return;
    this.Play();
  }

  private void AutoErase()
  {
    if (!this.isAutoErase || this.oldActive == this.IsActive() || (this.IsActive() || this.IsPausing()))
      return;
    this.Erase();
  }

  private void InitializeParticleList()
  {
    foreach (ParticleSystem componentsInChild in this.gameObject.GetComponentsInChildren<ParticleSystem>())
    {
      this.particleList.Add(componentsInChild);
      this.particleBaseSpeedList.Add(componentsInChild.main.simulationSpeed);
    }
  }
}
