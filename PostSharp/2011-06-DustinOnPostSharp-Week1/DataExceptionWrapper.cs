using System;
using System.Diagnostics;
using PostSharp.Aspects;

namespace PostSharpDemo1
{
    [Serializable]
    public class DataExceptionWrapper : OnExceptionAspect
    {
        public override sealed void OnException(MethodExecutionArgs args)
        {
            string msg = string.Format("{0} had an error @ {1}: {2}\n{3}",
                                       args.Method.Name, DateTime.Now,
                                       args.Exception.Message, args.Exception.StackTrace);

            Trace.WriteLine(msg);

            throw new Exception("There was a problem");
        }

        public override Type GetExceptionType(System.Reflection.MethodBase targetMethod)
        {
            return typeof (InvalidOperationException);
        }
    }
}
