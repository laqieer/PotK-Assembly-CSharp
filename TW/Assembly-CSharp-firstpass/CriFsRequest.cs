// Decompiled with JetBrains decompiler
// Type: CriFsRequest
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class CriFsRequest : IDisposable
{
  public CriFsRequest.DoneDelegate doneDelegate { get; protected set; }

  public bool isDone { get; private set; }

  public string error { get; protected set; }

  public bool isDisposed { get; protected set; }

  public virtual void Stop()
  {
  }

  public YieldInstruction WaitForDone(MonoBehaviour mb)
  {
    return (YieldInstruction) mb.StartCoroutine(this.CheckDone());
  }

  public virtual void Update()
  {
  }

  protected void Done()
  {
    this.isDone = true;
    if (this.doneDelegate == null)
      return;
    this.doneDelegate(this);
  }

  [DebuggerHidden]
  private IEnumerator CheckDone()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new CriFsRequest.\u003CCheckDone\u003Ec__Iterator0()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void Dispose()
  {
  }

  ~CriFsRequest() => this.Dispose();

  public delegate void DoneDelegate(CriFsRequest request);
}
