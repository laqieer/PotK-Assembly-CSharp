// Decompiled with JetBrains decompiler
// Type: Shop0074ScrollGrid
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Shop0074ScrollGrid : UIGrid
{
  protected override void Sort(BetterList<Transform> list)
  {
    list.Sort((BetterList<Transform>.CompareFunc) ((a, b) => ((Component) a).GetComponent<Shop0074Scroll>().IsSoldOut.CompareTo(((Component) b).GetComponent<Shop0074Scroll>().IsSoldOut)));
  }
}
