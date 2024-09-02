// Decompiled with JetBrains decompiler
// Type: StoryResource
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore.LispCore;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class StoryResource
{
  private Dictionary<int, StoryResource.UnitResource> unitResources = new Dictionary<int, StoryResource.UnitResource>();

  [DebuggerHidden]
  public IEnumerator Run(ReadOnlyCollection<StoryBlock> xs)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new StoryResource.\u003CRun\u003Ec__Iterator47F()
    {
      xs = xs,
      \u003C\u0024\u003Exs = xs,
      \u003C\u003Ef__this = this
    };
  }

  public GameObject GetCharacterPrefab(int character_id) => this.unitResource(character_id).Prefab;

  public Sprite GetLargeTexture(int character_id) => this.unitResource(character_id).Large;

  private StoryResource.UnitResource unitResource(int character_id)
  {
    if (!this.unitResources.ContainsKey(character_id))
      Debug.LogError((object) ("character id not found = " + (object) character_id));
    return this.unitResources[character_id];
  }

  private List<Cons> flatten(Cons cons)
  {
    List<Cons> consList = new List<Cons>();
    for (; cons != null; cons = cons.cdr as Cons)
    {
      if (cons.car is Cons car)
        consList.Add(car);
    }
    return consList;
  }

  [DebuggerHidden]
  private IEnumerator dispatch(Cons cons)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new StoryResource.\u003Cdispatch\u003Ec__Iterator480()
    {
      cons = cons,
      \u003C\u0024\u003Econs = cons,
      \u003C\u003Ef__this = this
    };
  }

  private class UnitResource
  {
    public readonly GameObject Prefab;
    public readonly Sprite Large;

    public UnitResource(GameObject prefab, Sprite large)
    {
      this.Prefab = prefab;
      this.Large = large;
    }
  }
}
