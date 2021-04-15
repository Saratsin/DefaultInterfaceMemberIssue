package com.saratsin.defaultinterfacememberissuelibrary;

public class ListenerInvoker {
    public void InvokeListenerMethod(Listener listener) {
        listener.onValueChanged(true);
    }

    public void InvokeListenerImplementorMethod(ListenerImplementor listenerImplementor) {
        listenerImplementor.onValueChanged(true);
    }
}
