namespace NetcoreCrudBaseApi.Infrastructure.Responses;

public record struct ResponseErrors(bool error, string message, object? content)
{
    public const string MsgHasProfilePermissions = "Este perfil já possui permissões vinculadas. Tente atualizar o cadastro.";
    public const string MsgViolationPermissionId = "Não é permitido vinculuar permissão inexistente para este perfil.";
    public const string MsgViolationProfileIdPermission = "Não é permitido o vínculo de perfil inativo ou inexistente.";
    public const string MsgViolationUserProfileId = "Não é permitido vincular perfil inativo ou inexistente para este usuário.";
    public const string MsgViolationParamRequest = "Violação de parâmetro na requeisição";
    public const string MsgArgumentNotValid = "Detecção de um ou mais erros de validação";
    public const string MsgUnexpected = "Ocoreu um erro inesperado durante a execução de processo";
    public const string MsgInvalidCredentials = "Credenciais Inválidas";

    public static ResponseErrors ArgumentNotValid(object? content) => new(true, MsgArgumentNotValid, content);


    public static ResponseErrors RuleViolation(string message) => new(true, message, null);
    public static ResponseErrors InvalidCredentials() => new(true, MsgInvalidCredentials, null);

    public static ResponseErrors Unexpected() => new(true, MsgUnexpected, null);

}
