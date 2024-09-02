// Decompiled with JetBrains decompiler
// Type: GearKindButtonIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using UnityEngine;

#nullable disable
public class GearKindButtonIcon : MonoBehaviour
{
  public Sprite GetIdle(GearKind kind)
  {
    return Resources.Load<Sprite>(string.Format("Icons/Materials/GuideWeaponBtn/slc_{0}_idle", (object) kind.Enum.ToString()));
  }

  public Sprite GetPress(GearKind kind)
  {
    return Resources.Load<Sprite>(string.Format("Icons/Materials/GuideWeaponBtn/slc_{0}_pressed", (object) kind.Enum.ToString()));
  }
}
