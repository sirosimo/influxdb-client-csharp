using System;
using System.Diagnostics;

namespace InfluxDB.Client.Core.Internal {
    public class TraceHandler {
        private static readonly TraceSwitch TraceSwitch;

        static TraceHandler() {
            TraceSwitch = new TraceSwitch("InfluxDB", "Trace Switch for InfluxDB client");
            // Set the default trace level here. You can change it dynamically.
            // Available trace levels: Off, Error, Warning, Info, Verbose
            TraceSwitch.Level = TraceLevel.Info;
        }

        public static TraceLevel LogLevel {
            get => TraceSwitch.Level;
            set => TraceSwitch.Level = value;
        }

        public static void TraceError(string message) {
            if (TraceSwitch.TraceError) {
                Trace.WriteLine($"[ERROR] {DateTime.Now}: {message}");
            }
        }

        public static void TraceWarning(string message) {
            if (TraceSwitch.TraceWarning) {
                Trace.WriteLine($"[WARNING] {DateTime.Now}: {message}");
            }
        }

        public static void TraceInfo(string message) {
            if (TraceSwitch.TraceInfo) {
                Trace.WriteLine($"[INFO] {DateTime.Now}: {message}");
            }
        }

        public static void TraceVerbose(string message) {
            if (TraceSwitch.TraceVerbose) {
                Trace.WriteLine($"[VERBOSE] {DateTime.Now}: {message}");
            }
        }
    }
}