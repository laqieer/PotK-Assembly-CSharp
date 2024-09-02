// Decompiled with JetBrains decompiler
// Type: I2.Loc.EventCallback
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace I2.Loc
{
  [Serializable]
  public class EventCallback
  {
    public MonoBehaviour Target;
    public string MethodName = string.Empty;

    public void Execute(Object Sender = null)
    {
      if (!Object.op_Implicit((Object) this.Target) || !Application.isPlaying)
        return;
      ((Component) this.Target).gameObject.SendMessage(this.MethodName, (object) Sender, (SendMessageOptions) 1);
    }
  }
}
