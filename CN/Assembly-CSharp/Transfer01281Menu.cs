// Decompiled with JetBrains decompiler
// Type: Transfer01281Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Transfer01281Menu : NGMenuBase
{
  [SerializeField]
  private GameObject InputCode;

  public virtual void IbtnPopupNext()
  {
    this.InputCode.SetActive(true);
    this.InputCode.GetComponent<Startup00017Menu>().InitDataCode();
    ((Component) this).gameObject.SetActive(false);
  }

  public virtual void IbtnPopupBack() => ((Component) this).gameObject.SetActive(false);
}
