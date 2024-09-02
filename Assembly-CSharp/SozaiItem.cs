// Decompiled with JetBrains decompiler
// Type: SozaiItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class SozaiItem : MonoBehaviour
{
  [SerializeField]
  private GameObject linkSozaiBase;
  [SerializeField]
  private GameObject dirSozaiBase;
  [SerializeField]
  private GameObject dirSozaiBase2;
  [SerializeField]
  private UILabel txtPossessionNum;
  [SerializeField]
  private GameObject wLine;
  [NonSerialized]
  public UnitIcon UnitIcon;

  public GameObject LinkSozaiBase => this.linkSozaiBase;

  public GameObject DirSozaiBase => this.dirSozaiBase;

  public GameObject DirSozaiBase2 => this.dirSozaiBase2;

  public UILabel TxtPossessionNum => this.txtPossessionNum;

  public GameObject WLine => this.wLine;

  public void SetOnlyWLine()
  {
    foreach (Transform transform in this.transform)
    {
      if ((UnityEngine.Object) transform.gameObject == (UnityEngine.Object) this.wLine)
        transform.gameObject.SetActive(true);
      else
        transform.gameObject.SetActive(false);
    }
  }
}
