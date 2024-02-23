namespace Company.Function.DTOs;
public class GenericResponse<TData, TError>
{
    public TData Data { get; set; }
    public TError Error { get; set; }
}