// Decompiled with JetBrains decompiler
// Type: CommonRarityAnim
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class CommonRarityAnim : MonoBehaviour
{
  public MeshRenderer image_;
  public MeshRenderer image400_;
  public MeshRenderer image_blur_;
  public MeshRenderer image400_blur_;
  public List<GameObject> rarity_obj_list_;
  public List<GameObject> gacha_rarity_obj_list_;
  public List<CommonRarityAnim.RarityStart> rarity_list;

  [Serializable]
  public class RarityStart
  {
    public List<GameObject> rarity_list;
  }
}
