namespace NetcoreCrudBaseApi.Infrastructure.Responses;

public record struct ResponseForbidden(string status, string message)
{
    public const string StatusForbidden = "403_Forbidden";
    public const string MsgRootProfileChange = "Não é permitido nenhuma alteração para este perfil.";
    public const string MsgRootUserChange = "Não é permitido nenhuma alteração para este usuário.";
    public const string MsgRootPermissionChange = "Não é permitido nenhuma alteração para esta permissão.";

    public static ResponseForbidden EmitMessage(string message) => new(StatusForbidden, message);
    public static ResponseForbidden RootProfileChange() => new(StatusForbidden, MsgRootProfileChange);
    public static ResponseForbidden RootUserChange() => new(StatusForbidden, MsgRootUserChange);
    public static ResponseForbidden RootPermissionChange() => new(StatusForbidden, MsgRootPermissionChange);
}
