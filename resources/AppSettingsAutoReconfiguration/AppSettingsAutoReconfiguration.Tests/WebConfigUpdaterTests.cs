using NUnit.Framework;
using System;
using System.Configuration;
using System.IO;
using System.Web.Configuration;

namespace AppSettingsAutoReconfiguration.Tests
{
	[TestFixture ()]
	[Ignore("Still to be implemented")]
	public class WebConfigUpdaterTests
	{
		[Test ()]
		public void ShouldAddModifiedAt ()
		{
			CreateSampleConfigFile ();

			new WebConfigUpdater("Web.config")
				.OverrideAppSettingsWithEnvironmentVars ();

			string directory = Path.GetDirectoryName(Path.GetFullPath("Web.config"));
			WebConfigurationFileMap wcfm = new WebConfigurationFileMap();
			VirtualDirectoryMapping vdm = new VirtualDirectoryMapping(directory, true, "Web.config");
			wcfm.VirtualDirectories.Add("/", vdm);

			//WebConfigurationManager seems bugging in Mono 3.2.4
			Configuration webConfig = WebConfigurationManager.OpenMappedWebConfiguration(wcfm, "/");

			CollectionAssert.Contains (webConfig.AppSettings.Settings.AllKeys, "AppSettingsAutoReconfiguration_ModifiedAt");
			Console.WriteLine (webConfig.AppSettings.Settings ["AppSettingsAutoReconfiguration_ModifiedAt"].Value);
		}

		static void CreateSampleConfigFile ()
		{
			System.IO.File.WriteAllText ("Web.config", @"<?xml version=""1.0"" encoding=""utf-8""?>
<!--
  For more information on how to configure your ASP.NET application, please visit
  http://go.microsoft.com/fwlink/?LinkId=169433
  -->
<configuration>
  <configSections>
    <!-- For more information on Entity Framework configuration, visit http://go.microsoft.com/fwlink/?LinkID=237468 -->
    <section name=""entityFramework"" type=""System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" requirePermission=""false"" />
  </configSections>
  <connectionStrings>
    <add name=""DefaultConnection"" connectionString=""Data Source=(LocalDb)\v11.0;Initial Catalog=aspnet-ShoelaceMVC-20130121215835;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\aspnet-ShoelaceMVC-20130121215835.mdf"" providerName=""System.Data.SqlClient"" />
  </connectionStrings>
  <appSettings>
    <add key=""Key1"" value=""Value1"" />
    <add key=""PORT"" value=""1234"" />
    <add key=""webpages:Version"" value=""2.0.0.0"" />
    <add key=""webpages:Enabled"" value=""false"" />
    <add key=""PreserveLoginUrl"" value=""true"" />
    <add key=""ClientValidationEnabled"" value=""true"" />
    <add key=""UnobtrusiveJavaScriptEnabled"" value=""true"" />
  </appSettings>
  <system.web>
    <compilation debug=""true"" targetFramework=""4.5"" />
    <httpRuntime targetFramework=""4.5"" />
    <authentication mode=""Forms"">
      <forms loginUrl=""~/Account/Login"" timeout=""2880"" />
    </authentication>
    <pages>
      <namespaces>
        <add namespace=""System.Web.Helpers"" />
        <add namespace=""System.Web.Mvc"" />
        <add namespace=""System.Web.Mvc.Ajax"" />
        <add namespace=""System.Web.Mvc.Html"" />
        <add namespace=""System.Web.Optimization"" />
        <add namespace=""System.Web.Routing"" />
        <add namespace=""System.Web.WebPages"" />
      </namespaces>
    </pages>
  </system.web>
  <system.webServer>
    <validation validateIntegratedModeConfiguration=""false"" />
    <handlers>
      <remove name=""ExtensionlessUrlHandler-ISAPI-4.0_32bit"" />
      <remove name=""ExtensionlessUrlHandler-ISAPI-4.0_64bit"" />
      <remove name=""ExtensionlessUrlHandler-Integrated-4.0"" />
      <add name=""ExtensionlessUrlHandler-ISAPI-4.0_32bit"" path=""*."" verb=""GET,HEAD,POST,DEBUG,PUT,DELETE,PATCH,OPTIONS"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness32"" responseBufferLimit=""0"" />
      <add name=""ExtensionlessUrlHandler-ISAPI-4.0_64bit"" path=""*."" verb=""GET,HEAD,POST,DEBUG,PUT,DELETE,PATCH,OPTIONS"" modules=""IsapiModule"" scriptProcessor=""%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll"" preCondition=""classicMode,runtimeVersionv4.0,bitness64"" responseBufferLimit=""0"" />
      <add name=""ExtensionlessUrlHandler-Integrated-4.0"" path=""*."" verb=""GET,HEAD,POST,DEBUG,PUT,DELETE,PATCH,OPTIONS"" type=""System.Web.Handlers.TransferRequestHandler"" preCondition=""integratedMode,runtimeVersionv4.0"" />
    </handlers>
  </system.webServer>
  <runtime>
    <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
      <dependentAssembly>
        <assemblyIdentity name=""DotNetOpenAuth.Core"" publicKeyToken=""2780ccd10d57b246"" />
        <bindingRedirect oldVersion=""0.0.0.0-4.1.0.0"" newVersion=""4.1.0.0"" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name=""DotNetOpenAuth.AspNet"" publicKeyToken=""2780ccd10d57b246"" />
        <bindingRedirect oldVersion=""0.0.0.0-4.1.0.0"" newVersion=""4.1.0.0"" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name=""DotNetOpenAuth.OAuth"" publicKeyToken=""2780ccd10d57b246"" />
        <bindingRedirect oldVersion=""1.0.0.0-4.0.0.0"" newVersion=""4.1.0.0"" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name=""DotNetOpenAuth.OAuth.Consumer"" publicKeyToken=""2780ccd10d57b246"" />
        <bindingRedirect oldVersion=""1.0.0.0-4.0.0.0"" newVersion=""4.1.0.0"" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name=""DotNetOpenAuth.OpenId"" publicKeyToken=""2780ccd10d57b246"" />
        <bindingRedirect oldVersion=""1.0.0.0-4.0.0.0"" newVersion=""4.1.0.0"" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name=""DotNetOpenAuth.OpenId.RelayingParty"" publicKeyToken=""2780ccd10d57b246"" />
        <bindingRedirect oldVersion=""1.0.0.0-4.0.0.0"" newVersion=""4.1.0.0"" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name=""System.Web.Helpers"" publicKeyToken=""31bf3856ad364e35"" />
        <bindingRedirect oldVersion=""1.0.0.0-2.0.0.0"" newVersion=""2.0.0.0"" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name=""System.Web.Mvc"" publicKeyToken=""31bf3856ad364e35"" />
        <bindingRedirect oldVersion=""0.0.0.0-4.0.0.0"" newVersion=""4.0.0.0"" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name=""System.Web.WebPages"" publicKeyToken=""31bf3856ad364e35"" />
        <bindingRedirect oldVersion=""1.0.0.0-2.0.0.0"" newVersion=""2.0.0.0"" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name=""WebGrease"" publicKeyToken=""31bf3856ad364e35"" />
        <bindingRedirect oldVersion=""0.0.0.0-1.3.0.0"" newVersion=""1.3.0.0"" />
      </dependentAssembly>
    </assemblyBinding>
  </runtime>
  <entityFramework>
    <defaultConnectionFactory type=""System.Data.Entity.Infrastructure.LocalDbConnectionFactory, EntityFramework"">
      <parameters>
        <parameter value=""v11.0"" />
      </parameters>
    </defaultConnectionFactory>
  </entityFramework>
</configuration>
");
		}
	}
}

