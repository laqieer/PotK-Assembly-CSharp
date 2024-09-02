// Decompiled with JetBrains decompiler
// Type: GearKindButtonIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
