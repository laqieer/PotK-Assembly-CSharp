﻿// Decompiled with JetBrains decompiler
// Type: TimerActiveCollider
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class TimerActiveCollider : MonoBehaviour
{
  [SerializeField]
  private float timer;
  [SerializeField]
  private float delay;
  [SerializeField]
  private BoxCollider[] colliders;

  private void Start() => this.StartCoroutine(this.Counter());

  private void OnEnable() => this.StartCoroutine(this.Counter());

  private IEnumerator Counter()
  {
    yield return (object) new WaitForSeconds(this.delay);
    foreach (Collider collider in this.colliders)
      collider.enabled = false;
    yield return (object) new WaitForSeconds(this.timer);
    foreach (BoxCollider collider in this.colliders)
    {
      collider.enabled = true;
      collider.GetComponent<UIButton>().isEnabled = true;
    }
  }
}
