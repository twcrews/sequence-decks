﻿namespace Crews.Education.SequenceDecks.Extensions;

public static class EnumerableExtensions
{
  public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
  {
    return source.Shuffle(new Random());
  }

  public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
  {
    ArgumentNullException.ThrowIfNull(source);
    ArgumentNullException.ThrowIfNull(rng);

    return source.ShuffleIterator(rng);
  }

  private static IEnumerable<T> ShuffleIterator<T>(
      this IEnumerable<T> source, Random rng)
  {
    var buffer = source.ToList();
    for (int i = 0; i < buffer.Count; i++)
    {
      int j = rng.Next(i, buffer.Count);
      yield return buffer[j];

      buffer[j] = buffer[i];
    }
  }
}
