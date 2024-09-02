// Decompiled with JetBrains decompiler
// Type: UnitTransAddStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class UnitTransAddStatus : MonoBehaviour
{
  [SerializeField]
  private UILabel TxtUppt;

  public void Init(int value) => this.TxtUppt.SetTextLocalize(value);
}
