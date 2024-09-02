// Decompiled with JetBrains decompiler
// Type: DuelCameraManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DuelCameraManager : MonoBehaviour
{
  public float smoothTime = 0.1f;
  [SerializeField]
  public GameObject duelCamera;
  [SerializeField]
  public GameObject koyuCamera;
  private GameObject subCamera;
  private bool isInitialized;
  private bool camelaLastMove;
  [SerializeField]
  private Transform lookat;
  [SerializeField]
  private Transform lookat_center;
  [SerializeField]
  private Transform lookat_attacker;
  [SerializeField]
  private Transform lookat_defender;
  public Transform lookat_bullet;
  public float MaxFarCameraZ = 20f;
  public float MinNearCameraZ = 2f;
  public bool IsShowCameraName;
  private Vector3 originalPosition;
  private static readonly Quaternion RotationWinAnimator = Quaternion.Euler(0.0f, 90f, 0.0f);
  private static readonly Vector3 PositionWinCam_r1 = new Vector3(0.0f, 0.0f, 2.5f);
  private static readonly Vector3 PositionWinCam_01 = new Vector3(0.0f, 0.0f, 5f);

  public GameObject currentCamera
  {
    get
    {
      try
      {
        return this.duelCamera.activeInHierarchy ? this.duelCamera.gameObject : this.koyuCamera.gameObject;
      }
      catch (MissingReferenceException ex)
      {
        return (GameObject) null;
      }
    }
  }

  public void Initialize()
  {
    if (this.isInitialized)
    {
      this.duelCamera.gameObject.SetActive(true);
      this.duelCamera.transform.position = this.originalPosition;
      ((Behaviour) this.duelCamera.GetComponent<Camera>()).enabled = false;
      ((Behaviour) this.subCamera.GetComponent<Camera>()).enabled = false;
      ((Behaviour) this.koyuCamera.GetComponentsInChildren<Camera>(true)[0]).enabled = false;
    }
    else
    {
      this.duelCamera = GameObject.Find("CameraFirst");
      this.duelCamera.gameObject.SetActive(true);
      this.originalPosition = this.duelCamera.transform.position;
      this.subCamera = GameObject.Find("CameraChg");
      this.subCamera.gameObject.transform.parent = this.duelCamera.gameObject.transform;
      this.subCamera.transform.localPosition = Vector3.zero;
      this.subCamera.transform.localRotation = Quaternion.identity;
      ((Behaviour) this.duelCamera.GetComponent<Camera>()).enabled = false;
      ((Behaviour) this.subCamera.GetComponent<Camera>()).enabled = false;
      ((Behaviour) this.koyuCamera.GetComponentsInChildren<Camera>(true)[0]).enabled = false;
      this.isInitialized = true;
    }
  }

  public void Reset()
  {
    if (!Object.op_Inequality((Object) this.duelCamera, (Object) null))
      return;
    this.duelCamera.transform.parent = ((Component) this).transform;
  }

  public void ActAttackBeginCamera(DuelResult result, NGDuelUnit myUnit)
  {
    if (!result.isBossBattle)
    {
      if (result.isPlayerAttack)
      {
        if (result.distance > 1)
          this.StartCoroutine(this.changeCamera("attackBeginCam_magic"));
        else if (result.attackAttackStatus.isMagic)
          this.StartCoroutine(this.changeCamera("attackBeginCam_magic_r1"));
        else if (result.attack.job.move_type == UnitMoveType.hikou)
          this.StartCoroutine(this.changeCamera("attackBeginCam_fly"));
        else
          this.StartCoroutine(this.changeCamera("attackBeginCam_01"));
      }
      else
        this.StartCoroutine(this.changeCamera(string.Empty));
    }
    else if (result.isPlayerAttack)
      this.StartCoroutine(this.changeCamera("BossBattleAttackBeginCam_01"));
    else
      this.StartCoroutine(this.changeCamera("2PBossBattleAttackBeginCam_01"));
  }

  public void ActKoyuCamera(RuntimeAnimatorController rac)
  {
    this.koyuCamera.gameObject.SetActive(true);
    Camera componentInChildren = this.koyuCamera.GetComponentInChildren<Camera>();
    this.subCamera.gameObject.transform.parent = this.koyuCamera.transform;
    this.subCamera.transform.localPosition = ((Component) componentInChildren).gameObject.transform.localPosition;
    this.subCamera.transform.localRotation = ((Component) componentInChildren).gameObject.transform.localRotation;
    this.koyuCamera.GetComponent<Animator>().runtimeAnimatorController = rac;
    this.duelCamera.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController) null;
    this.duelCamera.gameObject.SetActive(false);
  }

  public void EnableKoyuCamera()
  {
    ((Behaviour) this.koyuCamera.GetComponentInChildren<Camera>()).enabled = true;
  }

  public void ActEndCamera(RuntimeAnimatorController rac)
  {
  }

  public void ActCameraToMe(NGDuelUnit myUnit) => this.lookat = ((Component) myUnit).transform;

  public void ActCameraToCenter()
  {
    this.duelCamera.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController) null;
    this.lookat = this.lookat_center;
  }

  public void ActCameraToAttacker() => this.lookat = this.lookat_attacker;

  public void EndKoyuCamera()
  {
    this.ActCameraToCenter();
    this.koyuCamera.gameObject.SetActive(false);
    this.duelCamera.gameObject.SetActive(true);
    this.subCamera.gameObject.transform.parent = this.duelCamera.gameObject.transform;
    this.subCamera.transform.localPosition = Vector3.zero;
    this.subCamera.transform.localRotation = Quaternion.identity;
  }

  [DebuggerHidden]
  public IEnumerator changeCamera(string cameraName, Transform parent = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DuelCameraManager.\u003CchangeCamera\u003Ec__Iterator7DB()
    {
      cameraName = cameraName,
      parent = parent,
      \u003C\u0024\u003EcameraName = cameraName,
      \u003C\u0024\u003Eparent = parent,
      \u003C\u003Ef__this = this
    };
  }

  public void updateLookatPosition(
    float distance,
    NGDuelUnit myUnit,
    NGDuelUnit enemyUnit,
    bool isPlayerAttack)
  {
    Vector3 position1 = this.lookat_center.position;
    position1.x = ((Component) myUnit).transform.position.x - distance / 2f;
    this.lookat_center.position = position1;
    Vector3 position2 = this.lookat_attacker.position;
    position2.x = ((Component) myUnit).transform.position.x - 1f;
    this.lookat_attacker.position = position2;
    this.lookat_defender.position.x = ((Component) enemyUnit).transform.position.x + 1f;
    this.lookat_defender.position = position2;
    Vector3 position3 = this.duelCamera.transform.position;
    if (Object.op_Equality((Object) this.lookat, (Object) this.lookat_attacker))
      this.duelCamera.transform.LookAt(this.lookat_attacker);
    else if (Object.op_Equality((Object) this.lookat, (Object) this.lookat_center))
    {
      Vector3 position4 = this.duelCamera.transform.position;
      float num = 3f * distance;
      if ((double) num < (double) this.MinNearCameraZ)
        num = this.MinNearCameraZ;
      else if ((double) num > (double) this.MaxFarCameraZ)
        num = this.MaxFarCameraZ;
      position3.z = num;
      position3.y = distance * 0.5f;
      if ((double) position3.y < 1.5)
        position3.y = 1.5f;
      position3.x = position1.x;
      if (isPlayerAttack)
      {
        if ((double) position3.x < -1.0)
          --position3.x;
      }
      else if ((double) position3.x > 1.0)
        ++position3.x;
      Vector3 zero = Vector3.zero;
      this.duelCamera.transform.position = Vector3.SmoothDamp(position4, position3, ref zero, this.smoothTime);
      this.duelCamera.transform.LookAt(((Component) this.lookat_center).transform.position);
    }
    else if (Object.op_Equality((Object) ((Component) myUnit).transform, (Object) this.lookat) && !this.camelaLastMove)
    {
      this.camelaLastMove = true;
      position3.x = -1f;
      position3.z = 1f;
      position3.y = 0.5f;
      if (Vector3.op_Inequality(this.duelCamera.transform.position, position3))
        this.duelCamera.transform.position = position3;
      this.duelCamera.transform.LookAt(((Component) myUnit).transform);
    }
    else if (Object.op_Equality((Object) this.lookat, (Object) this.lookat_bullet))
      this.duelCamera.transform.LookAt(this.lookat_bullet);
    this.duelCamera.GetComponent<Camera>().fieldOfView = 80f;
  }

  public void ShakeCamera() => this.StartCoroutine(this.coShakeCamera());

  public void InActiveKoyuCamera() => this.koyuCamera.SetActive(false);

  public void DisableKoyuCamera()
  {
    ((Behaviour) this.koyuCamera.GetComponentInChildren<Camera>()).enabled = false;
  }

  [DebuggerHidden]
  private IEnumerator coShakeCamera()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DuelCameraManager.\u003CcoShakeCamera\u003Ec__Iterator7DC()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void WarpCamera1stAttackPos(bool is_princess, Transform defender)
  {
    Animator component = this.duelCamera.GetComponent<Animator>();
    if (Object.op_Inequality((Object) null, (Object) component))
      component.runtimeAnimatorController = (RuntimeAnimatorController) null;
    this.duelCamera.gameObject.transform.position = !is_princess ? new Vector3(defender.position.x - 3.7f, 2.6f, 3.4f) : new Vector3(defender.position.x + 1f, 2.3f, 5f);
    this.lookat = this.lookat_attacker;
  }

  [DebuggerHidden]
  public IEnumerator WarpCamera1stAttackPosRemoteEnemy(
    Transform defender,
    float delay,
    Transform bullet)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DuelCameraManager.\u003CWarpCamera1stAttackPosRemoteEnemy\u003Ec__Iterator7DD()
    {
      delay = delay,
      defender = defender,
      bullet = bullet,
      \u003C\u0024\u003Edelay = delay,
      \u003C\u0024\u003Edefender = defender,
      \u003C\u0024\u003Ebullet = bullet,
      \u003C\u003Ef__this = this
    };
  }

  public void LookCameraBullet(Transform bullet) => this.lookat_bullet = bullet;
}
