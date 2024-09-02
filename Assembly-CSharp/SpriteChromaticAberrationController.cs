// Decompiled with JetBrains decompiler
// Type: SpriteChromaticAberrationController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof (UI2DSprite))]
public class SpriteChromaticAberrationController : MonoBehaviour
{
  private UI2DSprite sprite;
  private SpriteChromaticAberrationDrawCall drawcallExtension;
  public UIDrawCall drawCall;
  public bool isAdditiveMode;
  private UnityEngine.Shader spriteChromaticAberrationShader;
  private UnityEngine.Shader spriteChromaticAberrationAdditiveShader;
  private bool isShaderChanged;
  public Color color = Color.white;
  [Range(-0.1f, 0.1f)]
  public float aberrationPower = 0.02395844f;
  public float wiggle = 0.4f;
  [Range(0.0f, 1f)]
  public float cutoff = 0.5f;

  private void Start()
  {
    this.spriteChromaticAberrationShader = UnityEngine.Shader.Find("PUNK/UI/Sprite_Chromatic Aberration2");
    this.spriteChromaticAberrationAdditiveShader = UnityEngine.Shader.Find("PUNK/UI/Sprite_Chromatic Aberration_Additive2");
    this.sprite = this.GetComponent<UI2DSprite>();
    this.UpdateShader();
  }

  private bool UpdateShader()
  {
    if (!this.isAdditiveMode && (Object) this.sprite.shader != (Object) this.spriteChromaticAberrationShader)
    {
      this.sprite.shader = this.spriteChromaticAberrationShader;
      return true;
    }
    if (!this.isAdditiveMode || !((Object) this.sprite.shader != (Object) this.spriteChromaticAberrationAdditiveShader))
      return false;
    this.sprite.shader = this.spriteChromaticAberrationAdditiveShader;
    return true;
  }

  private void LateUpdate() => this.UpdateMaterialSettings();

  private void UpdateMaterialSettings()
  {
    if ((Object) this.sprite.drawCall == (Object) null)
    {
      this.sprite.Invalidate(true);
    }
    else
    {
      this.isShaderChanged = this.UpdateShader();
      if (this.isShaderChanged)
        return;
      if ((Object) this.drawCall != (Object) this.sprite.drawCall)
      {
        this.drawCall = this.sprite.drawCall;
        this.drawcallExtension = this.sprite.drawCall.gameObject.GetOrAddComponent<SpriteChromaticAberrationDrawCall>();
      }
      this.drawcallExtension.sprite = this.sprite;
      this.drawcallExtension.drawcall = this.sprite.drawCall;
      this.drawcallExtension.color = this.color;
      this.drawcallExtension.aberrationPower = this.aberrationPower;
      this.drawcallExtension.wiggle = this.wiggle;
      this.drawcallExtension.cutoff = this.cutoff;
    }
  }
}
