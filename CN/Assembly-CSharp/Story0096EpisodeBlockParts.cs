﻿// Decompiled with JetBrains decompiler
// Type: Story0096EpisodeBlockParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Story0096EpisodeBlockParts : MonoBehaviour
{
  [SerializeField]
  private GameObject[] DirEpisodenum;
  [SerializeField]
  private UIButton IbtnEpisodeBlock;

  [DebuggerHidden]
  public IEnumerator setData(int id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0096EpisodeBlockParts.\u003CsetData\u003Ec__Iterator52B()
    {
      id = id,
      \u003C\u0024\u003Eid = id,
      \u003C\u003Ef__this = this
    };
  }
}
