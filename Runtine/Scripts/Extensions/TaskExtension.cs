// MIT License
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Collections;
using System.Threading.Tasks;

namespace StarForge.Utils
{
    /// <summary>
    /// Provides extension methods for the <see cref="Task"/> class to facilitate its usage in Unity.
    /// </summary>
    public static class TaskExtension
    {
        /// <summary>
        /// Converts the <see cref="Task"/> into an <see cref="IEnumerator"/> for Unity coroutine usage.
        /// </summary>
        /// <param name="task">The <see cref="Task"/> to convert.</param>
        /// <returns>An <see cref="IEnumerator"/> representation of the <see cref="Task"/>.</returns>
        public static IEnumerator AsCoroutine(this Task task) {
            while (!task.IsCompleted) yield return null;
            // When used on a faulted Task, GetResult() will propagate the original exception.
            // see: https://devblogs.microsoft.com/pfxteam/task-exception-handling-in-net-4-5/
            task.GetAwaiter().GetResult();
        }

        /// <summary>
        /// Marks a <see cref="Task"/> to be forgotten, meaning any exceptions thrown by the task will be caught and handled.
        /// </summary>
        /// <param name="task">The <see cref="Task"/> to be forgotten.</param>
        /// <param name="onException">The optional action to execute when an exception is caught. If provided, the exception will not be rethrown.</param>
        public static async void Forget(this Task task, Action<Exception> onException = null) {
            try {
                await task;
            }
            catch (Exception exception) {
                if (onException == null)
                    throw;

                onException(exception);
            }
        }
    }
}