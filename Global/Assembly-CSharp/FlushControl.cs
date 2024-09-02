﻿// Decompiled with JetBrains decompiler
// Type: FlushControl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class FlushControl : MonoBehaviour
{
  private Color color;
  private float time;
  private int value;
  private bool isEnd = true;
  [SerializeField]
  private UIWidget widget;

  private void Start()
  {
  }

  private void Update()
  {
  }

  public void Start(Color color, float time, int value)
  {
    this.widget.color = color;
    this.time = time;
    this.value = value;
    this.isEnd = false;
    this.StartCoroutine(this.FlushUpdate());
  }

  public void SetEnd()
  {
    this.widget.alpha = 0.0f;
    this.isEnd = true;
  }

  public bool IsEnd() => this.isEnd;

  [DebuggerHidden]
  private IEnumerator FlushUpdate()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new FlushControl.\u003CFlushUpdate\u003Ec__Iterator471()
    {
      \u003C\u003Ef__this = this
    };
  }
}
