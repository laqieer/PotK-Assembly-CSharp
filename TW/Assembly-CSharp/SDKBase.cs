// Decompiled with JetBrains decompiler
// Type: SDKBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class SDKBase : MonoBehaviour
{
  public virtual void start(GameObject gObj)
  {
  }

  public virtual void SDKInit()
  {
  }

  public virtual void LogOut()
  {
  }

  public virtual void Login()
  {
  }

  public virtual void Quit()
  {
  }

  public virtual void createRoleExtra(string roleid, string rolename, string zoneid)
  {
  }

  public virtual string getToken() => string.Empty;

  public virtual string getPlayID() => string.Empty;

  public virtual string getAccountID() => string.Empty;

  public virtual bool isLoginFinish() => false;

  public virtual void testPay()
  {
  }

  public virtual void testPaySpand()
  {
  }

  public virtual void testPayQuick(int index)
  {
  }

  public virtual void buyItem(int index)
  {
  }

  public virtual void setPayFinishAct(Action<int, int, int> payEvent)
  {
  }

  public virtual int getLMoney() => 0;

  public virtual bool getIsShowMoney() => false;

  public virtual void ItemPayStop(string msg)
  {
  }

  public virtual void link(string linkType)
  {
  }

  public virtual void unlink()
  {
  }

  public virtual void loadaccount(string linkType, string oneKeyStr)
  {
  }
}
