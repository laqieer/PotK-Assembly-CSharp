﻿// Decompiled with JetBrains decompiler
// Type: UnitRoleIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using UnityEngine;

[AddComponentMenu("Popup/Recommend/UnitRoleIcon")]
public class UnitRoleIcon : MonoBehaviour
{
  [SerializeField]
  private UI2DSprite uiSprite_;

  public static Future<GameObject> createLoader() => new ResourceObject("Prefabs/unit/RoleIcon").Load<GameObject>();

  public UI2DSprite uiSprite => this.uiSprite_;

  public IEnumerator doInitialize(UnitRole unitRole)
  {
    Future<UnityEngine.Sprite> ldSprite = new ResourceObject(string.Format("RoleIcons/{0}", (object) unitRole.icon)).Load<UnityEngine.Sprite>();
    yield return (object) ldSprite.Wait();
    this.uiSprite_.sprite2D = ldSprite.Result;
  }
}
