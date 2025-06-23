namespace ToDo.Domain.Exceptions;

public class DuplicateEntityException<T>(string name, T id) : Exception($"Entity \"{name}\" with id = \"{id}\" is already exists.");