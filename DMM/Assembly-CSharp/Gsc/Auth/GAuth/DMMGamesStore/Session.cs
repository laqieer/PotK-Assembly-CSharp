// Decompiled with JetBrains decompiler
// Type: Gsc.Auth.GAuth.DMMGamesStore.Session
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using Gsc.Core;
using Gsc.Device;
using Gsc.DOM.Json;
using Gsc.Network;
using Gsc.Tasks;
using System;
using System.Collections;
using UnityEngine;

namespace Gsc.Auth.GAuth.DMMGamesStore
{
  public class Session : Gsc.Auth.GAuth.GAuth.Session
  {
    private static IEnumerator UpdateAccessToken(Session session)
    {
      yield return (object) new WaitForSeconds(1800f);
      WebTaskResult verifyResult = WebTaskResult.None;
      while (true)
      {
        if (verifyResult == WebTaskResult.None)
        {
          WebTask<Gsc.Auth.GAuth.GAuth.API.Request.AccessTokenVerify, Gsc.Auth.GAuth.GAuth.API.Response.AccessTokenVerify> verify = new Gsc.Auth.GAuth.GAuth.API.Request.AccessTokenVerify().GetTask(WebTaskAttribute.Reliable | WebTaskAttribute.Silent | WebTaskAttribute.Parallel).SetAcceptResults(WebTaskResult.kLocalResult | WebTaskResult.kGrobalResult | WebTaskResult.kCreticalError | WebTaskResult.Maintenance | WebTaskResult.UpdateApplication | WebTaskResult.InternalExpiredTokenError);
          yield return (object) verify;
          verifyResult = verify.Result;
          verify = (WebTask<Gsc.Auth.GAuth.GAuth.API.Request.AccessTokenVerify, Gsc.Auth.GAuth.GAuth.API.Response.AccessTokenVerify>) null;
        }
        if ((verifyResult & (WebTaskResult.Success | WebTaskResult.InternalExpiredTokenError)) > WebTaskResult.None)
        {
          WebTask<Gsc.Auth.GAuth.DMMGamesStore.API.Request.AccessToken, Gsc.Auth.GAuth.GAuth.API.Response.AccessToken> token = new Gsc.Auth.GAuth.DMMGamesStore.API.Request.AccessToken(Gsc.Auth.GAuth.DMMGamesStore.Device.Instance.ViewerId, Gsc.Auth.GAuth.DMMGamesStore.Device.Instance.OnetimeToken).GetTask(WebTaskAttribute.Reliable | WebTaskAttribute.Silent).SetAcceptResults(WebTaskResult.kLocalResult | WebTaskResult.kGrobalResult | WebTaskResult.kCreticalError | WebTaskResult.Maintenance | WebTaskResult.UpdateApplication | WebTaskResult.InternalExpiredTokenError);
          yield return (object) token;
          if ((token.Result & (WebTaskResult.Success | WebTaskResult.InternalExpiredTokenError)) > WebTaskResult.None)
          {
            verifyResult = WebTaskResult.None;
            session.AccessToken = token.Response.Token;
            yield return (object) new WaitForSeconds(1800f);
            continue;
          }
          if ((token.Result & WebTaskResult.ServerError) > WebTaskResult.None)
          {
            yield return (object) new WaitForSeconds(1f);
            continue;
          }
          if ((token.Result & (WebTaskResult.ExpiredSessionError | WebTaskResult.InvalidDeviceError)) <= WebTaskResult.None)
            token = (WebTask<Gsc.Auth.GAuth.DMMGamesStore.API.Request.AccessToken, Gsc.Auth.GAuth.GAuth.API.Response.AccessToken>) null;
          else
            break;
        }
        else if ((verifyResult & (WebTaskResult.ExpiredSessionError | WebTaskResult.InvalidDeviceError)) <= WebTaskResult.None)
          verifyResult = WebTaskResult.None;
        else
          goto label_9;
        yield return (object) new WaitForSeconds(30f);
      }
      yield break;
label_9:;
    }

    public override string DeviceID => Gsc.Auth.GAuth.DMMGamesStore.Device.Instance.ViewerId.ToString();

    public Session(string envName, IAccountManager accountManager)
      : base(envName, accountManager)
      => ImmortalObject.Instance.StartCoroutine(Session.UpdateAccessToken(this));

    public override bool CanRefreshToken(System.Type requestType) => !requestType.Equals(typeof (Gsc.Auth.GAuth.DMMGamesStore.API.Request.AccessToken));

    public override IRefreshTokenTask GetRefreshTokenTask() => (IRefreshTokenTask) new Session.RefreshTokenTask(this);

    public override IWebTask RegisterEmailAddressAndPassword(
      string email,
      string password,
      bool disableValicationEmail,
      Action<RegisterEmailAddressAndPasswordResult> callback)
    {
      return (IWebTask) new Gsc.Auth.GAuth.DMMGamesStore.API.Request.RegisterEmailAddressAndPassword(Gsc.Auth.GAuth.DMMGamesStore.Device.Instance.ViewerId, Gsc.Auth.GAuth.DMMGamesStore.Device.Instance.OnetimeToken, email, password)
      {
        DisableValidationEmail = disableValicationEmail
      }.Send().OnResponse((VoidCallbackWithError<Gsc.Auth.GAuth.DMMGamesStore.API.Request.RegisterEmailAddressAndPassword.Response>) ((response, error) => callback(Session.GetRegisterEmailAddressWithPasswordResult(response, (Gsc.Auth.GAuth.GAuth.API.Response.ErrorResponse) error))));
    }

    private static RegisterEmailAddressAndPasswordResult GetRegisterEmailAddressWithPasswordResult(
      Gsc.Auth.GAuth.DMMGamesStore.API.Request.RegisterEmailAddressAndPassword.Response response,
      Gsc.Auth.GAuth.GAuth.API.Response.ErrorResponse error)
    {
      if (error == null)
        return new RegisterEmailAddressAndPasswordResult(RegisterEmailAddressAndPasswordResultCode.Success);
      RegisterEmailAddressAndPasswordResultCode resultCode = RegisterEmailAddressAndPasswordResultCode.UnknownError;
      string errorCode = error.ErrorCode;
      if (!(errorCode == "invalied_email"))
      {
        if (!(errorCode == "invalied_password"))
        {
          if (errorCode == "duplicated_email")
          {
            resultCode = RegisterEmailAddressAndPasswordResultCode.DuplicatedEmailAddress;
          }
          else
          {
            Value root = error.data.Root;
            if (root.GetValueByPointer("/reason/email", (string) null) != null)
            {
              resultCode = RegisterEmailAddressAndPasswordResultCode.InvalidEmailAddress;
            }
            else
            {
              root = error.data.Root;
              if (root.GetValueByPointer("/reason/password", (string) null) != null)
                resultCode = RegisterEmailAddressAndPasswordResultCode.InvalidPassword;
            }
          }
        }
        else
          resultCode = RegisterEmailAddressAndPasswordResultCode.InvalidPassword;
      }
      else
        resultCode = RegisterEmailAddressAndPasswordResultCode.InvalidEmailAddress;
      return new RegisterEmailAddressAndPasswordResult(resultCode);
    }

    public override IWebTask AddDeviceWithEmailAddressAndPassword(
      string email,
      string password,
      Action<AddDeviceWithEmailAddressAndPasswordResult> callback)
    {
      return (IWebTask) new Gsc.Auth.GAuth.DMMGamesStore.API.Request.AddDeviceWithEmailAddressAndPassword(Gsc.Auth.GAuth.DMMGamesStore.Device.Instance.ViewerId, Gsc.Auth.GAuth.DMMGamesStore.Device.Instance.OnetimeToken, email, password).Send().OnResponse((VoidCallbackWithError<Gsc.Auth.GAuth.DMMGamesStore.API.Request.AddDeviceWithEmailAddressAndPassword.Response>) ((response, error) => callback(Session.GetAddDeviceWithEmailAddressAndPassword((Gsc.Auth.GAuth.GAuth.API.Response.ErrorResponse) error))));
    }

    private static AddDeviceWithEmailAddressAndPasswordResult GetAddDeviceWithEmailAddressAndPassword(
      Gsc.Auth.GAuth.GAuth.API.Response.ErrorResponse error)
    {
      if (error == null)
        return new AddDeviceWithEmailAddressAndPasswordResult(AddDeviceWithEmailAddressAndPasswordResultCode.Success);
      AddDeviceWithEmailAddressAndPasswordResultCode resultCode = AddDeviceWithEmailAddressAndPasswordResultCode.UnknownError;
      string errorCode = error.ErrorCode;
      Value root;
      if (!(errorCode == "missing_device_id"))
      {
        if (!(errorCode == "missing_email_or_password"))
        {
          if (errorCode == "locked")
          {
            resultCode = AddDeviceWithEmailAddressAndPasswordResultCode.Locked;
          }
          else
          {
            root = error.data.Root;
            if (root.GetValueByPointer("/reason/email", (string) null) != null)
            {
              resultCode = AddDeviceWithEmailAddressAndPasswordResultCode.MissingEmailOrPassword;
            }
            else
            {
              root = error.data.Root;
              if (root.GetValueByPointer("/reason/password", (string) null) != null)
                resultCode = AddDeviceWithEmailAddressAndPasswordResultCode.MissingEmailOrPassword;
            }
          }
        }
        else
          resultCode = AddDeviceWithEmailAddressAndPasswordResultCode.MissingEmailOrPassword;
      }
      else
        resultCode = AddDeviceWithEmailAddressAndPasswordResultCode.MissingDeviceId;
      if (resultCode != AddDeviceWithEmailAddressAndPasswordResultCode.Locked)
        return new AddDeviceWithEmailAddressAndPasswordResult(resultCode);
      int num = (int) resultCode;
      root = error.data.Root;
      root = root["expires_in"];
      int lockedExpiresIn = root.ToInt();
      root = error.data.Root;
      root = root["trial_counter"];
      int trialCounter = root.ToInt();
      return new AddDeviceWithEmailAddressAndPasswordResult((AddDeviceWithEmailAddressAndPasswordResultCode) num, lockedExpiresIn, trialCounter);
    }

    public new class RefreshTokenTask : IRefreshTokenTask, ITask
    {
      private readonly Session session;

      public WebTaskResult Result { get; protected set; }

      public bool isDone { get; protected set; }

      public RefreshTokenTask(Session session) => this.session = session;

      public void OnStart()
      {
      }

      public void OnFinish()
      {
      }

      public IEnumerator Run()
      {
        WebInternalTask<Gsc.Auth.GAuth.DMMGamesStore.API.Request.AccessToken, Gsc.Auth.GAuth.GAuth.API.Response.AccessToken> task = WebInternalTask.Create<Gsc.Auth.GAuth.DMMGamesStore.API.Request.AccessToken, Gsc.Auth.GAuth.GAuth.API.Response.AccessToken>((Gsc.Network.Request<Gsc.Auth.GAuth.DMMGamesStore.API.Request.AccessToken, Gsc.Auth.GAuth.GAuth.API.Response.AccessToken>) new Gsc.Auth.GAuth.DMMGamesStore.API.Request.AccessToken(Gsc.Auth.GAuth.DMMGamesStore.Device.Instance.ViewerId, Gsc.Auth.GAuth.DMMGamesStore.Device.Instance.OnetimeToken));
        task.OnStart();
        yield return (object) task.Run();
        task.OnFinish();
        this.Result = task.Result;
        if (task.Result == WebTaskResult.Success)
        {
          this.session.AccessToken = task.Response.Token;
          this.isDone = true;
        }
      }
    }
  }
}
