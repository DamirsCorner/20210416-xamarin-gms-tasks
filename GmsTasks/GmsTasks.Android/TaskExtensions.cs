using Android.Gms.Tasks;
using System.Threading.Tasks;

namespace GmsTasks.Droid
{
    public static class TaskExtensions
    {
        public static Task<Java.Lang.Object> ToAwaitableTask(this Android.Gms.Tasks.Task task)
        {
            var taskCompletionSource = new TaskCompletionSource<Java.Lang.Object>();
            var taskCompleteListener = new TaskCompleteListener(taskCompletionSource);
            task.AddOnCompleteListener(taskCompleteListener);

            return taskCompletionSource.Task;
        }

        private class TaskCompleteListener : Java.Lang.Object, IOnCompleteListener
        {
            private readonly TaskCompletionSource<Java.Lang.Object> taskCompletionSource;

            public TaskCompleteListener(TaskCompletionSource<Java.Lang.Object> taskCompletionSource)
            {
                this.taskCompletionSource = taskCompletionSource;
            }

            public void OnComplete(Android.Gms.Tasks.Task task)
            {
                if (task.IsCanceled)
                {
                    this.taskCompletionSource.SetCanceled();
                }
                else if (task.IsSuccessful)
                {
                    this.taskCompletionSource.SetResult(task.Result);
                }
                else
                {
                    this.taskCompletionSource.SetException(task.Exception);
                }
            }
        }
    }
}