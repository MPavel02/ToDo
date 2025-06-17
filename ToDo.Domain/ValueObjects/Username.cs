namespace ToDo.Domain.ValueObjects;

/// <summary>
/// Имя пользователя.
/// </summary>
public class Username : ValueObject
{
    /// <summary>
    /// Максимальная длина имени пользователя.
    /// </summary>
    public const int MaxLength = 64;

    public string Value { get; }

    private Username(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Имя пользователя не может быть пустым");
        
        if (IsMoreMaxLength(value))
            throw new ArgumentException($"Имя пользователя не может быть больше {MaxLength} символов");
        
        Value = value;
    }

    public static Username From(string name)
    {
        return new Username(name);
    }

    /// <summary>
    /// Проверяет максимальную длину имени.
    /// </summary>
    /// <param name="value">Значение имени пользователя.</param>
    /// <returns>Возвращает true, если длина больше допустимой, иначе false.</returns>
    private static bool IsMoreMaxLength(string value)
    {
        return value.Length > MaxLength;
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}