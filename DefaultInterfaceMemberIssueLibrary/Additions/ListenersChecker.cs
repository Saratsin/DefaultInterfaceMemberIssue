using System;

namespace DefaultInterfaceMemberIssueLibrary
{
    public static class ListenersChecker
    {
        public static void CheckListenerMethodsFromJavaWorld()
        {
            var javaListener = new ListenerImplementor();
            var csharpListener = new ListenerCSharpImplemntor();
            var javaInvoker = new ListenerInvoker();

            // This should work fine
            WrapCall(
                javaInvoker,
                javaListener,
                nameof(javaInvoker.InvokeListenerImplementorMethod),
                () => javaInvoker.InvokeListenerImplementorMethod(javaListener));
            
            // This should work fine
            WrapCall(
                javaInvoker,
                javaListener,
                nameof(javaInvoker.InvokeListenerImplementorMethod),
                () => javaInvoker.InvokeListenerMethod(javaListener));
            
            // This throws AbstractMethodError when it shouldn't
            WrapCall(
                javaInvoker,
                csharpListener,
                nameof(javaInvoker.InvokeListenerImplementorMethod),
                () => javaInvoker.InvokeListenerMethod(csharpListener));
        }
        
        public static void CheckListenerMethodsFromCSharpWorld()
        {
            var javaListener = new ListenerImplementor() as IListener;
            var csharpListener = new ListenerCSharpImplemntor()  as IListener;

            // This should work fine
            WrapCall(
                javaListener,
                false,
                nameof(javaListener.OnValueChanged),
                () => javaListener.OnValueChanged(false));
            
            // This throws AbstractMethodError when it shouldn't
            WrapCall(
                csharpListener,
                false,
                nameof(csharpListener.OnValueChanged),
                () => csharpListener.OnValueChanged(false));
        }

        private static void WrapCall(object caller, object parameter, string callerMethodName, Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.GetType().Name}.\nCaller: {caller.GetType().Name}.{callerMethodName}.\nParameter: {parameter.GetType().Name}.\nMessage: {ex.Message}", ex);
            }
        }
    }
}