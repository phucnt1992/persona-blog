#addin nuget:?package=Cake.DotNetCoreEf&version=0.10.0
#tool "nuget:?package=xunit.runner.console"
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

Task("Run-EF-Core-Migration-Identity-Server")
.Does(()=>{
   Information("Migrating IdentityServer DB...");
   DotNetCoreEfDatabaseUpdate("./src/Persona.IdentityServer",  new DotNetCoreEfDatabaseUpdateSettings{ Context = "ConfigurationDbContext"});
   DotNetCoreEfDatabaseUpdate("./src/Persona.IdentityServer",  new DotNetCoreEfDatabaseUpdateSettings{ Context = "PersistedGrantDbContext"});
   DotNetCoreEfDatabaseUpdate("./src/Persona.IdentityServer", new DotNetCoreEfDatabaseUpdateSettings{ Context = "ApplicationDbContext"});
   Information("Finish to migrate IdentityServer DB.");
});

RunTarget(target);
