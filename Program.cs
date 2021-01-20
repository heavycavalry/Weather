using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Threading;

namespace Weather {
    class Program {
        public static void Main(string[] args) {

            new Builder.ProgramBuilder();
        }
    }
}