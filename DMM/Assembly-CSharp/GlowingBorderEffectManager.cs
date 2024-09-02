// Decompiled with JetBrains decompiler
// Type: GlowingBorderEffectManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

public class GlowingBorderEffectManager : MonoBehaviour
{
  [Tooltip("The original texture.")]
  public Texture2D inputTexture;
  [Tooltip("The width of the glowing border in pixel.")]
  [Range(1f, 100f)]
  public int borderWidth;
  [Tooltip("This variable is used to determine where to be regared as a border. For example, if the value is set to 0.1, it means that a pixel(of which the alpha is 0) that has any pixels(of which the alpha is larger than 0.1) will be regarded as a border.")]
  [Range(0.0f, 1f)]
  public float borderAlphaThreshold;
  [Tooltip("The texture that specifies the color gradient of the glowing border.")]
  public Texture2D borderColorTexture;
  public UITexture outputTexture;
  public UITexture originalTexture;

  private void Start()
  {
  }

  private void Update()
  {
  }

  private void SetGlowBorderTexture()
  {
    this.originalTexture.mainTexture = (Texture) this.inputTexture;
    this.outputTexture.mainTexture = (Texture) GlowingBorderEffectManager.GetGlowBorderTexture(this.inputTexture, this.borderColorTexture, this.borderWidth, this.borderAlphaThreshold);
  }

  private void OnGUI()
  {
    if (!UnityEngine.GUI.Button(new Rect((float) (Screen.width / 3), (float) (Screen.height / 15), (float) (Screen.width / 3), (float) (Screen.height / 15)), "Generate Glowing Border"))
      return;
    this.SetGlowBorderTexture();
  }

  public static Texture2D GetGlowBorderTexture(
    Texture2D inputTexture,
    Texture2D borderColorTexture,
    int borderWidth,
    float borderAlphaThreshold)
  {
    DateTime now = DateTime.Now;
    Color[] pixels1 = GlowingBorderEffectManager.DuplicateTexture(inputTexture).GetPixels();
    Texture2D texture2D = new Texture2D(inputTexture.width, inputTexture.height);
    Color[] colorArray = new Color[inputTexture.width * inputTexture.height];
    bool[] flagArray = new bool[inputTexture.width * inputTexture.height];
    List<GlowingBorderEffectManager.BorderMark> borderMarkList = new List<GlowingBorderEffectManager.BorderMark>();
    Color[] pixels2 = GlowingBorderEffectManager.DuplicateTexture(borderColorTexture).GetPixels();
    for (int centerX = 0; centerX < inputTexture.width; ++centerX)
    {
      for (int centerY = 0; centerY < inputTexture.height; ++centerY)
      {
        int index = centerX + centerY * inputTexture.width;
        flagArray[index] = GlowingBorderEffectManager.CheckEdge(centerX, centerY, pixels1, inputTexture.width, inputTexture.height, borderAlphaThreshold);
        if (flagArray[index])
          borderMarkList.Add(new GlowingBorderEffectManager.BorderMark()
          {
            x = centerX,
            y = centerY
          });
        colorArray[index] = Color.clear;
      }
    }
    GlowingBorderEffectManager.BorderMark[] array = borderMarkList.ToArray();
    for (int index = 0; index < array.Length; ++index)
    {
      GlowingBorderEffectManager.BorderMark borderMark = array[index];
      colorArray[borderMark.x + borderMark.y * inputTexture.width] = pixels2[0];
    }
    for (int index1 = 1; index1 < borderWidth; ++index1)
    {
      borderMarkList.Clear();
      Color color = pixels2[Mathf.FloorToInt((float) index1 / (float) (borderWidth - 1) * (float) (pixels2.Length - 1))];
      for (int index2 = 0; index2 < array.Length; ++index2)
      {
        int x = array[index2].x;
        int y = array[index2].y;
        int width = inputTexture.width;
        int num1 = x;
        int num2 = y + 1;
        int num3 = num2 < inputTexture.height ? num2 : inputTexture.height - 1;
        int index3 = num1 + num3 * inputTexture.width;
        if (!flagArray[index3] && (double) pixels1[index3].a == 0.0)
        {
          colorArray[index3] = color;
          borderMarkList.Add(new GlowingBorderEffectManager.BorderMark()
          {
            x = num1,
            y = num3
          });
          flagArray[index3] = true;
        }
        int num4 = x;
        int num5 = y - 1;
        int num6 = num5 >= 0 ? num5 : 0;
        int index4 = num4 + num6 * inputTexture.width;
        if (!flagArray[index4] && (double) pixels1[index4].a == 0.0)
        {
          colorArray[index4] = color;
          borderMarkList.Add(new GlowingBorderEffectManager.BorderMark()
          {
            x = num4,
            y = num6
          });
          flagArray[index4] = true;
        }
        int num7 = x - 1;
        int num8 = y;
        int num9 = num7 >= 0 ? num7 : 0;
        int index5 = num9 + num8 * inputTexture.width;
        if (!flagArray[index5] && (double) pixels1[index5].a == 0.0)
        {
          colorArray[index5] = color;
          borderMarkList.Add(new GlowingBorderEffectManager.BorderMark()
          {
            x = num9,
            y = num8
          });
          flagArray[index5] = true;
        }
        int num10 = x + 1;
        int num11 = y;
        int num12 = num10 < inputTexture.width ? num10 : inputTexture.width - 1;
        int index6 = num12 + num11 * inputTexture.width;
        if (!flagArray[index6] && (double) pixels1[index6].a == 0.0)
        {
          colorArray[index6] = color;
          borderMarkList.Add(new GlowingBorderEffectManager.BorderMark()
          {
            x = num12,
            y = num11
          });
          flagArray[index6] = true;
        }
      }
      array = borderMarkList.ToArray();
    }
    Color[] colors = new Color[inputTexture.width * inputTexture.height];
    int num13 = 1;
    for (int index1 = 0; index1 < inputTexture.width; ++index1)
    {
      for (int index2 = 0; index2 < inputTexture.height; ++index2)
      {
        int index3 = index1 + index2 * inputTexture.width;
        if ((double) pixels1[index3].a > 0.0)
          colors[index3] = new Color(1f, 1f, 1f, pixels1[index3].a);
        else if (flagArray[index3])
        {
          Color clear = Color.clear;
          int num1 = 0;
          for (int index4 = -num13; index4 <= num13; ++index4)
          {
            for (int index5 = -num13; index5 <= num13; ++index5)
            {
              int num2 = index1 + index4;
              int num3 = index2 + index5;
              if (0 <= num2 && num2 < inputTexture.width && (0 <= num3 && num3 < inputTexture.height))
              {
                int index6 = num2 + num3 * inputTexture.width;
                if ((double) pixels1[index6].a == 0.0)
                {
                  clear += colorArray[index6];
                  ++num1;
                }
              }
            }
          }
          colors[index3] = clear / (float) num1;
        }
      }
    }
    texture2D.SetPixels(colors);
    texture2D.Apply();
    return texture2D;
  }

  public static bool CheckEdge(
    int centerX,
    int centerY,
    Color[] colorMatrix,
    int textureWidth,
    int textureHeight,
    float borderAlphaThreshold)
  {
    if ((double) colorMatrix[centerX + centerY * textureWidth].a == 0.0)
    {
      for (int index1 = -1; index1 <= 1; ++index1)
      {
        for (int index2 = -1; index2 <= 1; ++index2)
        {
          if (index1 != 0 || index2 != 0)
          {
            int num1 = centerX + index1;
            int num2 = centerY + index2;
            if (0 <= num1 && num1 < textureWidth && (0 <= num2 && num2 < textureHeight) && (double) colorMatrix[num1 + num2 * textureWidth].a > (double) borderAlphaThreshold)
              return true;
          }
        }
      }
    }
    return false;
  }

  public static Texture2D DuplicateTexture(Texture2D source)
  {
    RenderTexture temporary = RenderTexture.GetTemporary(source.width, source.height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
    Graphics.Blit((Texture) source, temporary);
    RenderTexture active = RenderTexture.active;
    RenderTexture.active = temporary;
    Texture2D texture2D = new Texture2D(source.width, source.height);
    texture2D.ReadPixels(new Rect(0.0f, 0.0f, (float) temporary.width, (float) temporary.height), 0, 0);
    texture2D.Apply();
    RenderTexture.active = active;
    RenderTexture.ReleaseTemporary(temporary);
    return texture2D;
  }

  private struct BorderMark
  {
    public int x;
    public int y;
  }
}
