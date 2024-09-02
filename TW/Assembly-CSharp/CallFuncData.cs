// Decompiled with JetBrains decompiler
// Type: CallFuncData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
