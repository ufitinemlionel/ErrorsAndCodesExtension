// ------------------------------------------------------------
// 
// Copyright (c) Jiří Polášek. All rights reserved.
// 
// ------------------------------------------------------------

using System.Collections.Generic;

namespace JPSoftworks.ErrorsAndCodes.Helpers;

internal class LookupSetDictionary<TKey, TValue> : Dictionary<TKey, ISet<TValue>>
    where TKey : notnull
    where TValue : notnull
{
    public IEqualityComparer<TValue>? ValueComparer { private get; init; }

    public LookupSetDictionary() : base()
    {
    }

    public LookupSetDictionary(IEqualityComparer<TKey>? keyComparer) : base(keyComparer)
    {
    }

    public bool Add(TKey key, TValue value)
    {
        if (!this.ContainsKey(key))
        {
            this[key] = new HashSet<TValue>(ValueComparer ?? EqualityComparer<TValue>.Default);
        }

        return this[key].Add(value);
    }

    public bool Contains(TKey key, TValue value)
    {
        return this.TryGetValue(key, out var values) && values.Contains(value);
    }
}

internal static class DictionaryExtensions
{
    public static bool AddCore<TKey, TValue>(
        this IDictionary<TKey, ICollection<TValue>> dictionary,
        TKey key,
        TValue value)
        where TKey : notnull
    {
        if (!dictionary.TryGetValue(key, out var values))
        {
            values = new List<TValue>();
            dictionary[key] = values;
        }

        if (values.Contains(value))
        {
            return false;
        }

        values.Add(value);
        return true;
    }

    public static bool Add<TKey, TValue>(this Dictionary<TKey, List<TValue>> dictionary, TKey key, TValue value)
        where TKey : notnull
    {
        if (!dictionary.TryGetValue(key, out var values))
        {
            values = new List<TValue>();
            dictionary[key] = values;
        }

        if (values.Contains(value))
        {
            return false;
        }

        values.Add(value);
        return true;
    }
}