namespace NetcoreCrudBaseApi.Infrastructure.Responses;

public record struct ResponseMessage(bool success, string message)
{
    public const string MsgCreatedSuccess = "Registro criado com sucesso.";
    public const string MsgUpdatedSuccess = "Registro atualizado com sucesso.";
    public const string MsgDeletedSuccess = "Registro excluído com sucesso.";
    public const string MsgNotFound = "Solicitação não foi encontrada.";

    public static ResponseMessage CreatedSuccess() => new(true, MsgCreatedSuccess);
    public static ResponseMessage UpdatedSuccess() => new(true, MsgUpdatedSuccess);
    public static ResponseMessage DeletedSuccess() => new(true, MsgDeletedSuccess);
    public static ResponseMessage NotFound() => new(false, MsgNotFound);

}
