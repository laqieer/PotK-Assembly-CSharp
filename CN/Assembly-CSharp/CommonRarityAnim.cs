// Decompiled with JetBrains decompiler
// Type: CommonRarityAnim
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
