// Decompiled with JetBrains decompiler
// Type: CallFuncData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[Serializable]
public class CallFuncData
{
  [SerializeField]
  private int id;
  [SerializeField]
  private string func_name = string.Empty;
  [SerializeField]
  private GameObject func_obj;
  [SerializeField]
  private float wait_time;

  public int ID => this.id;

  public string FuncName
  {
    get => this.func_name;
    set => this.func_name = value;
  }

  public GameObject FuncObj
  {
    get => this.func_obj;
    set => this.func_obj = value;
  }

  public float WaitTime
  {
    get => this.wait_time;
    set => this.wait_time = value;
  }
}
