// Decompiled with JetBrains decompiler
// Type: ParticleClippingController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class ParticleClippingController : MonoBehaviour
{
  [SerializeField]
  private float delay = 0.2f;
  private UIPanel panel;
  private Vector3 prevPanelParentPosition;
  private Vector3 currentPanelParentPosition;
  private Vector3 localLeftTop;
  private Vector3 localRightBottom;
  private Vector3 worldLeftTop;
  private Vector3 worldRightBottom;
  private int standardHeight = 960;
  private Coroutine updateParticlesWithDelayCoroutine;
  public float UIRootHeight;
  public float resolutionFactor = 1f;
  public Vector4 worldClipRegion;
  public bool isInitialized;

  private void Start()
  {
    this.panel = this.GetComponentInParent<UIPanel>();
    if (!((Object) this.panel != (Object) null) || !((Object) this.panel.transform.parent != (Object) null))
      return;
    this.prevPanelParentPosition = this.panel.transform.parent.position;
  }

  private void Update()
  {
    if (!this.isInitialized && this.updateParticlesWithDelayCoroutine == null)
    {
      this.updateParticlesWithDelayCoroutine = this.StartCoroutine(this.UpdateParticlesWithDelay());
    }
    else
    {
      if (!((Object) this.panel != (Object) null) || !((Object) this.panel.transform.parent != (Object) null))
        return;
      this.currentPanelParentPosition = this.panel.transform.parent.position;
      if (!(this.currentPanelParentPosition != this.prevPanelParentPosition))
        return;
      this.UpdateClipRegion();
      this.prevPanelParentPosition = this.currentPanelParentPosition;
    }
  }

  private IEnumerator UpdateParticlesWithDelay()
  {
    yield return (object) new WaitForSeconds(this.delay);
    this.UpdateScaleFactor();
    this.UpdateClipRegion();
    this.isInitialized = true;
  }

  private void UpdateScaleFactor()
  {
    this.UIRootHeight = (float) this.GetComponentInParent<UIRoot>().manualHeight;
    this.resolutionFactor = (float) this.standardHeight / this.UIRootHeight;
  }

  private void UpdateClipRegion()
  {
    if ((Object) this.panel != (Object) null && this.panel.clipping != UIDrawCall.Clipping.None && this.panel.clipping != UIDrawCall.Clipping.ConstrainButDontClip)
    {
      this.localLeftTop = new Vector3(this.panel.finalClipRegion.x - this.panel.finalClipRegion.z * 0.5f, this.panel.finalClipRegion.y + this.panel.finalClipRegion.w * 0.5f, 0.0f);
      this.localRightBottom = new Vector3(this.panel.finalClipRegion.x + this.panel.finalClipRegion.z * 0.5f, this.panel.finalClipRegion.y - this.panel.finalClipRegion.w * 0.5f, 0.0f);
      this.worldLeftTop = this.panel.transform.localToWorldMatrix.MultiplyPoint3x4(this.localLeftTop);
      this.worldRightBottom = this.panel.transform.localToWorldMatrix.MultiplyPoint3x4(this.localRightBottom);
    }
    else
    {
      this.worldLeftTop = new Vector3(-1000f, 1000f, 0.0f);
      this.worldRightBottom = new Vector3(1000f, -1000f, 0.0f);
    }
    this.worldClipRegion = new Vector4(this.worldLeftTop.x, this.worldLeftTop.y, this.worldRightBottom.x, this.worldRightBottom.y);
  }

  private void OnDisable()
  {
    this.isInitialized = false;
    this.updateParticlesWithDelayCoroutine = (Coroutine) null;
  }
}
