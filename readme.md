# Netcore AOP with Autofac

An approach of adding interceptors in netstandard 2.0.3 project and avoid [conflicts](https://github.com/autofac/Autofac/issues/782) with Serializable attributes (netstandard and Autofac) is adding the following packages for creating Interceptors:

- Autofac.Extensions.DependencyInjection 4.4.0
- Castle.Core 4.3.1

This sample uses `<PackageReference Include="Autofac.Extras.DynamicProxy" Version="4.5.0" />` but this could cause conflicts with Serializable attributes.
