#tool nuget:?package=Cake.DotNetCoreEf
#addin nuget:?package=Cake.DotNetCoreEf
///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////
var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////
Setup(ctx =>
{
   // Executed BEFORE the first task.
   Information("Running tasks...");
});
Teardown(ctx =>
{
   // Executed AFTER the last task.
   Information("Finished running tasks.");
});

Task("Run-EF-Core-Migration")
.Does(()=>{
   DotNetCoreEfDatabaseUpdate("./src/Persona.IdentityServer");
})
