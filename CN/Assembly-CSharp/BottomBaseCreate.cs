// Decompiled with JetBrains decompiler
// Type: BottomBaseCreate
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class BottomBaseCreate : MonoBehaviour
{
  public static GameObject BottomBase(Transform parent)
  {
    return Resources.Load<GameObject>("Prefabs/UnitIcon/bottom_base").Clone(parent);
  }
}
