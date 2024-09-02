// Decompiled with JetBrains decompiler
// Type: EffectBuguSlot
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class EffectBuguSlot : MonoBehaviour
{
  [SerializeField]
  private GameObject objUnity_;
  [SerializeField]
  private UILabel txtUnity_;

  public void slotActive(bool active)
  {
    if ((bool) (Object) this.objUnity_)
      this.objUnity_.SetActive(active);
    if (!(bool) (Object) this.txtUnity_)
      return;
    this.txtUnity_.gameObject.SetActive(active);
  }

  public void setUnity(string unity) => this.txtUnity_.SetTextLocalize(unity);
}
