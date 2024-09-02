// Decompiled with JetBrains decompiler
// Type: SpriteChromaticAberrationDrawCall
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
public class SpriteChromaticAberrationDrawCall : MonoBehaviour
{
  public UI2DSprite sprite;
  public UIDrawCall drawcall;
  public Color color = Color.white;
  [Range(-0.1f, 0.1f)]
  public float aberrationPower = 0.02395844f;
  public float wiggle = 0.4f;
  [Range(0.0f, 1f)]
  public float cutoff = 0.5f;

  private void Update() => this.RemoveIfNotUsed();

  private void RemoveIfNotUsed()
  {
    if (!((Object) this.drawcall == (Object) null) && !((Object) this.sprite == (Object) null) && !((Object) this.drawcall != (Object) this.sprite.drawCall))
      return;
    Object.Destroy((Object) this);
  }

  private void OnWillRenderObject()
  {
    if ((Object) this.drawcall == (Object) null)
      return;
    if ((Object) this.drawcall.dynamicMaterial == (Object) null)
    {
      Debug.Log((object) "Material is null.");
    }
    else
    {
      this.drawcall.dynamicMaterial.SetColor("_Color", this.color);
      this.drawcall.dynamicMaterial.SetFloat("_AberrationPower", this.aberrationPower);
      this.drawcall.dynamicMaterial.SetFloat("_Wiggle", this.wiggle);
      this.drawcall.dynamicMaterial.SetFloat("_Cutoff", this.cutoff);
    }
  }
}
