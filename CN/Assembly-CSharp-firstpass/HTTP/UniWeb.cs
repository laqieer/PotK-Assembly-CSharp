// Decompiled with JetBrains decompiler
// Type: HTTP.UniWeb
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
namespace HTTP
{
  public class UniWeb : MonoBehaviour
  {
    private static UniWeb _instance;
    private List<Action> onQuit = new List<Action>();

    public static UniWeb Instance
    {
      get
      {
        if (Object.op_Equality((Object) UniWeb._instance, (Object) null))
        {
          UniWeb._instance = new GameObject("SimpleWWW", new Type[1]
          {
            typeof (UniWeb)
          }).GetComponent<UniWeb>();
          ((Object) ((Component) UniWeb._instance).gameObject).hideFlags = (HideFlags) 61;
        }
        return UniWeb._instance;
      }
    }

    private void Awake()
    {
      if (!Object.op_Inequality((Object) UniWeb._instance, (Object) null))
        return;
      Object.Destroy((Object) ((Component) this).gameObject);
    }

    public void Send(Request request, Action<Request> requestDelegate)
    {
      this.StartCoroutine(this._Send(request, requestDelegate));
    }

    public void Send(Request request, Action<Response> responseDelegate)
    {
      this.StartCoroutine(this._Send(request, responseDelegate));
    }

    [DebuggerHidden]
    private IEnumerator _Send(Request request, Action<Response> responseDelegate)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new UniWeb.\u003C_Send\u003Ec__Iterator12()
      {
        request = request,
        responseDelegate = responseDelegate,
        \u003C\u0024\u003Erequest = request,
        \u003C\u0024\u003EresponseDelegate = responseDelegate
      };
    }

    [DebuggerHidden]
    private IEnumerator _Send(Request request, Action<Request> requestDelegate)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new UniWeb.\u003C_Send\u003Ec__Iterator13()
      {
        request = request,
        requestDelegate = requestDelegate,
        \u003C\u0024\u003Erequest = request,
        \u003C\u0024\u003ErequestDelegate = requestDelegate
      };
    }

    public void OnQuit(Action fn) => this.onQuit.Add(fn);

    private void OnApplicationQuit()
    {
      if (Object.op_Inequality((Object) this, (Object) UniWeb._instance))
      {
        Object.DestroyImmediate((Object) ((Component) this).gameObject);
      }
      else
      {
        foreach (Action action in this.onQuit)
        {
          try
          {
            action();
          }
          catch (Exception ex)
          {
            Debug.LogError((object) ex);
          }
        }
        Object.DestroyImmediate((Object) ((Component) this).gameObject);
        UniWeb._instance = (UniWeb) null;
      }
    }
  }
}
