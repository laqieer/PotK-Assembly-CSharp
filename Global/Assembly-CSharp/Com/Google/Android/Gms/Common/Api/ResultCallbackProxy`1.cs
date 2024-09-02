﻿// Decompiled with JetBrains decompiler
// Type: Com.Google.Android.Gms.Common.Api.ResultCallbackProxy`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using Google.Developers;
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEngine;

#nullable disable
namespace Com.Google.Android.Gms.Common.Api
{
  public abstract class ResultCallbackProxy<R> : JavaInterfaceProxy, ResultCallback<R> where R : Result
  {
    private const string CLASS_NAME = "com/google/android/gms/common/api/ResultCallback";

    public ResultCallbackProxy()
      : base("com/google/android/gms/common/api/ResultCallback")
    {
    }

    public abstract void OnResult(R arg_Result_1);

    public void onResult(R arg_Result_1) => this.OnResult(arg_Result_1);

    public void onResult(AndroidJavaObject arg_Result_1)
    {
      IntPtr rawObject = arg_Result_1.GetRawObject();
      ConstructorInfo constructor = typeof (R).GetConstructor(new Type[1]
      {
        rawObject.GetType()
      });
      R r;
      if ((object) constructor != null)
      {
        r = (R) constructor.Invoke(new object[1]
        {
          (object) rawObject
        });
      }
      else
      {
        r = (R) typeof (R).GetConstructor(new Type[0]).Invoke(new object[0]);
        Marshal.PtrToStructure(rawObject, (object) r);
      }
      this.OnResult(r);
    }
  }
}
