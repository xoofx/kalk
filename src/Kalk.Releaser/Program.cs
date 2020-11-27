using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Octokit;

namespace Kalk.Releaser
{
    class Program
    {

        static async Task Main(string[] args)
        {
            var releaseApp = new ReleaserApp();
            await releaseApp.Run(args);
        }
    }
}
