using System;
using System.Diagnostics;
using Mono.Cecil;

public class MockAssemblyResolver : IAssemblyResolver
{
    public AssemblyDefinition Resolve(AssemblyNameReference name)
    {
        if (name.FullName == "System")
        {
            var codeBase = typeof(Debug).Assembly.CodeBase.Replace("file:///", "");
            return AssemblyDefinition.ReadAssembly(codeBase);
        }

        if (name.Name == "mscorlib")
        {
            var codeBase = typeof(string).Assembly.CodeBase.Replace("file:///", "");
            return AssemblyDefinition.ReadAssembly(codeBase);
        }

        return AssemblyDefinition.ReadAssembly(name.Name + ".dll");
    }

    public AssemblyDefinition Resolve(AssemblyNameReference name, ReaderParameters parameters)
    {
        throw new NotImplementedException();
    }


    public void Dispose()
    {
    }
}