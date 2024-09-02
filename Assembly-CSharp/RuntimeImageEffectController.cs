// Decompiled with JetBrains decompiler
// Type: RuntimeImageEffectController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof (UI2DSprite))]
public class RuntimeImageEffectController : MonoBehaviour
{
  private UI2DSprite sprite;
  public UnityEngine.Material material;
  public bool useBluredTexture;
  [Range(1f, 10f)]
  public float downSampleScale = 2f;
  [Range(0.0f, 10f)]
  public int gaussianBlurProcessTimes = 2;
  public Texture2D destinationTexture;
  [Tooltip("0: original texture, 1: destination texture")]
  [Range(0.0f, 1f)]
  public float interpolationProgress;
  public bool invertColor;
  public Color mainColor = Color.white;
  [Range(0.0f, 1f)]
  public float mainColorStrength;
  [Range(0.0f, 3f)]
  public float brightness = 1f;
  [Range(0.0f, 3f)]
  public float colorfulness = 1f;
  [Range(0.0f, 3f)]
  public float contrast = 1f;

  private void Start()
  {
    this.sprite = this.GetComponent<UI2DSprite>();
    if (!this.sprite.shader.name.Contains("RuntimeImageEffect"))
      this.sprite.shader = UnityEngine.Shader.Find("Unlit/RuntimeImageEffect");
    if (!this.useBluredTexture)
      return;
    this.GenerateBluredTexture();
  }

  [ContextMenu("Generate Blured Texture")]
  public void GenerateBluredTexture()
  {
    Texture2D mainTexture = (Texture2D) this.sprite.mainTexture;
    this.destinationTexture = RuntimeImageEffectController.ResizeTexture(mainTexture, (int) ((double) mainTexture.width / (double) this.downSampleScale), (int) ((double) mainTexture.height / (double) this.downSampleScale));
    for (int index = 0; index < this.gaussianBlurProcessTimes; ++index)
      this.destinationTexture = this.GenerateBluredTexture(this.destinationTexture);
  }

  private void LateUpdate() => this.UpdateMaterialSettings();

  private void UpdateMaterialSettings()
  {
    if ((Object) this.sprite == (Object) null)
      this.sprite = this.GetComponent<UI2DSprite>();
    else if ((Object) this.sprite.drawCall == (Object) null)
    {
      this.sprite.Invalidate(true);
    }
    else
    {
      if ((Object) this.material == (Object) null)
        this.material = this.sprite.drawCall.dynamicMaterial;
      this.material.SetTexture("_DestTex", (Texture) this.destinationTexture);
      this.material.SetFloat("_InterpolationProgress", this.interpolationProgress);
      this.material.SetInt("_Invert", this.invertColor ? 1 : 0);
      this.material.SetColor("_MainColor", this.mainColor);
      this.material.SetFloat("_MainColorStrength", this.mainColorStrength);
      this.material.SetFloat("_Brightness", this.brightness);
      this.material.SetFloat("_Colorfulness", this.colorfulness);
      this.material.SetFloat("_Contrast", this.contrast);
    }
  }

  private Texture2D GenerateBluredTexture(Texture2D originalTexture)
  {
    Texture2D texture2D = new Texture2D(originalTexture.width, originalTexture.height);
    Color[] pixels = originalTexture.GetPixels();
    float[] numArray = new float[9]
    {
      0.087133f,
      0.120917f,
      0.087133f,
      0.120917f,
      0.167799f,
      0.120917f,
      0.087133f,
      0.120917f,
      0.087133f
    };
    int num = (int) ((double) Mathf.Sqrt((float) numArray.Length) - 1.0) / 2;
    Color[] colors = new Color[pixels.Length];
    for (int index1 = 0; index1 < originalTexture.height; ++index1)
    {
      for (int index2 = 0; index2 < originalTexture.width; ++index2)
      {
        int index3 = index1 * originalTexture.width + index2;
        Color clear = Color.clear;
        int index4 = 0;
        for (int index5 = index1 - num; index5 <= index1 + num; ++index5)
        {
          for (int index6 = index2 - num; index6 <= index2 + num; ++index6)
          {
            if (0 <= index5 && index5 < originalTexture.height && (0 <= index6 && index6 < originalTexture.width))
            {
              int index7 = index5 * originalTexture.width + index6;
              clear += pixels[index7] * numArray[index4];
              ++index4;
            }
          }
        }
        colors[index3] = clear;
      }
    }
    texture2D.SetPixels(colors);
    texture2D.Apply();
    return texture2D;
  }

  public static Texture2D ResizeTexture(Texture2D source, int width, int height)
  {
    RenderTexture temporary = RenderTexture.GetTemporary(width, height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
    Graphics.Blit((Texture) source, temporary);
    RenderTexture active = RenderTexture.active;
    RenderTexture.active = temporary;
    Texture2D texture2D = new Texture2D(width, height);
    texture2D.ReadPixels(new Rect(0.0f, 0.0f, (float) temporary.width, (float) temporary.height), 0, 0);
    texture2D.Apply();
    RenderTexture.active = active;
    RenderTexture.ReleaseTemporary(temporary);
    return texture2D;
  }
}
