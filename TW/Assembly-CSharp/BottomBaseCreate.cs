// Decompiled with JetBrains decompiler
// Type: BottomBaseCreate
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class BottomBaseCreate : MonoBehaviour
{
  public static GameObject BottomBase(Transform parent)
  {
    return Resources.Load<GameObject>("Prefabs/UnitIcon/bottom_base").Clone(parent);
  }
}
