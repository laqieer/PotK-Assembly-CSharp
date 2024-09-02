// Decompiled with JetBrains decompiler
// Type: NGFillAmountGaugeTip
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class NGFillAmountGaugeTip : MonoBehaviour
{
  public float OffSetX;
  [SerializeField]
  private UISprite mParentSprite;

  private void Update()
  {
    float x = (float) this.mParentSprite.width * this.mParentSprite.fillAmount + this.OffSetX;
    Vector3 localPosition = this.transform.localPosition;
    if ((double) x == (double) localPosition.x)
      return;
    this.transform.localPosition = new Vector3(x, localPosition.y, localPosition.z);
  }
}
