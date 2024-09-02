// Decompiled with JetBrains decompiler
// Type: AnimationEventAction
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
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

  private bool ErrorCheck()
  {
    return this.func_name_ == string.Empty || Object.op_Equality((Object) this.func_obj_, (Object) null);
  }

  private bool ErrorCheck(CallFuncData cfd)
  {
    return cfd.FuncName == string.Empty || Object.op_Equality((Object) cfd.FuncObj, (Object) null);
  }

  public void PartuclePlay() => ((Component) this).GetComponent<ParticleSystem>().Play();
}
