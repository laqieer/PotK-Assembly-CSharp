// Decompiled with JetBrains decompiler
// Type: CoroutineData`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using UnityEngine;

#nullable disable
public class CoroutineData<T>
{
  private Coroutine m_Coroutine;
  private T m_Value;
  private Exception m_Exception;
  private volatile bool m_Running;
  private volatile bool m_Completed;
  private volatile bool m_Stopped;
  private volatile bool m_ShouldStop;
  private Thread m_Thread;
  private Object m_ValueLock = new Object();
  private Object m_ExceptionLock = new Object();

  private CoroutineData()
  {
    this.Running = true;
    this.Completed = false;
  }

  public Coroutine Coroutine
  {
    get
    {
      lock (this.m_Coroutine)
        return this.m_Coroutine;
    }
  }

  public T Value
  {
    get
    {
      lock (this.m_ValueLock)
      {
        Exception exception = this.Exception;
        if (exception != null)
          throw exception;
        if (this.Stopped)
          throw new CoroutineStoppedException();
        return this.m_Value;
      }
    }
    protected set
    {
      lock (this.m_ValueLock)
        this.m_Value = value;
    }
  }

  public Exception Exception
  {
    get
    {
      lock (this.m_ExceptionLock)
        return this.m_Exception;
    }
    protected set
    {
      lock (this.m_ExceptionLock)
        this.m_Exception = value;
    }
  }

  public bool Running
  {
    get => this.m_Running;
    protected set => this.m_Running = value;
  }

  public bool Completed
  {
    get => this.m_Completed;
    protected set => this.m_Completed = value;
  }

  public bool Stopped
  {
    get => this.m_Stopped;
    protected set => this.m_Stopped = value;
  }

  public bool ShouldStop
  {
    get => this.m_ShouldStop;
    protected set => this.m_ShouldStop = value;
  }

  public bool RunningOnMainThread => this.m_Thread == null;

  private Thread Thread
  {
    get => this.m_Thread;
    set
    {
      if (this.m_Thread != null && value == null)
        this.m_Thread.Abort();
      this.m_Thread = value;
    }
  }

  internal static CoroutineData<T> Start(MonoBehaviour behaviour, IEnumerator coroutine)
  {
    CoroutineData<T> coroutineData = new CoroutineData<T>();
    coroutineData.m_Coroutine = behaviour.StartCoroutine(coroutineData.Wrap(coroutine));
    return coroutineData;
  }

  internal static CoroutineData<T> Start(MonoBehaviour behaviour, MonitorCoroutine<T> coroutine)
  {
    CoroutineData<T> data = new CoroutineData<T>();
    data.m_Coroutine = behaviour.StartCoroutine(data.Wrap(coroutine(data)));
    return data;
  }

  [DebuggerHidden]
  private IEnumerator Wrap(IEnumerator coroutine)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new CoroutineData<T>.\u003CWrap\u003Ec__IteratorB15()
    {
      coroutine = coroutine,
      \u003C\u0024\u003Ecoroutine = coroutine,
      \u003C\u003Ef__this = this
    };
  }

  private void WorkerThread(object coroutineObject)
  {
    if (!(coroutineObject is IEnumerator enumerator))
    {
      this.Exception = (Exception) new ArgumentException("Coroutine object passed to thread is null");
      this.Running = false;
    }
    else
    {
      while (!this.Stopped)
      {
        if (this.Running)
        {
          try
          {
            if (!enumerator.MoveNext())
            {
              this.Running = false;
              return;
            }
          }
          catch (Exception ex)
          {
            this.Exception = ex;
            this.Running = false;
            return;
          }
          object current = enumerator.Current;
          switch (current)
          {
            case null:
              Thread.Sleep(1);
              continue;
            case WaitForWorkerThread _:
              Debug.LogWarning((object) "Received WaitForWorkerThread while already on worker thread");
              continue;
            case WaitForMainThread _:
              return;
            case WaitForSeconds _:
              Thread.Sleep(TimeSpan.FromSeconds((double) (float) typeof (WaitForSeconds).GetField("m_Seconds", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).GetValue(current)));
              continue;
            case T obj:
              this.Value = obj;
              this.Running = false;
              this.Completed = true;
              return;
            default:
              Debug.LogWarning((object) string.Format("Unsupported worker thread yield instruction: {0}", (object) current.GetType().Name));
              goto case null;
          }
        }
        else
          break;
      }
      this.Running = false;
    }
  }

  public void Stop() => this.Stopped = true;

  public void RequestStop() => this.ShouldStop = true;
}
