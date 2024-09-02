// Decompiled with JetBrains decompiler
// Type: UniWebViewEventProcessor
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class UniWebViewEventProcessor : MonoBehaviour
{
  private object _queueLock = new object();
  private List<System.Action> _queuedEvents = new List<System.Action>();
  private List<System.Action> _executingEvents = new List<System.Action>();
  private static UniWebViewEventProcessor _instance;

  public static UniWebViewEventProcessor instance
  {
    get
    {
      if (!Object.op_Implicit((Object) UniWebViewEventProcessor._instance))
      {
        UniWebViewEventProcessor._instance = Object.FindObjectOfType(typeof (UniWebViewEventProcessor)) as UniWebViewEventProcessor;
        if (!Object.op_Implicit((Object) UniWebViewEventProcessor._instance))
        {
          GameObject gameObject = new GameObject(nameof (UniWebViewEventProcessor));
          Object.DontDestroyOnLoad((Object) gameObject);
          UniWebViewEventProcessor._instance = gameObject.AddComponent<UniWebViewEventProcessor>();
        }
      }
      return UniWebViewEventProcessor._instance;
    }
  }

  public void QueueEvent(System.Action action)
  {
    lock (this._queueLock)
      this._queuedEvents.Add(action);
  }

  private void Update()
  {
    this.MoveQueuedEventsToExecuting();
    while (this._executingEvents.Count > 0)
    {
      System.Action executingEvent = this._executingEvents[0];
      this._executingEvents.RemoveAt(0);
      executingEvent();
    }
  }

  private void MoveQueuedEventsToExecuting()
  {
    lock (this._queueLock)
    {
      while (this._queuedEvents.Count > 0)
      {
        this._executingEvents.Add(this._queuedEvents[0]);
        this._queuedEvents.RemoveAt(0);
      }
    }
  }
}
