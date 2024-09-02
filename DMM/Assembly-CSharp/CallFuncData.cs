// Decompiled with JetBrains decompiler
// Type: CallFuncData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[Serializable]
public class CallFuncData
{
  [SerializeField]
  private int id;
  [SerializeField]
  private string func_name = "";
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
