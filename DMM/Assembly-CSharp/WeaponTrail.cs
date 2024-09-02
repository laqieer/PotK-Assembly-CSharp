// Decompiled with JetBrains decompiler
// Type: WeaponTrail
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;
using UnityEngine;

public class WeaponTrail : MonoBehaviour
{
  private WeaponTrailMeshRender meshRender;
  public Color MeshDefaultColor = new Color(0.4196078f, 0.6f, 0.627451f, 0.8235294f);
  public int MeshSplitCount = 512;
  public float MeshHeight = 1.1f;
  public float CurveVolume = 0.5f;
  public Transform CaptureTarget;
  public UnityEngine.Material WeaponTrailMaterial;

  public void On(Transform parent = null, NGDuelUnit unit = null)
  {
    if ((Object) this.meshRender != (Object) null)
      return;
    Color color = this.MeshDefaultColor;
    if ((Object) unit != (Object) null)
    {
      DuelElementTrailEffect elementTrailEffect = unit.GetElementTrailEffect();
      if (elementTrailEffect != null)
      {
        if (!string.IsNullOrEmpty(elementTrailEffect.trail_effect_name))
          Singleton<NGDuelDataManager>.GetInstance().GetPreloadDuelEffect(elementTrailEffect.trail_effect_name, this.transform.parent);
        if (elementTrailEffect.trail_color_r.HasValue && elementTrailEffect.trail_color_g.HasValue && (elementTrailEffect.trail_color_b.HasValue && elementTrailEffect.trail_color_a.HasValue))
          color = new Color((float) elementTrailEffect.trail_color_r.Value / (float) byte.MaxValue, (float) elementTrailEffect.trail_color_g.Value / (float) byte.MaxValue, (float) elementTrailEffect.trail_color_b.Value / (float) byte.MaxValue, (float) elementTrailEffect.trail_color_a.Value / (float) byte.MaxValue);
      }
    }
    GameObject gameObject = new GameObject();
    gameObject.layer = this.gameObject.layer;
    gameObject.name = "DynamicMeshRenderForWeaponTrail";
    gameObject.transform.parent = parent;
    this.meshRender = gameObject.AddComponent<WeaponTrailMeshRender>();
    this.meshRender.MeshCurrentColor = color;
    this.meshRender.MeshSplitCount = this.MeshSplitCount;
    this.meshRender.MeshHeight = this.MeshHeight;
    this.meshRender.CurveVolume = this.CurveVolume;
    this.meshRender.CaptureTarget = this.CaptureTarget;
    this.meshRender.WeaponTrailMaterial = this.WeaponTrailMaterial;
    this.meshRender.On();
  }

  public void Off()
  {
    if ((Object) this.meshRender == (Object) null)
      return;
    this.meshRender.Off();
  }
}
