﻿// Decompiled with JetBrains decompiler
// Type: Friend00817MenuBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Friend00817MenuBase : NGMenuBase
{
  [SerializeField]
  protected UILabel TxtListdescription01;
  [SerializeField]
  protected UILabel TxtListdescription02;
  [SerializeField]
  protected UILabel TxtListdescription03;
  [SerializeField]
  protected UILabel TxtListdescription04;
  [SerializeField]
  protected UILabel TxtTitle;

  protected virtual void Foreground() => Debug.Log((object) "click default event Foreground");

  protected virtual void IbtnBack() => Debug.Log((object) "click default event IbtnBack");

  protected virtual void IbtnSendmessage()
  {
    Debug.Log((object) "click default event IbtnSendmessage");
  }

  protected virtual void IbtnSort() => Debug.Log((object) "click default event IbtnSort");

  protected virtual void VScrollBar() => Debug.Log((object) "click default event VScrollBar");
}
