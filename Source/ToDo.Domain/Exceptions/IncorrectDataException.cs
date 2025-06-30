namespace ToDo.Domain.Exceptions;

public class IncorrectFieldException(string message, string fieldName) : Exception($"{message}. Поле: {fieldName}");