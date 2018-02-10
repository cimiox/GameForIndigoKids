using Model;

/// <summary>
/// Базовый класс для фабрики алфавита
/// </summary>
public abstract class AlphabetFactory
{
    public abstract Alphabet CreateAlphabet();
}
