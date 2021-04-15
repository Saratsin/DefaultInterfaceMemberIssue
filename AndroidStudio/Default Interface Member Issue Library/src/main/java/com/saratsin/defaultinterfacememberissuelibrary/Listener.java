package com.saratsin.defaultinterfacememberissuelibrary;

public interface Listener {
    default void onValueChanged(boolean value) {
    }
}
