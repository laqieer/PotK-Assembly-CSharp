// Decompiled with JetBrains decompiler
// Type: Friend00818MenuBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Friend00818MenuBase : NGMenuBase
{
  [SerializeField]
  protected UILabel InpMesseage;
  [SerializeField]
  protected UILabel TxtFriendmessage;
  [SerializeField]
  protected UILabel TxtListdescription01;
  [SerializeField]
  protected UILabel TxtListdescription02;
  [SerializeField]
  protected UILabel TxtListdescription04;
  [SerializeField]
  protected UILabel TxtTitle;

  protected virtual void IbtnBack() => Debug.Log((object) "click default event IbtnBack");

  protected virtual void IbtnCancel() => Debug.Log((object) "click default event IbtnCancel");

  protected virtual void IbtnTransmission()
  {
    Debug.Log((object) "click default event IbtnTransmission");
  }
}
