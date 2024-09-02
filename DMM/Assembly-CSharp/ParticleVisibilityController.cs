// Decompiled with JetBrains decompiler
// Type: ParticleVisibilityController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ParticleVisibilityController : MonoBehaviour
{
  private ParticleSystemRenderer psRenderer;
  private UIRect parentRect;
  private ParticleClippingController pcController;
  private bool currentVisibility;
  private bool previousVisibility;
  private bool isLocaleScaleInitialized;
  private bool isClipRegionInitialized;

  private void Start()
  {
    this.parentRect = this.GetComponentInParent<UIRect>();
    this.psRenderer = this.GetComponentInChildren<ParticleSystemRenderer>(true);
    this.pcController = this.GetComponentInParent<ParticleClippingController>();
  }

  private void Update()
  {
    this.UpdateLocalScale();
    this.UpdateClipRegion();
    this.UpdateVisibility();
  }

  private void UpdateLocalScale()
  {
    if (this.isLocaleScaleInitialized)
      return;
    if ((Object) this.pcController == (Object) null || !this.pcController.isInitialized)
    {
      this.pcController = this.GetComponentInParent<ParticleClippingController>();
    }
    else
    {
      Vector3 vector3 = this.psRenderer.transform.parent.lossyScale * this.pcController.UIRootHeight * 0.5f;
      this.psRenderer.transform.localScale = new Vector3(this.pcController.resolutionFactor * vector3.x, this.pcController.resolutionFactor * vector3.y, this.pcController.resolutionFactor * vector3.z);
      this.isLocaleScaleInitialized = true;
    }
  }

  private void UpdateClipRegion()
  {
    if ((Object) this.pcController == (Object) null || !this.pcController.isInitialized)
    {
      this.pcController = this.GetComponentInParent<ParticleClippingController>();
    }
    else
    {
      this.psRenderer.material.SetVector("_WorldClipRegion", this.pcController.worldClipRegion);
      this.isClipRegionInitialized = true;
    }
  }

  private void UpdateVisibility()
  {
    if (!this.isLocaleScaleInitialized || !this.isClipRegionInitialized)
      return;
    if ((Object) this.parentRect == (Object) null)
    {
      this.parentRect = this.GetComponentInParent<UIRect>();
    }
    else
    {
      this.currentVisibility = (double) this.parentRect.finalAlpha == 1.0;
      if (this.currentVisibility == this.previousVisibility)
        return;
      this.psRenderer.gameObject.SetActive(this.currentVisibility);
      this.previousVisibility = this.currentVisibility;
    }
  }

  private void OnDisable()
  {
    this.isLocaleScaleInitialized = false;
    this.isClipRegionInitialized = false;
    if (!(bool) (Object) this.psRenderer || !(bool) (Object) this.psRenderer.gameObject)
      return;
    this.previousVisibility = false;
    this.psRenderer.gameObject.SetActive(false);
  }
}
