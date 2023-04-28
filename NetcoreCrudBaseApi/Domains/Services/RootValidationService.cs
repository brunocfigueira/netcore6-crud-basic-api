using System.Runtime.InteropServices;
using System;
using NetcoreCrudBaseApi.Infrastructure.Exceptions;
using NetcoreCrudBaseApi.Infrastructure.Responses;

namespace NetcoreCrudBaseApi.Domains.Services;

public static class RootValidationService
{

    public enum ERoot
    {
        PROFILEID = 1,
        USERID = 1,
        PERMISSIONID = 1
    }
    public static bool IsRootProfile(long profileId)
    {
        return (long)ERoot.PROFILEID == profileId;
    }
    public static bool IsRootUser(long userId)
    {
        return (long)ERoot.USERID == userId;
    }
    public static bool IsRootPermission(long PermissionId)
    {
        return (long)ERoot.PERMISSIONID == PermissionId;
    }

    public static void VerifyRootProfile(long profileId)
    {
        if (IsRootProfile(profileId))
        {
            throw ForbiddenAccessException.EmitMessage(ResponseForbidden.MsgRootProfileChange);
        }
    }
    public static void VerifyRootUser(long userId)
    {
        if (IsRootProfile(userId))
        {
            throw ForbiddenAccessException.EmitMessage(ResponseForbidden.MsgRootUserChange);
        }
    }

    public static void VerifyRootPermission(long permissionId)
    {
        if (IsRootProfile(permissionId))
        {
            throw ForbiddenAccessException.EmitMessage(ResponseForbidden.MsgRootPermissionChange);
        }
    }
}
