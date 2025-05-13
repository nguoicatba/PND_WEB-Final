using System;
using System.Runtime.InteropServices;
using System.Runtime.Loader;

public class CustomAssemblyLoadContext : AssemblyLoadContext
{
    public IntPtr LoadUnmanagedLibrary(string absolutePath)
    {
        return LoadUnmanagedDll(absolutePath);
    }

    protected override IntPtr LoadUnmanagedDll(string unmanagedDllPath)
    {
        return LoadUnmanagedDllFromPath(unmanagedDllPath);
    }

    protected override System.Reflection.Assembly Load(System.Reflection.AssemblyName assemblyName)
    {
        return null;
    }
}
