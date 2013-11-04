using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace JustWeather.ViewModels
{
    public static class AsyncCatcher
    {
        public static async Task Try(Func<Task> asyncAction)
        {
            await asyncAction();
        }

        public static async Task Catch<TException>(this Task task, Func<TException, Task> handleExceptionAsync, bool rethrow = false)
            where TException : Exception
        {
            TException exception = null;
            try
            {
                await task;
            }
            catch (TException ex)
            {
                exception = ex;
            }

            if (exception != null)
            {
                await handleExceptionAsync(exception);
                if (rethrow)
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }
            }
        }
    }
}
