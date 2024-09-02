// Decompiled with JetBrains decompiler
// Type: MaterialController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MaterialController : BattleMonoBehaviour
{
  private UnityEngine.Shader grayScaleShader;

  public void Initialize() => this.grayScaleShader = UnityEngine.Shader.Find("Custom/LegacyDiffuseGrayScale");

  public UnityEngine.Material[] CreateGrayScaleMaterial(Renderer render)
  {
    if ((Object) this.grayScaleShader == (Object) null)
      this.Initialize();
    UnityEngine.Material[] materials = render.materials;
    UnityEngine.Material[] materialArray = new UnityEngine.Material[materials.Length];
    for (int index = 0; index < materials.Length; ++index)
    {
      UnityEngine.Material material = new UnityEngine.Material(materials[index]);
      material.shader = this.grayScaleShader;
      material.color = new Color(0.5529412f, 0.5529412f, 0.5529412f);
      material.EnableKeyword("_APPLY_GRAYSCALE_ON");
      materialArray[index] = material;
    }
    return materialArray;
  }

  public UnityEngine.Material[] CreateGrayScaleMaterial(UnityEngine.Material[] targetMaterials)
  {
    if ((Object) this.grayScaleShader == (Object) null)
      this.Initialize();
    UnityEngine.Material[] materialArray1 = targetMaterials;
    UnityEngine.Material[] materialArray2 = new UnityEngine.Material[materialArray1.Length];
    for (int index = 0; index < materialArray1.Length; ++index)
    {
      UnityEngine.Material material = new UnityEngine.Material(materialArray1[index]);
      material.shader = this.grayScaleShader;
      material.color = new Color(0.5529412f, 0.5529412f, 0.5529412f);
      material.EnableKeyword("_APPLY_GRAYSCALE_ON");
      materialArray2[index] = material;
    }
    return materialArray2;
  }
}
