namespace ToDo.Domain.Exceptions;

public class NotFoundException(string message) : Exception(message);