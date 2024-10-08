﻿// Decompiled with JetBrains decompiler
// Type: AnimationEventAction
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventAction : MonoBehaviour
{
  public string func_name_ = "Action";
  public GameObject func_obj_;
  public List<CallFuncData> func_data_list = new List<CallFuncData>();

  private void Action()
  {
    if (this.ErrorCheck())
      return;
    this.func_obj_.SendMessage(this.func_name_);
  }

  private void ListAction(int number)
  {
    int? nullable = this.func_data_list.FirstIndexOrNull<CallFuncData>((Func<CallFuncData, bool>) (x => x.ID == number));
    if (!nullable.HasValue)
      return;
    CallFuncData funcData = this.func_data_list[nullable.Value];
    if (this.ErrorCheck(funcData))
      return;
    funcData.FuncObj.SendMessage(funcData.FuncName, (object) funcData.WaitTime);
  }

  private void ListActionString(string func_name)
  {
    int? nullable = this.func_data_list.FirstIndexOrNull<CallFuncData>((Func<CallFuncData, bool>) (x => x.FuncName == func_name));
    if (!nullable.HasValue)
      return;
    CallFuncData funcData = this.func_data_list[nullable.Value];
    if (this.ErrorCheck(funcData))
      return;
    funcData.FuncObj.SendMessage(funcData.FuncName, (object) funcData.WaitTime);
  }

  private void Action2(string func_name)
  {
    if (this.ErrorCheck())
      return;
    this.func_obj_.SendMessage(func_name);
  }

  private bool ErrorCheck() => this.func_name_ == "" || (UnityEngine.Object) this.func_obj_ == (UnityEngine.Object) null;

  private bool ErrorCheck(CallFuncData cfd) => cfd.FuncName == "" || (UnityEngine.Object) cfd.FuncObj == (UnityEngine.Object) null;

  public void PartuclePlay() => this.GetComponent<ParticleSystem>().Play();
}
