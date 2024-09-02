// Decompiled with JetBrains decompiler
// Type: Shop0074ScrollGrid
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class Shop0074ScrollGrid : UIGrid
{
  protected override void Sort(BetterList<Transform> list) => list.Sort((BetterList<Transform>.CompareFunc) ((a, b) => a.GetComponent<Shop0074Scroll>().IsSoldOut.CompareTo(b.GetComponent<Shop0074Scroll>().IsSoldOut)));
}
