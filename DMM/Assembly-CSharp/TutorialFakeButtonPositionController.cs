﻿// Decompiled with JetBrains decompiler
// Type: TutorialFakeButtonPositionController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TutorialFakeButtonPositionController : MonoBehaviour
{
  public string targetName;
  [Tooltip("=0: use the gameobject with targetName as target gameobject\n, >0: use the parent of the gameobject with targetName as target gameobject")]
  public int parentLayer;
  private Transform targetTransform;

  private void Awake() => this.UpdatePosition();

  private void Start() => this.UpdatePosition();

  private void Update() => this.UpdatePosition();

  public void UpdatePosition()
  {
    if ((Object) this.targetTransform == (Object) null)
    {
      GameObject gameObject = GameObject.Find(this.targetName);
      if ((Object) gameObject != (Object) null)
      {
        this.targetTransform = gameObject.transform;
        for (int index = 0; index < this.parentLayer; ++index)
        {
          this.targetTransform = this.targetTransform.parent;
          if ((Object) this.targetTransform == (Object) null)
          {
            Debug.LogError((object) "The specified target gameobject does not exist!");
            return;
          }
        }
      }
      else
      {
        Debug.LogError((object) "The specified target gameobject does not exist!");
        return;
      }
    }
    if (!((Object) this.targetTransform != (Object) null))
      return;
    this.transform.position = this.targetTransform.position;
  }
}
