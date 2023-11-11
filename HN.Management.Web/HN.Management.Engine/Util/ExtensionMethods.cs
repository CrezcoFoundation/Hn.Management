using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq.Expressions;
using System.Linq;
using System.Reflection;
using System;

namespace HN.Management.Engine.Util
{
    public static class ExtensionMethods
    {
        private const string Yes = "yes";
        private const string Y = "y";
        private const string True = "true";
        private const string One = "1";
        private const string No = "no";
        private const string N = "n";
        private const string False = "false";
        private const string Zero = "0";

        public static IEnumerable<T> ApplyOrdering<T>(this IEnumerable<T> source, SortDirection sortDirection, string sortField)
        {
            object GetProperty(T instance) => instance.GetType().GetProperty(sortField, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)?.GetValue(instance);
            if (sortField != null && sortDirection != SortDirection.None)
            {
                if (sortDirection == SortDirection.Ascending)
                {
                    return source.OrderBy(GetProperty);
                }
                else
                {
                    return source.OrderByDescending(GetProperty);
                }
            }

            return source;
        }

        public static IQueryable<T> ApplyOrdering<T, TKey>(this IQueryable<T> source, SortDirection sortDirection, Expression<Func<T, TKey>> keySelector)
        {
            if (keySelector != null && sortDirection != SortDirection.None)
            {
                return sortDirection == SortDirection.Ascending
                    ? source.OrderBy(keySelector)
                    : source.OrderByDescending(keySelector);
            }

            return source;
        }

        /// <summary>
        /// Notes :: Composite Index must be added to the CosmosDB collection
        /// Azure Portal > Resource Group > [cosmosdb-resource] > Data Explorer > Settings > Indexing Policy
        /// </summary>
        /// <typeparam name="T">Source queryable type</typeparam>
        /// <typeparam name="TKey">Sort predicate return type</typeparam>
        public static IQueryable<T> ApplyMultiOrdering<T, TKey>(
            this IQueryable<T> source,
            IList<(Expression<Func<T, TKey>> sortPredicate, SortDirection sortDirection)> sortOperations)
        {
            if (!sortOperations.Any())
            {
                return source;
            }

            var headOperation = sortOperations.Head();
            var query = headOperation.sortDirection == SortDirection.Ascending
                ? source.OrderBy(headOperation.sortPredicate)
                : source.OrderByDescending(headOperation.sortPredicate);

            for (var index = 1; index < sortOperations.Count; index++)
            {
                var (sortPredicate, sortDirection) = sortOperations[index];
                query = sortDirection == SortDirection.Ascending
                    ? query.ThenBy(sortPredicate)
                    : query.ThenByDescending(sortPredicate);
            }

            return query;
        }

        public static IQueryable<T> ApplyPredicate<T>(
            this IQueryable<T> source,
            Func<IQueryable<T>, IQueryable<T>> predicate) => predicate(source);

        public static IList<string> CsvToList(this string source) => source?.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList() ?? new List<string>();

        public static TAttribute GetAttribute<TAttribute>(this Enum value)
           where TAttribute : Attribute
        {
            var enumType = value.GetType();
            var name = Enum.GetName(enumType, value);
            return enumType.GetField(name).GetCustomAttributes(false).OfType<TAttribute>().SingleOrDefault();
        }

        public static string GetDescription(this Enum enumValue)
        {
            var descriptionAttribute = enumValue.GetAttribute<DescriptionAttribute>();
            return descriptionAttribute is null
                ? enumValue.ToString()
                : descriptionAttribute.Description;
        }

        public static bool? TextToNullableBool(this string value)
        {
            if (value is null)
            {
                return null;
            }

            switch (value.ToLower(CultureInfo.InvariantCulture))
            {
                case Yes:
                case Y:
                case True:
                case One:
                    return true;
                case No:
                case N:
                case False:
                case Zero:
                    return false;
                default:
                    break;
            }

            return null;
        }

        public static bool TextToBool(this string value)
        {
            if (value is null)
            {
                return false;
            }

            switch (value.ToLower(CultureInfo.InvariantCulture))
            {
                case Yes:
                case Y:
                case True:
                case One:
                    return true;
                case No:
                case N:
                case False:
                case Zero:
                    return false;
                default:
                    break;
            }

            return false;
        }

        public static bool DictionaryEquals<TKey, TValue>(this IDictionary<TKey, TValue> first, IDictionary<TKey, TValue> second, IEqualityComparer<TValue> valueComparer = null)
        {
            if (first == second)
            {
                return true;
            }

            if ((first == null) || (second == null))
            {
                return false;
            }

            if (first.Count != second.Count)
            {
                return false;
            }

            valueComparer ??= EqualityComparer<TValue>.Default;

            foreach (var kvp in first)
            {
                if (!second.TryGetValue(kvp.Key, out var secondValue))
                {
                    return false;
                }

                if (!valueComparer.Equals(kvp.Value, secondValue))
                {
                    return false;
                }
            }

            return true;
        }

        public static string ConverDateTimeOffsetToDateString(DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.LocalDateTime.ToShortDateString();
        }

        public static string ConverDateTimeOffsetToPSTGeneralShortDateString(DateTimeOffset dateTimeOffset)
        {
            var pstZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            var pstDateTime = TimeZoneInfo.ConvertTimeFromUtc(dateTimeOffset.UtcDateTime, pstZone);
            return pstDateTime.ToString("g");
        }
    }
}
