# DOTNET CORE SERVICE LIFETIME - EXAMPLE PROJECT

This project shows;

- There is how many lifetimes in dotnet core
- There is how many method to inject services
- How the lifetimes can be used in another service
- How the lifetimes cannot be used in another service

**---------------------------------------------**  
**Do not forget to examine the startup.cs file.**  
**---------------------------------------------**  

```
/// There is 4 way to use services:
/// 
/// 1. Constructor Injection
///     Created once in a class and all class functions use SAME instance event if instance is TRANCIENT!
///     Scope services cannot used as CI if service is singleton.
///     Independent of request
///     If want to use scope services in singleton services, use IServiceProvider or IHttpContextAccessor
/// 
/// 2. IServiceProvider
///     Singleton container for services
///     Independent of request
///     It can bu used even if there is no request.
///     It does not have scope services if used in singleton services. 
///         Even if IServiceProvider does not HAVE scope services, scope container CAN BE CREATED from it.
///     
/// 3. IHttpContextAccessor ( Also named as RequestServices or HttpContext )
///     Scope container for services
///     Dependent of request
///     There must be request to use it, otherwise it rise exception
///     It has both scope and singleton services.
///
/// 4. app.ApplicationServices
///     This is like IServiceProvider
///     This following codes runs once at startup.


/// USAGE:
///     Singleton:
///         Created only once and not destroyed until the end of the Application.
///         Like static variables.
///         Use where you need to maintain application wide state.
///         Singletons are also memory efficient.
///         Exp : Logging Service, Caching, App Configuration
///     Scope:
///         Created on request and delete after request ends.
///         Use where you need to maintain state withing a request.
///         If you do not know which one you should use, use scope.
///     Transient:
///         Always created new instance whenever app needs. 
///         Safest to create, but use more memory because create new instance has negative impact on performance.
///         Use for the lightweight service with little or no state.


/// NOTES:
///     Never inject Scoped & Transient services into Singleton service.
///     Never inject Transient services into scoped service.
```