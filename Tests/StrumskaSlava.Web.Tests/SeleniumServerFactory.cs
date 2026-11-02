namespace StrumskaSlava.Web.Tests
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Hosting.Server;
    using Microsoft.AspNetCore.Hosting.Server.Features;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class SeleniumServerFactory<TStartup> : WebApplicationFactory<TStartup>
        where TStartup : class
    {
        private readonly Process process;

        private IHost host;

        public SeleniumServerFactory()
        {
            this.ClientOptions.BaseAddress = new Uri("https://localhost"); // will follow redirects by default

            this.process = new Process
                       {
                           StartInfo = new ProcessStartInfo
                                       {
                                           FileName = "selenium-standalone",
                                           Arguments = "start",
                                           UseShellExecute = true,
                                       },
                       };
            this.process.Start();
        }

        public string RootUri { get; set; } // Save this use by tests

        protected override IHost CreateHost(IHostBuilder builder)
        {
            // In-memory host used by WebApplicationFactory itself
            var testHost = builder.Build();

            // Real TCP port
            builder.ConfigureWebHost(webHostBuilder => webHostBuilder.UseKestrel());
            this.host = builder.Build();
            this.host.Start();
            this.RootUri = this.host.Services.GetRequiredService<IServer>()
                .Features.Get<IServerAddressesFeature>().Addresses.LastOrDefault(); // Last is https://localhost:5001!

            testHost.Start();
            return testHost;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                this.host?.Dispose();
                this.process.CloseMainWindow(); // Be sure to stop Selenium Standalone
            }
        }
    }
}
