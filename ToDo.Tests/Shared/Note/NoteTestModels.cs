namespace ToDo.Tests.Shared.Note;

/// <summary>
/// Упрощенная модель заметки для тестирования.
/// </summary>
/// <param name="ID">Идентификатор заметки.</param>
/// <param name="Title">Название заметки.</param>
/// <param name="Details">Детали заметки.</param>
public record NoteTestModel(
    Guid ID,
    string Title,
    string Details);
    
/// <summary>
/// Упрощенная модель заметки для тестирования.
/// </summary>
/// <param name="Title">Название заметки.</param>
/// <param name="Details">Детали заметки.</param>
public record NoteTestModelWithoutID(
    string Title,
    string Details);