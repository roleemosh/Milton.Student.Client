using Milton.Blazor.Shared.Models;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Milton.Blazor.Shared.Helpers
{
    public static class HelperMethods
    {
        public static void FastIteration<T>(this List<T> @base, Action<T> action)
        {
            Span<T> subjectSpan = CollectionsMarshal.AsSpan(@base);
            ref T pointer = ref MemoryMarshal.GetReference(subjectSpan);

            for (int i = 0; i < subjectSpan.Length; i++)
            {
                T subject = Unsafe.Add(ref pointer, i);
                action.Invoke(subject);
            }
        }
    }
}
