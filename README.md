# Java interfaces with default members issue

## Steps to reproduce
1. Run project with Min23 suffix
2. Look at app screen output
### Expected result
"No error" is written as when you run project with Min24 suffix (the only difference between Min23 and Min24 projects is minSdkVersion in AndroidManifest.xml)
### Actual Result
AbstractMethodError is thrown and shown in output

## Conditions
1. Min SDK version for Xamarin.Android application is set to 23 or lower.
2. Binding library with java interface with default method implementation is connected to the project
3. C# class inherits from this java interface, default method is not implemented (thus, default implementation should be used)
4. C# class is casted to the interface and default method is called

## Current workarounds for this issue
* Implement all default methods of the interface in C# class.
* Implement class in Java and bind it to C#, in this case default methods work properly
* Increase Min SDK version for Xamarin.Android application to 24 – then everything works like a charm

## Possible reasons of this issue
Probably there's some issue with targetCompatibility/sourceCompatibility with Java 8. And it only relates to our custom C# classes which are inherited or implement some java classes/interfaces.
When they exopose to Java world with java wrappers, probably something is going wrong. The big problem also is that this issue happens only in Runtime.
